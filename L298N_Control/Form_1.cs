using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;

namespace L298N_Control
{
    public partial class Form_1 : Form
    {
        public static int PortOpen_LoadCell = 0;
        public static string UNOCOM_LoadCell;

        public static string time_LC, LC1, LC2;
        private int counter;
        public static double[] ForceChangeX, ForceChangeY1, ForceChangeY2;
        public static bool runMeasurement_LC;
        public static bool readyLC;

        public Form_1()
        {
            InitializeComponent();
            InitChart();
            FetchAvailablePorts();

            ForceChangeX = new double[5000];
            ForceChangeY1 = new double[5000];
            ForceChangeY2 = new double[5000];
        }

        void FetchAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPortName.Items.AddRange(ports);
        }

        #region Form to Form
        public void OpenPort()
        {
            try
            {
                if (PortOpen_LoadCell == 1)
                {
                    MessageBox.Show("You have already connected to UNO-Board.");
                }
                else
                {
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    iconPictureBoxOn.IconColor = Color.ForestGreen;
                    buttonOpenPort.Text = "Close Port";

                    PortOpen_LoadCell = 1;

                    comboBoxPortName.Text = Form_2.UNOCOM_Form_2;
                    comboBoxBaudRate.Text = "57600";

                    textBoxCMD.AppendText("Port Opened." + Environment.NewLine);
                    textBoxCMD.AppendText("Wait seconds for stabilization..." + Environment.NewLine);
                }
            }
            catch { }
        }

        public void ClosePort()
        {
            try
            {
                if (PortOpen_LoadCell == 0)
                {
                    MessageBox.Show("You are not connected to UNO-Board.");
                }
                else
                {
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                    iconPictureBoxOn.IconColor = Color.Firebrick;
                    iconPictureBoxReady.IconColor = Color.Firebrick;
                    readyLC = false;
                    buttonOpenPort.Text = "Open Port";

                    PortOpen_LoadCell = 0;
                    textBoxCMD.AppendText("Port Closed." + Environment.NewLine);
                }
            }
            catch { }
        }

        public void LCMeasurement()
        {
            textBoxDataSave.AppendText(time_LC + '\t' + LC1 + '\t' + LC2 + Environment.NewLine);

            labelForceLC1.Text = "LC1 = " + LC1 + "N";
            labelForceLC2.Text = "LC2 = " + LC2 + "N";
        }

        public void plotLoadCell()
        {
            var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            principalForm.LoadCellM();
            principalForm.LCM_ON();

            //plot
            ForceChangeX[counter] = Convert.ToDouble(time_LC);
            ForceChangeY1[counter] = Convert.ToDouble(LC1);
            ForceChangeY2[counter] = Convert.ToDouble(LC2);
            chartLoadCell.Series[0].Points.AddXY(ForceChangeX[counter], ForceChangeY1[counter]);
            chartLoadCell.Series[1].Points.AddXY(ForceChangeX[counter], ForceChangeY2[counter]);
            chartLoadCell.ChartAreas[0].RecalculateAxesScale();

            counter++;
        }

        public static string cmdForm_1;
        public void Receivedcmd()
        {
            textBoxCMD.AppendText(cmdForm_1 + Environment.NewLine);
        }

        public void Reset()
        {
            labelForceLC1.Text = "Load Cell1 Value";
            labelForceLC2.Text = "Load Cell1 Value";
            foreach (var series in chartLoadCell.Series)
            {
                series.Points.Clear();
            }

            textBoxDataSave.Clear();

            time_LC = "";
            LC1 = "";
            LC2 = "";
            counter = 0;
            iconPictureBoxReady.IconColor = Color.ForestGreen;
            textBoxCMD.AppendText("New Force Measurement Ready." + Environment.NewLine);

            readyLC = true;
        }

        public void Startup()
        {
            textBoxCMD.AppendText("Startup is complete." + Environment.NewLine);
            textBoxCMD.AppendText("Please click Reset Button to prepare for a new measurement." + Environment.NewLine);
        }


        #endregion

        #region Chart Initialization
        private void InitChart()
        {
            chartLoadCell.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartLoadCell.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartLoadCell.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartLoadCell.ChartAreas[0].AxisX.Title = "Time [s]";
            chartLoadCell.ChartAreas[0].AxisY.Title = "Force [N]"; //name of the X-Y axis
            chartLoadCell.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartLoadCell.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartLoadCell.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
            chartLoadCell.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
            chartLoadCell.ChartAreas[0].CursorX.AutoScroll = true;

            Series series1 = new Series()
            {
                Name = "Load Cell1",
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Series series2 = new Series()
            {
                Name = "Load Cell2",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Title title = new Title()
            {
                Font = new Font("Segoe UI", 12),
                Text = "Force Measurement"
            };

            chartLoadCell.Titles.Add(title);
            chartLoadCell.Series.Add(series1);
            chartLoadCell.Series.Add(series2);
        }

        #endregion

        #region Clear Textbox; Save the files
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxCMD.Clear();
        }

        private void buttonSaveMData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\Desktop";
            saveFile.Title = "Save your Measured Data";
            saveFile.DefaultExt = "srt";
            saveFile.Filter = "csv file (*.csv)|*.csv|text file (*.txt)|*.txt|subtitle file (*.srt)|*.srt|All Files (*.*)|*.*";
            saveFile.RestoreDirectory = true;
            saveFile.FileName = DateTime.Now.ToString("yyyy-MM-dd") + " Force_Measurement";

            string save_txt = "Time [s]" + "\t" + "Force1 [N]" + "\t" + "Force2 [N]" + "\r\n" + textBoxDataSave.Text;
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_LoadCell == 1)
                {
                    Form_2.PortUno.WriteLine("r");
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to UNO-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (PortOpen_LoadCell == 0)//
            {
                try
                {
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    iconPictureBoxOn.IconColor = Color.ForestGreen;

                    UNOCOM_LoadCell = comboBoxPortName.Text;
                    var principalForm_2 = System.Windows.Forms.Application.OpenForms.OfType<Form_2>().FirstOrDefault();
                    principalForm_2.OpenPort();

                    buttonOpenPort.Text = "Close Port";
                    PortOpen_LoadCell = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Serial Port Open Error.");
                }
            }
            else
            {
                try
                {
                    if (runMeasurement_LC)
                    {
                        Form_2.PortUno.WriteLine("l");
                        runMeasurement_LC = false;
                    }

                    if (readyLC)
                    {
                        readyLC = false;
                    }

                    var principalForm_2 = System.Windows.Forms.Application.OpenForms.OfType<Form_2>().FirstOrDefault();
                    principalForm_2.ClosePort();

                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;

                    buttonOpenPort.Text = "Open Port";

                    iconPictureBoxReady.IconColor = Color.Firebrick;
                    PortOpen_LoadCell = 0;
                }
                catch { }
            }
        }

        private void comboBoxPortName_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxBaudRate.Text = "57600";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_LoadCell == 1)
                {
                    if (readyLC)
                    {
                        Form_2.PortUno.WriteLine("L");
                        runMeasurement_LC = true;
                    }
                    else
                    {
                        textBoxCMD.AppendText("Measurement is not Ready!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to UNO-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_LoadCell == 1)
                {
                    if (runMeasurement_LC)
                    {
                        Form_2.PortUno.WriteLine("l");
                        runMeasurement_LC = false;

                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm.LCM_OFF();
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to UNO-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }


    }
}

 



