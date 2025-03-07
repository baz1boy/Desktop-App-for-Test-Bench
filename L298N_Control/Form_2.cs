using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace L298N_Control
{
    public partial class Form_2 : Form
    {
        public static string peelangleSetForm_2;
        public static string peelangleMeaForm_2;
        public static string peelangleMeaTimeForm_2;

        public static SerialPort PortUno;
        public static int PortOpen = 0;
        public static bool runMeasurement_IE;
        public static string UNOCOM_Form_2;
        public static bool readyIE;

        //private int onoff = 0;
        //private string[] IncrementalEncoder = new string[2];
        //private string[] LoadCell = new string[3];
        private int counter;
        private double _timeie, _ie;
        public static double Angle, Angle_set; 
        public static double[] DegreeChangeX, DegreeChangeY;

        private double _timelc, _lc1, _lc2;
        private double _timeielc, _ielc_ie, _ielc_lc1, _ielc_lc2;

        public Form_2()
        {
            InitializeComponent();
            FetchAvailablePorts();
            InitChart();

            DegreeChangeX = new double[5000];
            DegreeChangeY = new double[5000];
        }

        void FetchAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPortName.Items.AddRange(ports);
        }

        #region Form to Form
        private void Form_2_Load(object sender, EventArgs e)
        {
            textBoxDegreeSet.Text = Form_3.peelangleSet;
        }

        private void textBoxDegreeSet_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxDegreeSet.Text = Form_3.peelangleSet;
        }

        public void OpenPort()
        {
            try
            {
                if (PortOpen == 1)
                {
                    MessageBox.Show("You have already connected to UNO-Board.");
                }
                else
                {
                    comboBoxPortName.Text = Form_1.UNOCOM_LoadCell;
                    comboBoxBaudRate.Text = "57600";
                    Form_2OpenPort();
                }
            }
            catch { }
        }

        private void Form_2OpenPort()
        {
            object obj = new object();
            EventArgs ea = new EventArgs();
            buttonOpenPort_Click(obj, ea);
        }

        public void ClosePort()
        {
            try
            {
                if (PortOpen == 0)
                {
                    MessageBox.Show("You are not connected to UNO-Board.");
                }
                else
                {
                    Form_2OpenPort();
                }
            }
            catch { }
        }

        public void SetPeelAngle()
        {
            textBoxDegreeSet.Text = Form_3.peelangleSet;
        }

        public void QuickReset()
        {
            try
            {
                if (PortOpen == 1)
                {
                    PortUno.WriteLine("N");

                    labelAngleChange.Text = "0";
                    labelDegree.Text = "0";
                    foreach (var series in chartAngleChange.Series)
                    {
                        series.Points.Clear();
                    }
                    foreach (var series in chartPeelAngle.Series)
                    {
                        series.Points.Clear();
                    }

                    textBoxMeasuredData.Clear();

                    var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.AngleReset();
                }
            }
            catch { }
        }

        #endregion

        #region COM Port Connection
        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (PortOpen == 0)//为0时，表示关闭，此时可以进行打开操作
            {
                PortUno = new SerialPort();
                PortUno.PortName = comboBoxPortName.Text;//获取端口号
                PortUno.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);//设置波特率
                PortUno.ReadBufferSize = 200000000;
                PortUno.DataReceived += Port_DataReceived;
                try
                {
                    PortUno.Open();
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    iconPictureBoxOn.IconColor = Color.ForestGreen;
                    Thread.Sleep(1000);
                    textBoxCMD.AppendText("Port Opened." + Environment.NewLine);
                    buttonOpenPort.Text = "Close Port";
                    
                    PortOpen = 1;
                    var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.ConnectToUNO();

                    UNOCOM_Form_2 = comboBoxPortName.Text;
                    if (Form_1.PortOpen_LoadCell == 0)
                    {
                        var principalForm_1 = System.Windows.Forms.Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalForm_1.OpenPort();
                    }

                    textBoxCMD.AppendText("Wait seconds for stabilization..." + Environment.NewLine);
                    TimeNow = DateTime.Now;
                    timer1.Start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Serial Port Open Error.");
                }
            }
            else
            {
                try
                {
                    if (runMeasurement_IE)
                    {
                        PortUno.WriteLine("s");
                        //onoff = 0;
                        runMeasurement_IE = false;
                    }

                    readyIE = false;
                    PortUno.Close();
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                    iconPictureBoxOn.IconColor = Color.Firebrick;
                    textBoxCMD.AppendText("Port Closed." + Environment.NewLine);
                    buttonOpenPort.Text = "Open Port";
                    PortOpen = 0;

                    var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.DisconnectToUNO();

                    if (Form_1.PortOpen_LoadCell == 1)
                    {
                        var principalForm_1 = System.Windows.Forms.Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalForm_1.ClosePort();
                    }
                }
                catch{ }
            }
        }

        private void comboBoxPortName_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxBaudRate.Text = "57600";
        }

        private string ReceivedData;
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceivedData = PortUno.ReadLine();
            this.Invoke(new Action(ProcessingData));
        }

        #endregion

        #region ReceivedData Processing
        private void ProcessingData()
        {
            try
            {
                char firstchar;
                firstchar = ReceivedData[0];

                switch (firstchar)
                {
                    case 'C':
                        string CMD = ReceivedData.Substring(1);
                        textBoxCMD.AppendText(CMD + Environment.NewLine);
                        break;

                    case 'c':
                        string cmd = ReceivedData.Substring(1);
                        Form_1.cmdForm_1 = cmd;
                        var principalFormLC1 = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalFormLC1.Receivedcmd();
                        break;

                    case 'A':
                        string IE = ReceivedData.Substring(1);
                        string[] splitIE = IE.Split('\t');
                        //_timeie = Convert.ToDouble(splitIE[0]);
                        //_ie = Convert.ToDouble(splitIE[1]);
                        double.TryParse(splitIE[0], out _timeie);
                        double.TryParse(splitIE[1], out _ie);
                        DegreeChangeX[counter] = _timeie;
                        DegreeChangeY[counter] = _ie;

                        //plot 1
                        chartAngleChange.Series[0].Points.AddXY(DegreeChangeX[counter], DegreeChangeY[counter]);
                        chartAngleChange.ChartAreas[0].RecalculateAxesScale();

                        //plot 2
                        Angle = Angle_set + _ie;
                        chartPeelAngle.Series[0].Points.AddXY(DegreeChangeX[counter], Angle);
                        ////plot setpoint
                        chartPeelAngle.Series[1].Points.AddXY(DegreeChangeX[counter], Angle_set);
                        chartPeelAngle.ChartAreas[0].RecalculateAxesScale();

                        if (runMeasurement_IE)
                        {
                            labelAngleChange.Text = _timeie.ToString() + "s | " + _ie.ToString() + "°";
                            labelDegree.Text = _timeie.ToString() + "s | " + Angle.ToString() + "°";
                        }

                        textBoxMeasuredData.AppendText(_timeie.ToString() + "\t" + _ie.ToString() + "\t" + Angle.ToString() + Environment.NewLine);

                        peelangleMeaTimeForm_2 = _timeie.ToString();
                        peelangleMeaForm_2 = Angle.ToString();
                        var principalForm1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm1.AngleMeasure();
                        principalForm1.PointsCaculation();

                        counter++;
                        break;

                    case 'F':
                        string LC = ReceivedData.Substring(1);
                        string[] splitLC = LC.Split('\t');
                        _timelc = Convert.ToDouble(splitLC[0]);
                        _lc1 = Convert.ToDouble(splitLC[1]);
                        _lc2 = Convert.ToDouble(splitLC[2]);
                        //double.TryParse(splitLC[0], out _timelc);
                        //double.TryParse(splitLC[1], out _lc1);
                        //double.TryParse(splitLC[2], out _lc2);

                        Form_1.time_LC = _timelc.ToString();
                        Form_1.LC1 = _lc1.ToString();
                        Form_1.LC2 = _lc2.ToString();

                        var principalFormLC2 = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalFormLC2.LCMeasurement();
                        principalFormLC2.plotLoadCell();
                        break;

                    case 'O':
                        var principalFormLC3 = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalFormLC3.Reset();

                        var principalForm1_Prepare = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm1_Prepare.getReadyLC();
                        break;

                    case 'n':
                        textBoxCMD.AppendText("New Angle Measurement Ready." + Environment.NewLine);

                        var principalLCReset = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalLCReset.Reset();

                        var principalLCPrepare = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalLCPrepare.getReadyLC();

                        MessageBox.Show("Quick Reset Complete.");
                        break;

                    case 'T':
                        string IELC = ReceivedData.Substring(1);
                        string[] splitIELC = IELC.Split('\t');
                        _timeielc = Convert.ToDouble(splitIELC[0]);
                        _ielc_ie = Convert.ToDouble(splitIELC[1]);
                        _ielc_lc1 = Convert.ToDouble(splitIELC[2]);
                        _ielc_lc2 = Convert.ToDouble(splitIELC[3]);
                        //double.TryParse(splitIELC[0], out _timeielc);
                        //double.TryParse(splitIELC[1], out _ielc_ie);
                        //double.TryParse(splitIELC[2], out _ielc_lc1);
                        //double.TryParse(splitIELC[3], out _ielc_lc2);
                        DegreeChangeX[counter] = _timeielc;
                        DegreeChangeY[counter] = _ielc_ie;

                        //plot 1
                        chartAngleChange.Series[0].Points.AddXY(DegreeChangeX[counter], DegreeChangeY[counter]);
                        chartAngleChange.ChartAreas[0].RecalculateAxesScale();

                        //plot 2
                        Angle = Angle_set + _ielc_ie;
                        chartPeelAngle.Series[0].Points.AddXY(DegreeChangeX[counter], Angle);
                        chartPeelAngle.Series[1].Points.AddXY(DegreeChangeX[counter], Angle_set);
                        chartPeelAngle.ChartAreas[0].RecalculateAxesScale();

                        if (runMeasurement_IE)
                        {
                            labelAngleChange.Text = _timeielc.ToString() + "s | " + _ielc_ie.ToString() + "°";
                            labelDegree.Text = _timeielc.ToString() + "s | " + Angle.ToString() + "°";
                        }

                        textBoxMeasuredData.AppendText(_timeielc.ToString() + "\t" + _ielc_ie.ToString() + "\t" + Angle.ToString() + Environment.NewLine);

                        peelangleMeaTimeForm_2 = _timeielc.ToString();
                        peelangleMeaForm_2 = Angle.ToString();

                        var principalFormIELC_IE = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalFormIELC_IE.AngleMeasure();
                        principalFormIELC_IE.PointsCaculation();
                        principalFormIELC_IE.PAM_ON();

                        Form_1.time_LC = _timeielc.ToString();
                        Form_1.LC1 = _ielc_lc1.ToString();
                        Form_1.LC2 = _ielc_lc2.ToString();

                        var principalFormIELC_LC = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                        principalFormIELC_LC.LCMeasurement();
                        principalFormIELC_LC.plotLoadCell();

                        var principalFormIELC_Plot= Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalFormIELC_Plot.IELC_Plot();

                        counter++;
                        break;
                }
            }
            catch { }

        }

        #endregion

        #region Set, Start, Stop Measure
        private void buttonSetAngle_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen == 1)
                {
                    Angle_set = Convert.ToDouble(textBoxDegreeSet.Text);
                    string setAngle = 'S' + textBoxDegreeSet.Text;
                    PortUno.WriteLine(setAngle);

                    labelAngleChange.Text = "0";
                    labelDegree.Text = "0";
                    foreach (var series in chartAngleChange.Series)
                    {
                        series.Points.Clear();
                    }
                    foreach (var series in chartPeelAngle.Series)
                    {
                        series.Points.Clear();
                    }
                    textBoxMeasuredData.Clear();

                    //onoff = 0;
                    runMeasurement_IE = false;
                    iconPictureBoxReady.IconColor = Color.ForestGreen;

                    peelangleSetForm_2 = textBoxDegreeSet.Text;
                    var principalForm = Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                    principalForm.SetPeelAngleForm_3();

                    readyIE = true;
                    var principalForm1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm1.getReadyIE();
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to UNO-Board!" + Environment.NewLine);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input!");
            }
        }

        private void buttonStartMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen == 1)
                {
                    if (readyIE)
                    {
                        if (!runMeasurement_IE)
                        {
                            PortUno.WriteLine("I");
                            //onoff = 1;
                            runMeasurement_IE = true;

                            var principal = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                            principal.PAM_ON();
                        }
                    }
                    else
                    {
                        textBoxCMD.AppendText("Measurement is not ready!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to UNO-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void buttonStopMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                if (runMeasurement_IE)
                {
                    PortUno.WriteLine("i");
                    //onoff = 0;
                    runMeasurement_IE = false;

                    var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.PAM_OFF();
                }
            }catch { }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen == 1)
                {
                    PortUno.WriteLine("R");

                    labelAngleChange.Text = "0";
                    labelDegree.Text = "0";
                    foreach (var series in chartAngleChange.Series)
                    {
                        series.Points.Clear();
                    }
                    foreach (var series in chartPeelAngle.Series)
                    {
                        series.Points.Clear();
                    }

                    textBoxMeasuredData.Clear();

                    var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.AngleReset();
                }
            }
            catch { }  
        }

        #endregion

        #region Data Save to File
        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\Desktop";
            saveFile.Title = "Save your Measured Data";
            saveFile.DefaultExt = "srt";
            saveFile.Filter = "csv file (*.csv)|*.csv|text file (*.txt)|*.txt|subtitle file (*.srt)|*.srt|All Files (*.*)|*.*";
            saveFile.RestoreDirectory = true;

            saveFile.FileName = DateTime.Now.ToString("yyyy-MM-dd") + " Peel_Angle_Measurement";

            string save_txt = "Time [s]" + "\t" + "Angle Deviation [°]" + "\t" + "Current Peel Angle [°]" + "\r\n" + textBoxMeasuredData.Text;
            string save_csv = save_txt.Replace("\t", ",");


            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                switch (saveFile.FilterIndex)
                {
                    case 1:
                        using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                            writer.WriteLine(save_csv);
                        break;
                    case 2:
                        using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                            writer.WriteLine(save_txt);
                        break;
                }

                string saved = Path.GetFullPath(saveFile.FileName.ToString());
                MessageBox.Show(saved, "Your file has been saved");               
            }
        }
        #endregion

        #region Initializaiton Chart
        private void InitChart()
        {
            chartAngleChange.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartAngleChange.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartAngleChange.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartAngleChange.ChartAreas[0].AxisX.Title = "Time [s]";
            chartAngleChange.ChartAreas[0].AxisY.Title = "Angle [°]"; //name of the X-Y axis
            chartAngleChange.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartAngleChange.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartAngleChange.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
            chartAngleChange.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
            chartAngleChange.ChartAreas[0].CursorX.AutoScroll = true;

            Series series1 = new Series()
            {
                Name = "Angle Deviation",
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Title title1 = new Title()
            {
                Font = new Font("Segoe UI", 12),
                Text = "Peel Angle Deviation"
            };

            chartAngleChange.Titles.Add(title1);
            chartAngleChange.Series.Add(series1);

            ///////////
            chartPeelAngle.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartPeelAngle.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartPeelAngle.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartPeelAngle.ChartAreas[0].AxisX.Title = "Time [s]";
            chartPeelAngle.ChartAreas[0].AxisY.Title = "Angle [°]"; //name of the X-Y axis
            chartPeelAngle.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartPeelAngle.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartPeelAngle.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
            chartPeelAngle.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
            chartPeelAngle.ChartAreas[0].CursorX.AutoScroll = true;

            Series series2 = new Series()
            {
                Name = "Peel Angle",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Series seriesSetAngle = new Series()
            {
                Name = "Set Point",
                Color = System.Drawing.Color.Orange,
                ChartType = SeriesChartType.FastLine,
                BorderWidth = 2, 
                IsXValueIndexed = true
            };

            Title title2 = new Title()
            {
                Font = new Font("Segoe UI", 12),
                Text = "Peel Angle"
            };

            chartPeelAngle.Titles.Add(title2);
            chartPeelAngle.Series.Add(series2);
            chartPeelAngle.Series.Add(seriesSetAngle);
        }
        #endregion

        private void buttonClearData_Click(object sender, EventArgs e)
        {
            textBoxCMD.Clear();
        }

        DateTime TimeNow = new DateTime();
        private void timer1_Tick(object sender, EventArgs e)
        {
            //TimeSpan waitsecs = new TimeSpan();
            TimeSpan waitsecs = DateTime.Now - TimeNow;
            if (waitsecs.TotalSeconds >= 4)
            {
                timer1.Stop();
                textBoxCMD.AppendText("Startup is complete." + Environment.NewLine);
                textBoxCMD.AppendText("Please set Peel Angle." + Environment.NewLine);

                var principalForm = Application.OpenForms.OfType<Form_1>().FirstOrDefault();
                principalForm.Startup();
            }
        }

        private void Form_2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(PortOpen == 1)
                {
                    PortUno.WriteLine("E");
                    //onoff = 0;
                    runMeasurement_IE = false;

                    PortUno.Close();
                    PortOpen = 0;
                }
            }
            catch { }
        }
    }
}
