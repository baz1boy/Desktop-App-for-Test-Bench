using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using FontAwesome.Sharp;

namespace L298N_Control
{
    public partial class Form_4 : Form
    {
        public static int PortOpen_DU = 0;
        public static string MEGACOM_Form_4;
        public static bool resetForm_4 = false;
        public static string DUSpeed;
        public static string linear_travel_speed;
        private bool DUready = false;
        public static string setSpeedComplete;

        System.DateTime TimeNow = new DateTime();
        TimeSpan TimeCount = new TimeSpan();
        TimeSpan TimeConti = new TimeSpan();

        public Form_4()
        {
            InitializeComponent();
            FetchAvailablePorts();
        }

        void FetchAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPortName.Items.AddRange(ports);
        }

        #region COM Port
        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (PortOpen_DU == 0)//为0时，表示关闭，此时可以进行打开操作
            {
                try
                {
                    MEGACOM_Form_4 = comboBoxPortName.Text;
                    var principalForm_3 = System.Windows.Forms.Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                    principalForm_3.OpenPort();
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
                    var principalForm_3 = System.Windows.Forms.Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                    principalForm_3.ClosePort();
                }
                catch { }
            }
        }

        private void comboBoxPortName_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxBaudRate.Text = "9600";
        }

        #endregion

        #region Form to Form 
        public void OpenPort()
        {
            try
            {
                if (PortOpen_DU == 1)
                {
                    MessageBox.Show("You have already connected to MEGA-Board.");
                }
                else
                {
                    iconPictureBoxOn.IconChar = IconChar.ToggleOn;
                    iconPictureBoxOn.IconColor = Color.ForestGreen;
                    buttonOpenPort.Text = "Close Port";

                    textBoxCMD.AppendText("Port Opened." + Environment.NewLine);
                    PortOpen_DU = 1;

                    comboBoxPortName.Text = Form_3.MEGACOM_Form_3;
                    comboBoxBaudRate.Text = "9600";
                }
            }
            catch { }
        }

        public void ClosePort()
        {
            try
            {
                if (PortOpen_DU == 0)
                {
                    MessageBox.Show("You are not connected to MEGA-Board.");
                }
                else
                {
                    iconPictureBoxOn.IconChar = IconChar.ToggleOff;
                    iconPictureBoxOn.IconColor = Color.Firebrick;
                    buttonOpenPort.Text = "Open Port";

                    DUready = false;
                    iconPictureBoxReady.IconColor = Color.Firebrick;
                    buttonConnect.Text = "Connect";
                    textBoxCMD.AppendText("Port Closed." + Environment.NewLine);
                    PortOpen_DU = 0;
                }
            }
            catch { }
        }

        public void TimerGo()
        {
            timerDU.Start();
            TimeNow = DateTime.Now;
        }

        public void setDUSpeed()
        {
            textBoxCMD.AppendText(setSpeedComplete + Environment.NewLine);
        }
        #endregion

        #region Control the Delivery Unit
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_DU == 1)
                {
                    if (!DUready)
                    {
                        Form_3.PortMega.WriteLine("O");
                        iconPictureBoxReady.IconColor = Color.ForestGreen;
                        DUready = true;
                        buttonConnect.Text = "Disconnect";

                        textBoxCMD.AppendText("Delivery Motor Ready." + Environment.NewLine);

                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm.getReadyDU();
                    }
                    else
                    {
                        Form_3.PortMega.WriteLine("o");
                        iconPictureBoxReady.IconColor = Color.Firebrick;
                        DUready = false;
                        buttonConnect.Text = "Connect";
                        labelCurrentSpeedDataAuto.Text = "800";
                        labelCurrentSpeedDataManual.Text = "800";
                        radioButtonForward.Checked = false;
                        radioButtonBack.Checked = false;

                        textBoxCMD.AppendText("Delivery Motor Disconnected." + Environment.NewLine);

                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        principalForm.notReadyDU();
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }

            }catch { }

        }

        private void buttonRunDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_DU == 1)
                {
                    if (DUready)
                    {
                        Form_3.PortMega.WriteLine("D");
                        resetForm_4 = false;
                    }
                    else
                    {
                        textBoxCMD.AppendText("Delivery Unit is not ready." + Environment.NewLine);
                    }
                }
            }
            catch { }
        }

        private void buttonStopDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_DU == 1)
                {
                    Form_3.PortMega.WriteLine("d");

                    timerDU.Stop();
                    TimeConti = TimeCount;
                }
            }
            catch { }
        }

        private void buttonSetDUSpeedAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_DU == 1)
                {
                    if (DUready)
                    {
                        string setSpeed = "va" + textBoxDeliverySpeedAuto.Text;
                        Form_3.PortMega.WriteLine(setSpeed);

                        DUSpeed = textBoxDeliverySpeedAuto.Text;
                        labelCurrentSpeedDataAuto.Text = DUSpeed;
                        travelspeed = Convert.ToDouble(DUSpeed) * conversion_factor;
                        labelLTSpeedAutoData.Text = travelspeed.ToString();
                    }
                    else
                    {
                        textBoxCMD.AppendText("Delivery Unit is not ready." + Environment.NewLine);
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Auto with time Interval
        private double timesec;
        private double travelspeed = 4;             // 4 mm/s when inital 800step/sec
        private double interval = 30;         // time interval: 30s forward, 30s backward
        private int direction = 1;
        private double conversion_factor = 0.005;
        private void timerDU_Tick(object sender, EventArgs e)
        {
            TimeCount = TimeConti + (DateTime.Now - TimeNow);
            labelTimerData.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", TimeCount.Hours, TimeCount.Minutes, TimeCount.Seconds, TimeCount.Milliseconds / 10);
            timesec = Convert.ToDouble(TimeCount.TotalSeconds.ToString("0.000000"));

            if (timesec >= interval)
            {
                TimeNow = DateTime.Now;
                TimeCount = TimeSpan.Zero;
                TimeConti = TimeSpan.Zero;
                direction = -direction;
            }

            if (direction > 0)
            {
                labelPositionData.Text = (0 + timesec * travelspeed).ToString();
                labeldir.Text = "+";      // forward
            }
            else
            {
                labelPositionData.Text = (interval * travelspeed - timesec * travelspeed).ToString();
                labeldir.Text = "-";       // backward
            }
        }

        private void buttonRSP_Click(object sender, EventArgs e)
        {
            Form_3.PortMega.WriteLine("n");

            TimeCount = TimeSpan.Zero;
            TimeConti = TimeSpan.Zero;
            direction = 1;
            timesec = 0;

            labeldir.Text = "DIR";
            labelPositionData.Text = "0";
            labelTimerData.Text = "00:00:00:00";
        }

        #endregion

        #region Manual Test Delivery Unit
        private void buttonSetDUSpeedManual_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortOpen_DU == 1)
                {
                    if (DUready)
                    {
                        string setSpeed = "vm" + textBoxDeliverySpeedManual.Text;
                        Form_3.PortMega.WriteLine(setSpeed);

                        labelCurrentSpeedDataManual.Text = textBoxDeliverySpeedManual.Text;
                        labelLTSpeedManualData.Text = (Convert.ToDouble(labelCurrentSpeedDataManual.Text) * conversion_factor).ToString();
                    }
                    else
                    {
                        textBoxCMD.AppendText("Delivery Unit is not ready." + Environment.NewLine);
                    }
                }
            }
            catch { }
        }

        private void buttonManualRun_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_DU == 1)
                {
                    if (DUready)
                    {
                        if (radioButtonForward.Checked)
                        {
                            string KF = "K0";
                            Form_3.PortMega.WriteLine(KF);
                        }
                        else if (radioButtonBack.Checked)
                        {
                            string KB = "K1";
                            Form_3.PortMega.WriteLine(KB);
                        }else if(!radioButtonForward.Checked && !radioButtonBack.Checked)
                        {
                            textBoxCMD.AppendText("Direction not Selected." + Environment.NewLine);
                        }
                    }
                    else
                    {
                        textBoxCMD.AppendText("Delivery Unit is not ready." + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }

            }
            catch { }
        }

        private void buttonManualStop_Click(object sender, EventArgs e)
        {
            try
            {
                if(PortOpen_DU == 1)
                {
                    if (DUready)
                    {
                        Form_3.PortMega.WriteLine("k");
                    }
                    else
                    {
                        textBoxCMD.AppendText("Delivery Unit is not ready." + Environment.NewLine);
                    }
                }
                else
                {
                    textBoxCMD.AppendText("Not connected to MEGA-Board!" + Environment.NewLine);
                }
            }
            catch { }
        }

        // Hold to Control
        private void iconButtonBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (DUready)
            {
                Form_3.PortMega.WriteLine("H1");

            }
        }

        private void iconButtonBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (DUready)
            {
                Form_3.PortMega.WriteLine("h1");

            }
        }

        private void iconButtonForward_MouseDown(object sender, MouseEventArgs e)
        {
            if (DUready)
            {
                Form_3.PortMega.WriteLine("H0");

            }
        }

        private void iconButtonForward_MouseUp(object sender, MouseEventArgs e)
        {
            if (DUready)
            {
                Form_3.PortMega.WriteLine("h0");

            }
        }

        #endregion

        private void Form_4_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (PortOpen_DU == 1)
                {
                    Form_3.PortMega.WriteLine("o");
                    Form_3.PortMega.Close();
                }
                DUready = false;
            }catch { }

        }

        private void buttonClearCMD_Click(object sender, EventArgs e)
        {
            textBoxCMD.Clear();
        }

    }
}
