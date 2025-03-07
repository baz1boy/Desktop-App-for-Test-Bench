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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Action = System.Action;
using System.Reflection;
using DDPTestBench;

namespace L298N_Control
{
    public partial class Form_3 : Form
    {
        public static SerialPort PortMega;

        System.DateTime TimeNow = new DateTime();
        TimeSpan TimeCount = new TimeSpan();
        TimeSpan TimeConti = new TimeSpan();
        private int timego;
        private bool DMready = false;
        public static bool DMautoready = false;
        private bool runMotor = false;

        public static string tapethicknessSet;
        public static string peelangleSet;
        public static string peelspeedSet;
        public static string peellengthSet;
        public static string peelwidthSet;
        public static string tapetemperature;
        public static int PortOpen_MEGA= 0;
        public static string MEGACOM_Form_3;

        public Form_3()
        {
            InitializeComponent();
            FetchAvailablePorts();
            this.dataGridView1.DoubleBuffered(true);
        }

        void FetchAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPortName.Items.AddRange(ports);
        }

        #region COM Port 
        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (buttonOpenPort.Text == "Open Port")//为0时，表示关闭，此时可以进行打开操作
            {
                PortMega = new SerialPort();

                PortMega.PortName = comboBoxPortName.Text;//获取端口号
                PortMega.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);//设置波特率
                PortMega.ReadBufferSize = 200000000;
                PortMega.DataReceived += Port_DataReceived;
                try
                {
                    PortMega.Open();
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                    iconPictureBoxOn.IconColor = Color.ForestGreen;
                    Thread.Sleep(1000);
                    buttonOpenPort.Text = "Close Port";
                    textBoxCMD.AppendText("Port Opened." + Environment.NewLine);

                    PortOpen_MEGA = 1;
                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.ConnectToMEGA();

                    MEGACOM_Form_3 = comboBoxPortName.Text;
                    if(Form_4.PortOpen_DU == 0)
                    {
                        var principalForm_4 = System.Windows.Forms.Application.OpenForms.OfType<Form_4>().FirstOrDefault();
                        principalForm_4.OpenPort();
                    }
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
                    PortMega.WriteLine("E");
                    runMotor = false;
                    DMready = false;
                    DMautoready = false;
                    iconPictureBoxReady.IconColor = Color.Firebrick;
                    buttonConnect.Text = "Connect";

                    PortMega.Close();

                    PortOpen_MEGA = 0;
                    iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                    iconPictureBoxOn.IconColor = Color.Firebrick;
                    buttonOpenPort.Text = "Open Port";
                    radioButtonAuto.Checked = false;
                    radioButtonManual.Checked = false;

                    textBoxCMD.AppendText("Port Closed." + Environment.NewLine);

                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.DisconnectToMEGA();

                    if(Form_4.PortOpen_DU == 1)
                    {
                        var principalForm_4 = System.Windows.Forms.Application.OpenForms.OfType<Form_4>().FirstOrDefault();
                        principalForm_4.ClosePort();
                    }
                }
                catch { }
            }
        }

        private void comboBoxPortName_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxBaudRate.Text = "9600";
        }
        #endregion

        #region Port DataReceived

        private string ReceivedData;
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceivedData = PortMega.ReadLine();
            this.Invoke(new Action(ProcessingData));
        }


        private string[] atot_data = new string[2];
        private double _at, _ot;
        private string[] motorspeed_data = new string[2];
        private double _drum1, _drum2;
        private void ProcessingData()
        {
            try
            {
                char firstchar;
                firstchar = ReceivedData[0];

                switch (firstchar)
                {
                    case 'P':
                        if (timego == 1)
                        {
                            Mytimer.Start();
                            TimeNow = DateTime.Now;
                            timego = 0;
                        }

                        var principalForm1DrumStop = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm1DrumStop.DrumStart();
                        break;

                    case 'p':
                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form_4>().FirstOrDefault();
                        principalForm.TimerGo();
                        break;

                    case 'Q':
                        if (!reset)
                        {
                            textBoxCMD.AppendText("Reset Complete." + Environment.NewLine);
                            labelTimerData.Text = "00:00:00:00";
                            TimeConti = DateTime.Now - DateTime.Now;
                            TimeCount = DateTime.Now - DateTime.Now;
                            labelTimeInMin.Text = "0";
                            labelPeelPositionData.Text = "0";
                            labelCurrentSpeedDataAuto.Text = "0";
                            labelCurrentSpeedD1.Text = "0";
                            labelCurrentSpeedD2.Text = "0";
                            labelCurrentSpeedDataAuto.Text = "1000";

                            reset = true;

                            var principalFormResetDrum = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                            principalFormResetDrum.ResetDrum();
                        }
                        break;

                    case 'q':
                        if (!Form_4.resetForm_4)
                        {
                            MessageBox.Show("Reset Position Complete");
                            Form_4.resetForm_4 = true;
                        }
                        break;

                    case 'a':
                        if (setPa == 0)
                        {
                            textBoxCMD.AppendText("Parameter Setup has been updated." + Environment.NewLine);
                            labelCurrentSpeedDataAuto.Text = textBoxPSpeed.Text;
                   
                            setPa = 1;
                        }
                        break;

                    case 'T':
                        string TT = ReceivedData.Substring(1);
                        atot_data = TT.Split('\t');
                        double.TryParse(atot_data[0], out _at);
                        double.TryParse(atot_data[1], out _ot);
                        Form1.ambient_temperature = _at.ToString();
                        Form1.object_temperature = _ot.ToString();

                        var principalForm1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm1.aToT();
                        break;



                    case 'J':
                        string motorspeed = ReceivedData.Substring(1);
                        motorspeed_data = motorspeed.Split('\t');
                        double.TryParse(motorspeed_data[0], out _drum1);
                        double.TryParse(motorspeed_data[1], out _drum2);
                        labelCurrentSpeedD1.Text = _drum1.ToString();
                        labelCurrentSpeedD2.Text = _drum2.ToString();

                        Form1.drum1speed = _drum1.ToString();
                        Form1.drum2speed = _drum2.ToString();
                        var principalForm1DrumSpeed = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm1DrumSpeed.DrumSpeed();
                        break;

                    case 'j':
                        string setDUspeed = ReceivedData.Substring(1);
                        Form_4.setSpeedComplete = setDUspeed;

                        var principalsetDUspeed = System.Windows.Forms.Application.OpenForms.OfType<Form_4>().FirstOrDefault();
                        principalsetDUspeed.setDUSpeed();
                        break;
                }
            }
            catch { }
        }

        private void buttonClearCMD_Click(object sender, EventArgs e)
        {
            textBoxCMD.Clear();
        }

        #endregion

        #region Form to Form 
        public void SetPeelAngleForm_3()
        {
            try
            {
                textBoxPAngle.Text = Form_2.peelangleSetForm_2;
                if(PortOpen_MEGA == 0)
                {
                    MessageBox.Show("You are not connected to MEGA-Board, Please confirm the parameters settings.");
                }
                else { }
            }
            catch { }
        }

        public void MainRunMotor()
        {
            try
            {
                if (PortOpen_MEGA == 0)
                {
                    MessageBox.Show("You are not connected to MEGA-Board.");
                }
                else
                {
                    //Form_3RunMotor();
                }
            }
            catch { }
        }

        private void Form_3OpenPort()
        {
            object obj = new object();
            EventArgs ea = new EventArgs();
            buttonOpenPort_Click(obj, ea);
        }

        public void OpenPort()
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    MessageBox.Show("You have already connected to MEGA-Board.");
                }
                else
                {
                    comboBoxPortName.Text = Form_4.MEGACOM_Form_4;
                    comboBoxBaudRate.Text = "9600";
                    Form_3OpenPort();
                }
            }
            catch { }
        }

        public void ClosePort()
        {
            try
            {
                if (PortOpen_MEGA == 0)
                {
                    MessageBox.Show("You are not connected to MEGA-Board.");
                }
                else
                {
                    Form_3OpenPort();
                }
            }
            catch { }
        }

        public void StartTest()
        {
            try
            {
                object obj = new object();
                EventArgs ea = new EventArgs();
                buttonRun_Click(obj, ea);
            }catch { }
        }

        public void StopTest()
        {
            try
            {
                object obj = new object();
                EventArgs ea = new EventArgs();
                buttonStop_Click(obj, ea);
            }
            catch { }
        }

        public void QuickReset()
        {
            try
            {
                object obj = new object();
                EventArgs ea = new EventArgs();
                buttonReset_Click(obj, ea);
            }
            catch { }
        }

        #endregion

        #region DataGridView Edit
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxThickness.Text == "" || textBoxPAngle.Text == "" || textBoxPSpeed.Text == "" || textBoxPLength.Text == "" || textBoxPWidth.Text == "" || textBoxTemperature.Text == "")
                {
                    MessageBox.Show("Please enter empty text box");
                }
                else
                {
                    float Thic = Convert.ToSingle(textBoxThickness.Text);
                    float PAng = Convert.ToSingle(textBoxPAngle.Text);
                    float PSpe = Convert.ToSingle(textBoxPSpeed.Text);
                    float PLen = Convert.ToSingle(textBoxPLength.Text);
                    float PWid = Convert.ToSingle(textBoxPWidth.Text);
                    float Tem = Convert.ToSingle(textBoxTemperature.Text);

                    dataGridView1.Rows.Add(Thic, PAng, PSpe, PLen, PWid, Tem);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input.");
            }       
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxThickness.Text == "" || textBoxPAngle.Text == "" || textBoxPSpeed.Text == "" || textBoxPLength.Text == "" || textBoxPWidth.Text == "" || textBoxTemperature.Text == "")
                {
                    MessageBox.Show("Please enter empty text box");
                }
                else
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    float Thic = Convert.ToSingle(textBoxThickness.Text);
                    float PAng = Convert.ToSingle(textBoxPAngle.Text);
                    float PSpe = Convert.ToSingle(textBoxPSpeed.Text);
                    float PLen = Convert.ToSingle(textBoxPLength.Text);
                    float PWid = Convert.ToSingle(textBoxPWidth.Text);
                    float Tem = Convert.ToSingle(textBoxTemperature.Text);

                    dataGridView1.Rows.Insert(selectedRowIndex, Thic, PAng, PSpe, PLen, PWid, Tem);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                if (DialogResult.Yes == MessageBox.Show("Are you Sure you want to delete this Row?", "Delete Selected Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    if (selectedRowIndex != -1)
                    {
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);
                    }
                }
            }catch { }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow updateRow = dataGridView1.Rows[selectedRowIndex];
                if (DialogResult.Yes == MessageBox.Show("Are you Sure you want to change this Row?", "Change Selected Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    if (selectedRowIndex != -1)
                    {
                        updateRow.Cells[0].Value = textBoxThickness.Text;
                        updateRow.Cells[1].Value = textBoxPAngle.Text;
                        updateRow.Cells[2].Value = textBoxPSpeed.Text;
                        updateRow.Cells[3].Value = textBoxPLength.Text;
                        updateRow.Cells[4].Value = textBoxPWidth.Text;
                        updateRow.Cells[5].Value = textBoxTemperature.Text;

                    }
                }
            }catch { }
        }

        // import Excel Parameters;
        _Application importExcel;
        _Workbook importWorkbook;
        _Worksheet importWorksheet;
        Range importExcelRange;
        private void buttonInput_Click(object sender, EventArgs e)
        {
            try
            {
                importExcel = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importExcelFileDialog = new OpenFileDialog();
                //Filter Excel Files Only
                importExcelFileDialog.Filter = "Excel Files | *.xls;*.xlsx;*.xlsm";
                // Dialog Title
                importExcelFileDialog.Title = "Import Excel File";

                if (importExcelFileDialog.ShowDialog() == DialogResult.OK)
                {
                    importWorkbook = importExcel.Workbooks.Open(importExcelFileDialog.FileName);
                    importWorksheet = importWorkbook.Sheets.get_Item(1);
                    importExcelRange = importWorksheet.UsedRange;

                    //Get Excel Rows
                    for (int i = 2; i <= importExcelRange.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add
                            (importExcelRange.Cells[i, 1].Value,
                            importExcelRange.Cells[i, 2].Value,
                            importExcelRange.Cells[i, 3].Value,
                            importExcelRange.Cells[i, 4].Value,
                            importExcelRange.Cells[i, 5].Value,
                            importExcelRange.Cells[i, 6].Value);
                    }
                    importWorkbook.Close();
                    importExcel.Quit();
                }
            }
            catch (Exception exError)
            {
                MessageBox.Show(exError.StackTrace);
            }
            finally
            {
                //importWorkbook.Close();
                //importExcel.Quit();
            }
        }

        // export Excel Parameters;
        _Application exportExcel;
        _Workbook exportWorkbook;
        _Worksheet excelWorksheet;
        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                exportExcel = new Microsoft.Office.Interop.Excel.Application();
                exportWorkbook = exportExcel.Workbooks.Add(Type.Missing);
                excelWorksheet = null;
                excelWorksheet = exportWorkbook.Sheets["Sheet1"];
                excelWorksheet = exportWorkbook.ActiveSheet;
                //Excel Sheet Name
                excelWorksheet.Name = "Test Settings";


                //Get DatagridView Header
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    //Populating excel Header 
                    excelWorksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                //Export DatagridView Rows
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        //Populating Excel Rows
                        excelWorksheet.Cells[j + 2, k + 1] = Convert.ToString(dataGridView1.Rows[j].Cells[k].Value);
                    }
                }
                excelWorksheet.Columns.AutoFit();

                SaveFileDialog exportExcelFile = new SaveFileDialog();
                exportExcelFile.Filter = "Excel Files | *.xls;*.xlsx;*.xlsm";
                //Excel File Name
                exportExcelFile.FileName = "DDTTest_Parameters";
                //Default Excel Extension
                exportExcelFile.DefaultExt = "xlsx";

                if (exportExcelFile.ShowDialog() == DialogResult.OK)
                {
                    // Save Excel File To your Computer
                    exportWorkbook.SaveAs(exportExcelFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                    // Message after excel file is saved
                    MessageBox.Show("Excel File Saved.");
                    exportWorkbook.Close();
                    exportExcel.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //exportWorkbook.Close();
                //exportExcel.Quit();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Clear this table?", "Clear All Value", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("DataGridView Is Empty!");
                }
            }    
        }

        #endregion

        #region Popular data with DataGridView and Textbox 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow selectedDatagridViewRow = dataGridView1.Rows[e.RowIndex];

                    textBoxThickness.Text = selectedDatagridViewRow.Cells[0].Value.ToString();
                    textBoxPAngle.Text = selectedDatagridViewRow.Cells[1].Value.ToString();
                    textBoxPSpeed.Text = selectedDatagridViewRow.Cells[2].Value.ToString();
                    textBoxPLength.Text = selectedDatagridViewRow.Cells[3].Value.ToString();
                    textBoxPWidth.Text = selectedDatagridViewRow.Cells[4].Value.ToString();
                    textBoxTemperature.Text = selectedDatagridViewRow.Cells[5].Value.ToString();

                    /*textBoxThickness.Text = Convert.ToString(selectedDatagridViewRow.Cells[0].Value);
                    textBoxPAngle.Text = Convert.ToString(selectedDatagridViewRow.Cells[1].Value);
                    textBoxPSpeed.Text = Convert.ToString(selectedDatagridViewRow.Cells[2].Value);
                    textBoxPLength.Text = Convert.ToString(selectedDatagridViewRow.Cells[3].Value);
                    textBoxPWidth.Text = Convert.ToString(selectedDatagridViewRow.Cells[4].Value);*/
                }
            }catch { }
        }

        // Add number before every row;
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }


        #endregion

        #region Send Parameters to Arduino
        private int setPa;
        private void buttonAllConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxThickness.Text == "" || textBoxPAngle.Text == "" || textBoxPSpeed.Text == "" || textBoxPLength.Text == "" || textBoxPWidth.Text == "" || textBoxTemperature.Text == "")
                {
                    MessageBox.Show("Please enter empty text box");
                }
                else
                {
                    float Thic = Convert.ToSingle(textBoxThickness.Text);
                    float PAng = Convert.ToSingle(textBoxPAngle.Text);
                    float PSpe = Convert.ToSingle(textBoxPSpeed.Text);
                    float PLen = Convert.ToSingle(textBoxPLength.Text);
                    float PWid = Convert.ToSingle(textBoxPWidth.Text);
                    float Tem = Convert.ToSingle(textBoxTemperature.Text);

                    dataGridView1.Rows.Add(Thic, PAng, PSpe, PLen, PWid, Tem);
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input.");
            }

            try
            {
                if(PortOpen_MEGA == 1)
                {
                    string ap = 'A'
                        + textBoxThickness.Text + ","
                        + textBoxPAngle.Text + ","
                        + textBoxPSpeed.Text + ","
                        + textBoxPLength.Text + ","
                        + textBoxPWidth.Text + ","
                        + textBoxTemperature.Text + ",";

                    PortMega.WriteLine(ap);
                    setPa = 0;

                    // current setup to display:
                    tapethicknessSet = textBoxThickness.Text;
                    peelangleSet = textBoxPAngle.Text;
                    peelspeedSet = textBoxPSpeed.Text;
                    peellengthSet = textBoxPLength.Text;
                    peelwidthSet = textBoxPWidth.Text;
                    tapetemperature = textBoxTemperature.Text;

                    labelCurrentSpeedDataAuto.Text = peelspeedSet;
                    // transfer data to other Forms
                    var principalForm1 = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm1.SetALLParameters();

                    var principalForm2 = System.Windows.Forms.Application.OpenForms.OfType<Form_2>().FirstOrDefault();
                    principalForm2.SetPeelAngle();
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            textBoxThickness.Text = "";
            textBoxPAngle.Text = "";
            textBoxPSpeed.Text = "";
            textBoxPLength.Text = "";
            textBoxPWidth.Text = "";
            textBoxTemperature.Text = "";
        }
        #endregion

        #region Time Counting
        private void Mytimer_Tick(object sender, EventArgs e)
        {
            TimeCount = TimeConti + (DateTime.Now - TimeNow);
            labelTimerData.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", TimeCount.Hours, TimeCount.Minutes, TimeCount.Seconds, TimeCount.Milliseconds / 10);

            labelTimeInMin.Text = TimeCount.TotalMinutes.ToString("0.0000");
            labelPeelPositionData.Text = (Convert.ToDouble(labelTimeInMin.Text) * Convert.ToDouble(labelCurrentSpeedDataAuto.Text)).ToString("0.000");

            Form1.testtime = TimeCount.TotalSeconds.ToString("0.00");
            Form1.tapeposition = labelPeelPositionData.Text;
            var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
            principalForm.TestTime();
        }

        #endregion

        #region Mode Choose
        private int manual = 0;
        private void radioButtonAuto_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    radioButtonManual.Checked = false;
                    radioButtonAuto.Checked = true;
                    PortMega.Write("m");
                    manual = 0;
                    textBoxCMD.AppendText("Auto Mode Selected." + Environment.NewLine);
                    
                    if (DMready)
                    {
                        DMautoready = true;
                    }

                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.ModeAuto();
                }
                else
                {
                    radioButtonManual.Checked = false;
                    radioButtonAuto.Checked = false;
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }     
        }
        private void radioButtonManual_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    radioButtonAuto.Checked = false;
                    radioButtonManual.Checked = true;
                    PortMega.Write("M");
                    Mytimer.Stop();
                    TimeConti = TimeCount;
                    timego = 0;
                    manual = 1;
                    DMautoready = false;
                    textBoxCMD.AppendText("Manual Mode Selected." + Environment.NewLine);

                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.ModeManual();
                }
                else
                {
                    radioButtonManual.Checked = false;
                    radioButtonAuto.Checked = false;
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }catch { }  
        }
        #endregion

        #region Auto Control
        ////////////////// Auto Control
        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    if (manual == 1 || !radioButtonAuto.Checked)
                    {
                        textBoxCMD.AppendText("Not in Auto Mode now" + "\r\n" + "Please select Auto Mode!" + Environment.NewLine);
                    }
                    else if (manual == 0 && radioButtonAuto.Checked)
                    {
                        if (DMready)
                        {
                            timego = 1;
                            reset = false;
                            PortMega.WriteLine("G");
                            runMotor = true;
                        }
                        else
                        {
                            textBoxCMD.AppendText("Drum Motors not Connected!" + Environment.NewLine);
                        }
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }

            }catch { }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    if (manual == 1 || !radioButtonAuto.Checked)
                    {
                        textBoxCMD.AppendText("Not in Auto Mode now" + "\r\n" + "Please select Auto Mode!" + Environment.NewLine);
                    }
                    else if (manual == 0 && radioButtonAuto.Checked)
                    {
                        if (DMready)
                        {
                            PortMega.WriteLine("g");
                            Mytimer.Stop();
                            TimeConti = TimeCount;
                            timego = 0;

                            var principalForm1DrumStop = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                            principalForm1DrumStop.DrumStop();
                        }
                        else
                        {
                            textBoxCMD.AppendText("Drum Motors not Connected!" + Environment.NewLine);
                        }
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }

            }catch { }

        }

        private void buttonEmStop_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    PortMega.WriteLine("X");
                    Mytimer.Stop();
                    TimeConti = TimeCount;
                    timego = 0;
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }

        }

        private void buttonSetSpeedAuto_Click(object sender, EventArgs e)
        {
            if (PortOpen_MEGA == 1)
            {
                if (manual == 0 && radioButtonAuto.Checked)
                {
                    string sps = "VP" + textBoxAutoSpeed.Text;
                    PortMega.WriteLine(sps);
                    labelCurrentSpeedDataAuto.Text = textBoxAutoSpeed.Text;
                    textBoxCMD.AppendText("Peel Speed set to " + textBoxAutoSpeed.Text + "[mm/min]." + Environment.NewLine);

                    peelspeedSet = textBoxAutoSpeed.Text;
                    textBoxPSpeed.Text = peelspeedSet;
                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    principalForm.SetPeelAngle();
                }
            }
            else
            {
                textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
            }
        }

        private bool reset = false;
        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    if (manual == 1 || !radioButtonAuto.Checked)
                    {
                        textBoxCMD.AppendText("Not in Auto Mode now" + "\r\n" + "Please select Auto Mode!" + Environment.NewLine);
                    }
                    else if (manual == 0 && radioButtonAuto.Checked)
                    {
                        if (DMready)
                        {
                            PortMega.WriteLine("N");
                        }
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }

        }
        #endregion

        #region Manual Control

        //////////////// Manual Control

        //// Drum 1 Click:
        private void iconButtonD1CCW_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 1;
                        string y1 = 'Y' + dir1.ToString();
                        PortMega.WriteLine(y1);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }catch { }
        }

        private void iconButtonD1CW_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 0;
                        string y1 = 'Y' + dir1.ToString();
                        PortMega.WriteLine(y1);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);

                }
            }
            catch { }
        }

        //// Drum 2 Click:
        private void iconButtonD2CCW_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 1;
                        string y2 = 'y' + dir2.ToString();
                        PortMega.WriteLine(y2);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void iconButtonD2CW_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 0;
                        string y2 = 'y' + dir2.ToString();
                        PortMega.WriteLine(y2);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now." + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        //// Drum 1 Hold:
        ///
        // Counter Clockwise
        private void iconButtonD1HoldCCW_MouseDown(object sender, MouseEventArgs e) //按下Drum1开始逆时针持续转动
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 1;
                        string l1 = 'L' + dir1.ToString();
                        PortMega.WriteLine(l1);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void iconButtonD1HoldCCW_MouseUp(object sender, MouseEventArgs e) //直到抬起鼠标转动停止
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 3;
                        string l1 = 'L' + dir1.ToString();
                        PortMega.WriteLine(l1);
                    }
                }
            }
            catch { }
        }

        // Clockwise
        private void iconButtonD1HoldCW_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 0;
                        string l1 = 'L' + dir1.ToString();
                        PortMega.WriteLine(l1);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch {}
        }

        private void iconButtonD1HoldCW_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir1 = 3;
                        string l1 = 'L' + dir1.ToString();
                        PortMega.WriteLine(l1);
                    }
                }
            }
            catch { }
        }

        //// Drum2 Hold:
        // Counter Clockwise
        private void iconButtonD2HoldCCW_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 1;
                        string l2 = 'l' + dir2.ToString();
                        PortMega.WriteLine(l2);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void iconButtonD2HoldCCW_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 3;
                        string l2 = 'l' + dir2.ToString();
                        PortMega.WriteLine(l2);
                    }
                }
            }
            catch { }
        }

        // Clockwise
        private void iconButtonD2HoldCW_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 0;
                        string l2 = 'l' + dir2.ToString();
                        PortMega.WriteLine(l2);
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void iconButtonD2HoldCW_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        int dir2 = 3;
                        string l2 = 'l' + dir2.ToString();
                        PortMega.WriteLine(l2);
                    }
                }
            }
            catch { }
        }

        //
        private void buttonSetSpeedD1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        string ss1 = "VL" + textBoxManualSpeedD1.Text;
                        PortMega.WriteLine(ss1);
                        labelCurrentSpeedDataManualD1.Text = textBoxManualSpeedD1.Text;

                        textBoxCMD.AppendText("Drum1 Speed set to " + textBoxManualSpeedD1.Text + " [mm/min]." + Environment.NewLine);
                    }
                }
            }
            catch { }
        }

        private void buttonSetSpeedD2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        string ss2 = "VR" + textBoxManualSpeedD2.Text;
                        PortMega.WriteLine(ss2);
                        labelCurrentSpeedDataManualD2.Text = textBoxManualSpeedD2.Text;

                        textBoxCMD.AppendText("Drum2 Speed set to " + textBoxManualSpeedD2.Text + " [mm/min]." + Environment.NewLine);
                    }
                }
            }
            catch { }
        }

        private void buttonManualrunD1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        PortMega.WriteLine("x1");
                    }
                    else
                    {
                        textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        private void buttonManualstopD1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (manual == 1)
                    {
                        PortMega.WriteLine("x0");
                    }
                }
            }
            catch { }
        }

        private void buttonManualrunD2_Click(object sender, EventArgs e)
        {
            if (PortOpen_MEGA == 1)
            {
                if (manual == 1)
                {
                    PortMega.WriteLine("x2");
                }
                else
                {
                    textBoxCMD.AppendText("Not in Manaul Mode now" + "\r\n" + "Please select Manual Mode!" + Environment.NewLine);
                }
            }
            else
            {
                textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
            }
        }

        private void buttonManualstopD2_Click(object sender, EventArgs e)
        {
            if (PortOpen_MEGA == 1)
            {
                if (manual == 1)
                {
                    PortMega.WriteLine("x3");
                }
            }
        }

        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Ready to Control Drum Motors
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_MEGA == 1)
                {
                    if (!DMready)
                    {
                        PortMega.WriteLine("C");
                        iconPictureBoxReady.IconColor = Color.ForestGreen;
                        DMready = true;
                        buttonConnect.Text = "Disconnect";
                        if(manual == 0 && radioButtonAuto.Checked)
                        {
                            DMautoready = true;
                        }
                        textBoxCMD.AppendText("Drum Motors Ready." + Environment.NewLine);

                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm.getReadyDM();
                    }
                    else
                    {
                        PortMega.WriteLine("c");
                        iconPictureBoxReady.IconColor = Color.Firebrick;
                        DMready = false;
                        DMautoready = false;
                        buttonConnect.Text = "Connect";

                        textBoxCMD.AppendText("Drum Motors Disconnected." + Environment.NewLine);

                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm.notReadyDM();
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }

            }
            catch { }
        }

        #endregion

        private void Form_3_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (buttonOpenPort.Text == "Close Port")
                {
                    PortMega.WriteLine("E");
                    PortMega.Close();
                    PortOpen_MEGA = 0;
                }
                else { }
            }
            catch { }
        }
    }
}
