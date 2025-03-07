using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Security.Cryptography;

namespace L298N_Control
{
    public partial class Form1 : Form
    {
        public static Color color1 = Color.FromArgb(255, 255, 255);
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public static string peelangleSetForm1;
        public static string ambient_temperature;
        public static string object_temperature;
        public static string drum1speed;
        public static string drum2speed;
        public static string testtime;
        public static string tapeposition;
        public static bool parameter_settings = false;
        public static bool heating;
        public static bool cooling;
        public static bool water_cooler;
        private double R2 = 75; // mm
        private double distance_sensor_drumaxis = 281.5; // mm
        private double hp, C1, peelforce;

        public Form1()
        {
            InitializeComponent();
            InitChart();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(8,60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            IconButtondisable();
            DatetimeDisplay();
        }



        #region Window Size
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width <= 1200)
            {
                this.Width = 1400;
            }

            if (this.Height <= 800)
            {
                this.Height = 800;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int GWL_STYLE = -16;
        public const int WS_DISABLED = 0x8000000;

        public static void SetControlEnabled(Control c, bool enabled)
        {
            if (enabled)
            { SetWindowLong(c.Handle, GWL_STYLE, (~WS_DISABLED) & GetWindowLong(c.Handle, GWL_STYLE)); }
            else
            { SetWindowLong(c.Handle, GWL_STYLE, WS_DISABLED + GetWindowLong(c.Handle, GWL_STYLE)); }
        }

        private void IconButtondisable()
        {
            SetControlEnabled(this.iconButtonCurrentForm, false);
            SetControlEnabled(this.iconButtonMotorAuto, false);
            SetControlEnabled(this.iconButtonMotorManual, false);
            SetControlEnabled(this.iconButtonDUAuto, false);
            SetControlEnabled(this.iconButtonDUManual, false);
            SetControlEnabled(this.iconButtonMEGA, false);
            SetControlEnabled(this.iconButtonUNO, false);
            SetControlEnabled(this.labelProgramName, false);
            SetControlEnabled(this.iconButtonHeat, false);
            SetControlEnabled(this.iconButtonCool, false);
        }

        private void DatetimeDisplay()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("G");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        #endregion

        #region Form to Form:
        public void SetALLParameters()
        {
            labelTT.Text = Form_3.tapethicknessSet;
            labelPA.Text = Form_3.peelangleSet;
            labelPS.Text = Form_3.peelspeedSet;
            labelPL.Text = Form_3.peellengthSet;
            labelTW.Text = Form_3.peelwidthSet;
            labelSetTData.Text = Form_3.tapetemperature;
            hp = Convert.ToDouble(Form_3.tapethicknessSet);

            if (Convert.ToDouble(Form_3.tapetemperature) > 35)
            {
                iconPictureBoxTarget.IconChar = IconChar.TemperatureHigh;
                iconPictureBoxTarget.IconColor = Color.IndianRed;
            }
            else
            {
                iconPictureBoxTarget.IconChar = IconChar.TemperatureLow;
                iconPictureBoxTarget.IconColor = Color.LightSkyBlue;
            }

            parameter_settings = true;
        }

        public void SetPeelAngle()
        {
            labelPS.Text = Form_3.peelspeedSet;
        }

        public void ConnectToMEGA()
        {
            iconButtonMEGA.IconChar = IconChar.ToggleOn;
            iconButtonMEGA.IconColor = Color.ForestGreen;
        }
        public void DisconnectToMEGA()
        {
            iconButtonMEGA.IconChar = IconChar.ToggleOff;
            iconButtonMEGA.IconColor = Color.Firebrick;
            //toolTip1.SetToolTip(iconButtonMEGA, "MEGA-Board Not Connected");

            iconButtonMotorAuto.IconChar = IconChar.Circle;
            iconButtonMotorAuto.IconFont = IconFont.Regular;
            iconButtonMotorAuto.IconColor = Color.DimGray;
            iconButtonMotorManual.IconChar = IconChar.Circle;
            iconButtonMotorManual.IconFont = IconFont.Regular;
            iconButtonMotorManual.IconColor = Color.DimGray;

            iconPictureBoxDMReady.IconChar = IconChar.Circle;
            iconPictureBoxDMReady.IconColor = Color.Firebrick;
            iconPictureBoxDUReady.IconChar = IconChar.Circle;
            iconPictureBoxDUReady.IconColor = Color.Firebrick;

            buttonTemSensor.Text = "Connect";
            iconPictureBoxAmbientTemperature.IconColor = Color.Firebrick;
            iconPictureBoxObjectTemperature.IconColor = Color.Firebrick;
            iconPictureBoxPeltier.IconColor = Color.Firebrick;
            iconPictureBoxTarget.IconChar = IconChar.TemperatureHigh;
            iconPictureBoxTarget.IconColor = Color.DarkGray;
            labelAmbientTemData.Text = "0";
            labelObjectTemData.Text = "0";
            labelSetTData.Text = "0";
            iconButtonHeat.IconChar = IconChar.Circle;
            iconButtonHeat.IconFont = IconFont.Regular;
            iconButtonHeat.IconColor = Color.DimGray;
            iconButtonCool.IconChar = IconChar.Circle;
            iconButtonCool.IconFont = IconFont.Regular;
            iconButtonCool.IconColor = Color.DimGray;
        }

        public void aToT()
        {
            labelAmbientTemData.Text = ambient_temperature;
            labelObjectTemData.Text = object_temperature;
        }

        public void ConnectToUNO()
        {
            iconButtonUNO.IconChar = IconChar.ToggleOn;
            iconButtonUNO.IconColor = Color.ForestGreen;
            toolTip1.SetToolTip(iconButtonUNO, "UNO-Board Connected");

        }

        public void DisconnectToUNO()
        {
            iconButtonUNO.IconChar = IconChar.ToggleOff;
            iconButtonUNO.IconColor = Color.Firebrick;
            toolTip1.SetToolTip(iconButtonUNO, "UNO-Board Not Connected");

            iconPictureBoxIEReady.IconChar = IconChar.Circle;
            iconPictureBoxIEReady.IconColor = Color.Firebrick;
            iconPictureBoxLCReady.IconChar = IconChar.Circle;
            iconPictureBoxLCReady.IconColor = Color.Firebrick;

            iconPictureBoxLC1.IconColor = Color.Firebrick;
            iconPictureBoxLC2.IconColor = Color.Firebrick;
        }

        public void ModeAuto()
        {
            iconButtonMotorManual.IconChar = IconChar.Circle;
            iconButtonMotorManual.IconFont = IconFont.Regular;
            iconButtonMotorManual.IconColor = Color.DimGray;
            iconButtonMotorAuto.IconChar = IconChar.DotCircle;
            iconButtonMotorAuto.IconFont = IconFont.Solid;
            iconButtonMotorAuto.IconColor = Color.SteelBlue;
        }

        public void ModeManual()
        {
            iconButtonMotorAuto.IconChar = IconChar.Circle;
            iconButtonMotorAuto.IconFont = IconFont.Regular;
            iconButtonMotorAuto.IconColor = Color.DimGray;
            iconButtonMotorManual.IconChar = IconChar.DotCircle;
            iconButtonMotorManual.IconFont = IconFont.Solid;
            iconButtonMotorManual.IconColor = Color.SteelBlue;
        }

        public void AngleMeasure()
        {
            labelPAMData.Text = Form_2.peelangleMeaForm_2;
        }

        public void AngleReset()
        {
            labelPAMData.Text = "0";
            //iconPictureBoxIEReady.IconChar = IconChar.Circle;
            //iconPictureBoxIEReady.IconColor = Color.Firebrick;
        }

        public void LoadCellM()
        {
            //labelLCMTime.Text = Form_1.time_LC;
            labelLCMD1.Text = Form_1.LC1;
            labelLCMD2.Text = Form_1.LC2;
        }

        public void PAM_ON()
        {
            iconPictureBoxPAM.IconColor = Color.ForestGreen;
        }

        public void PAM_OFF()
        {
            iconPictureBoxPAM.IconColor = Color.Firebrick;
        }

        public void LCM_ON()
        {
            iconPictureBoxLC1.IconColor = Color.ForestGreen;
            iconPictureBoxLC2.IconColor = Color.ForestGreen;
        }

        public void LCM_OFF()
        {
            iconPictureBoxLC1.IconColor = Color.Firebrick;
            iconPictureBoxLC2.IconColor = Color.Firebrick;
        }

        public void getReadyIE()
        {
            iconPictureBoxIEReady.IconChar = IconChar.CheckCircle;
            iconPictureBoxIEReady.IconColor = Color.ForestGreen;
            labelPA.Text = Form_2.peelangleSetForm_2;
        }

        public void getReadyLC()
        {
            //labelLCMTime.Text = "0";
            labelLCMD1.Text = "0";
            labelLCMD2.Text = "0";

            iconPictureBoxLCReady.IconChar = IconChar.CheckCircle;
            iconPictureBoxLCReady.IconColor = Color.ForestGreen;
        }

        public void getReadyDM()
        {
            iconPictureBoxDMReady.IconChar = IconChar.CheckCircle;
            iconPictureBoxDMReady.IconColor = Color.ForestGreen;
        }

        public void getReadyDU()
        {
            iconPictureBoxDUReady.IconChar = IconChar.CheckCircle;
            iconPictureBoxDUReady.IconColor = Color.ForestGreen;
        }

        public void notReadyDM()
        {
            iconPictureBoxDMReady.IconChar = IconChar.Circle;
            iconPictureBoxDMReady.IconColor = Color.Firebrick;
        }

        public void notReadyDU()
        {
            iconPictureBoxDUReady.IconChar = IconChar.Circle;
            iconPictureBoxDUReady.IconColor = Color.Firebrick;
        }

        private int counter;
        public void IELC_Plot()
        {
            //plot IE
            chartPeelAngle.Series[0].Points.AddXY(Form_2.DegreeChangeX[counter], Form_2.Angle);
            chartPeelAngle.Series[1].Points.AddXY(Form_2.DegreeChangeX[counter], Form_2.Angle_set);
            chartPeelAngle.ChartAreas[0].RecalculateAxesScale();

            //plot LC
            chartLoadCell.Series[0].Points.AddXY(Form_1.ForceChangeX[counter], Form_1.ForceChangeY1[counter]);
            chartLoadCell.Series[1].Points.AddXY(Form_1.ForceChangeX[counter], Form_1.ForceChangeY2[counter]);
            chartLoadCell.ChartAreas[0].RecalculateAxesScale();

            //calculation peel force
            C1 = Convert.ToDouble(Form_1.ForceChangeY2[counter]) * distance_sensor_drumaxis;
            peelforce = C1 / (R2 + hp / 2);

            string F = peelforce.ToString("0.000000");
            textBoxToSave.AppendText(Form_2.DegreeChangeX[counter] + "\t" + Form_2.Angle + "\t" + Form_1.ForceChangeY1[counter] + "\t" + Form_1.ForceChangeY2[counter] + "\t" + F + Environment.NewLine);

            //plot T
            double measured_T = Convert.ToDouble(object_temperature);
            double setpoin_T = Convert.ToDouble(Form_3.tapetemperature);
            chartTemperature.Series[0].Points.AddXY(Form_2.DegreeChangeX[counter], measured_T);
            chartTemperature.Series[1].Points.AddXY(Form_2.DegreeChangeX[counter], setpoin_T);
            chartTemperature.ChartAreas[0].RecalculateAxesScale();

            counter++;
        }

        public void DrumStart()
        {
            iconPictureBoxD1.IconColor = Color.ForestGreen;
            iconPictureBoxD2.IconColor = Color.ForestGreen;
        }

        public void DrumSpeed()
        {
            labelDrum1Speed.Text = drum1speed;
            labelDrum2Speed.Text = drum2speed;
        }

        public void DrumStop()
        {
            iconPictureBoxD1.IconColor = Color.Firebrick;
            iconPictureBoxD2.IconColor = Color.Firebrick;
            iconPictureBoxTime.IconColor = Color.Firebrick;
            iconPictureBoxPositon.IconColor = Color.Firebrick;
            labelDrum1Speed.Text = "0";
            labelDrum2Speed.Text = "0";
        }

        public void TestTime()
        {
            iconPictureBoxTime.IconColor = Color.ForestGreen;
            iconPictureBoxPositon.IconColor = Color.ForestGreen;
            labelTimeData.Text = testtime;
            labelPositionData.Text = tapeposition;
        }

        public void ResetDrum()
        {
            iconPictureBoxD1.IconColor = Color.Firebrick;
            iconPictureBoxD2.IconColor = Color.Firebrick;
            iconPictureBoxTime.IconColor = Color.Firebrick;
            iconPictureBoxPositon.IconColor = Color.Firebrick;
            labelDrum1Speed.Text = "0";
            labelDrum2Speed.Text = "0";
            labelTimeData.Text = "0";
            labelPositionData.Text = "0";
        }

        #endregion

        #region Act-Dis Buttons
        private void ActivateButton(object senderBtn, Color color)
        {     
            if(senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(54, 145, 222);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.ForeColor = Color.White;
                //left border button
                leftBorderBtn.BackColor = Color.FromArgb(214,226,240);
                leftBorderBtn.Location = new System.Drawing.Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconButtonCurrentForm.IconChar = currentBtn.IconChar;
                iconButtonCurrentForm.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255,255,255);
                currentBtn.ForeColor = Color.SteelBlue;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.SteelBlue;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Form Opening
        private Form childForm1, childForm2, childForm3, childForm4;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color1);
            if (childForm1 == null)
            {
                if (childForm2 == null)
                {
                    childForm2 = new Form_2();
                    childForm2.TopLevel = false;
                    childForm2.FormBorderStyle = FormBorderStyle.None;
                    childForm2.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(childForm2);
                    panelContainer.Tag = childForm2;
                    childForm2.Show();
                }

                childForm1 = new Form_1();
                childForm1.TopLevel = false;
                childForm1.FormBorderStyle = FormBorderStyle.None;
                childForm1.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(childForm1);
                panelContainer.Tag = childForm1;
                childForm1.BringToFront();
                childForm1.Show();
            }
            else
            {
                childForm1.Show();
                childForm1.BringToFront();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color1);
            if (childForm2 == null)
            {
                if (childForm1 == null)
                {
                    childForm1 = new Form_1();
                    childForm1.TopLevel = false;
                    childForm1.FormBorderStyle = FormBorderStyle.None;
                    childForm1.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(childForm1);
                    panelContainer.Tag = childForm1;
                    childForm1.Show();
                }

                childForm2 = new Form_2();
                childForm2.TopLevel = false;
                childForm2.FormBorderStyle = FormBorderStyle.None;
                childForm2.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(childForm2);
                panelContainer.Tag = childForm2;
                childForm2.BringToFront();
                childForm2.Show();
            }
            else
            {
                childForm2.Show();
                childForm2.BringToFront();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color1);
            if (childForm3 == null)
            {
                if (childForm4 == null)
                {
                    childForm4 = new Form_4();
                    childForm4.TopLevel = false;
                    childForm4.FormBorderStyle = FormBorderStyle.None;
                    childForm4.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(childForm4);
                    panelContainer.Tag = childForm4;
                    childForm4.Show();
                }

                childForm3 = new Form_3();
                childForm3.TopLevel = false;
                childForm3.FormBorderStyle = FormBorderStyle.None;
                childForm3.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(childForm3);
                panelContainer.Tag = childForm3;
                childForm3.BringToFront();
                childForm3.Show();
            }
            else
            {
                childForm3.Show();
                childForm3.BringToFront();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color1);
            if (childForm4 == null)
            {
                if (childForm3 == null)
                {
                    childForm3 = new Form_3();
                    childForm3.TopLevel = false;
                    childForm3.FormBorderStyle = FormBorderStyle.None;
                    childForm3.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(childForm3);
                    panelContainer.Tag = childForm3;
                    childForm3.Show();
                }

                childForm4 = new Form_4();
                childForm4.TopLevel = false;
                childForm4.FormBorderStyle = FormBorderStyle.None;
                childForm4.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(childForm4);
                panelContainer.Tag = childForm4;
                childForm4.BringToFront();
                childForm4.Show();
            }
            else
            {
                childForm4.Show();
                childForm4.BringToFront();
            }
        }

        #endregion

        #region Reset/Back to MainMenu/Close Current Form
        private void pictureBoxTUMLogo_Click(object sender, EventArgs e)
        {
            ResetMenu();
        }

        private void ResetMenu()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconButtonCurrentForm.IconChar = IconChar.Home;
            iconButtonCurrentForm.Text = "Main Menu"; 

            if (childForm1 != null)
            {
                childForm1.Visible = false;
            }
            if (childForm2 != null)
            {
                childForm2.Visible = false;
            }
            if (childForm3 != null)
            {
                childForm3.Visible = false;
            }
            if (childForm4 != null)
            {
                childForm4.Visible = false;
            }
        }

        private void iconButtonCloseWindow_Click(object sender, EventArgs e)
        {
            if(iconButtonCurrentForm.Text == "Main Menu")
            {
                MessageBox.Show("You are now on the Main Menu.");
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to Close this Form", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    if (currentBtn.Text == "Drum Control and Settings")
                    {
                        childForm3.Close();
                        childForm3 = null;
                        iconButtonMotorAuto.IconChar = IconChar.Circle;
                        iconButtonMotorAuto.IconFont = IconFont.Regular;
                        iconButtonMotorAuto.IconColor = Color.DimGray;
                        iconButtonMotorManual.IconChar = IconChar.Circle;
                        iconButtonMotorManual.IconFont = IconFont.Regular;
                        iconButtonMotorManual.IconColor = Color.DimGray;
                    }
                    if (currentBtn.Text == "Force Measurement")
                    {
                        childForm1.Close();
                        childForm1 = null;
                        iconPictureBoxLC1.IconColor = Color.Firebrick;
                        iconPictureBoxLC2.IconColor = Color.Firebrick;
                        labelLCMD1.Text = "0";
                        labelLCMD2.Text = "0";
                    }
                    if (currentBtn.Text == "Peel Angle Measurement")
                    {
                        childForm2.Close();
                        childForm2 = null;
                        iconPictureBoxPAM.IconColor = Color.Firebrick;
                        iconButtonUNO.IconColor = Color.Firebrick;
                        labelPAMData.Text = "0";
                    }
                    if (currentBtn.Text == "Delivery Unit Control")
                    {
                        childForm4.Close();
                        childForm4 = null;
                    }

                    ResetMenu();
                }
            } 
        }
        #endregion

        #region maxi mini Window / Drag Form
        private void iconButtonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButtonMaxi_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to quit this program", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Application.Exit();
                //System.Environment.Exit(0);
            }
            else{}
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region 画实时角度图 Draw Angle Movement

        private double x1, y1, x2, y2, x1_tangent, y1_tangent;
        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int r = 300 / 2, s = 600;
                int D1_x = 70 + r; int D1_y = 60 + r;
                int D2_x = D1_x + s; int D2_y = D1_y;

                Graphics g = e.Graphics;
                Pen p = new Pen(Color.Green, 2);
                Pen p1 = new Pen(Color.Red, 2);
                Pen p2 = new Pen(Color.Blue, 2);
                Pen p3 = new Pen(Color.Black, 1);
                Pen p4 = new Pen(Color.LightBlue, 3);
                Pen p5 = new Pen(Color.Goldenrod, 1);

                g.DrawEllipse(p1, 70, 60, 300, 300);    // 左上角punkt x=70, y=60;   r=300
                g.DrawEllipse(p2, 670, 60, 300, 300);   // 左上角punkt x=670, y=60;   r=300
                g.DrawLine(p3, D1_x - 1, D1_y, D1_x + 1, D1_y); // Mittelpunkt Drum1
                g.DrawLine(p3, D1_x, D1_y - 1, D1_x, D1_y + 1); // Mittelpunkt Drum1
                g.DrawLine(p3, D1_x, 60, D2_x, 60);  // p1=(220, 60);  p2=(220, 60);

                g.DrawLine(p, (float)x1, (float)y1, (float)x2, (float)y2);
                g.DrawLine(p5, D1_x, D1_y, (float)x1, (float)y1);
                g.DrawLine(p4, (float)x1, (float)y1, (float)x1_tangent, (float)y1_tangent);
                //g.Dispose();
            }
            catch { }
        }

        public void PointsCaculation()
        {
            int r = 300 / 2, s = 600;
            int D1_x = 70 + r; int D1_y = 60 + r;
            int D2_x = D1_x + s; int D2_y = D1_y;
            try
            {
                double a = r * Math.Sin(Convert.ToDouble(Form_2.peelangleMeaForm_2) * Math.PI / 180);
                double b = r * Math.Cos(Convert.ToDouble(Form_2.peelangleMeaForm_2) * Math.PI / 180);
                double c = r - b;
                double dd = Math.Pow(s, 2) - Math.Pow(c, 2);
                double zz = dd + Math.Pow(b, 2);
                //label1.Text = zz.ToString();

                // x2,y2 caculation:
                x2 = ((zz - Math.Pow(r, 2)) / s + D1_x + D2_x) / 2;
                y2 = D2_y - Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x2 - D2_x, 2));

                //labelx2.Text = x2.ToString();
                //labely2.Text = y2.ToString();

                // x1, y1 caculation:
                double d = Math.Sqrt(dd);
                double e = d - a;
                double ff = Math.Pow(e, 2) + Math.Pow(r, 2);
                
                x1 = ((Math.Pow(r, 2) - ff) / s + D1_x + D2_x) / 2;
                y1 = D1_y - Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x1 - D1_x, 2));

                //labelx1.Text = x1.ToString();
                //labely1.Text = y1.ToString();

                double k1_tangent = - (x1 - D1_x) / (y1 - D1_y);
                y1_tangent = y1 + 100;
                x1_tangent = (y1_tangent - y1) / k1_tangent + x1;

                /* Graph Drawing:
                Graphics g = this.myPanelDraw.CreateGraphics();
                Pen p = new Pen(Color.Green, 2);
                Pen p1 = new Pen(Color.Red, 2);
                Pen p2 = new Pen(Color.Blue, 2);
                Pen p3 = new Pen(Color.Black, 1);
                Pen p4 = new Pen(Color.LightBlue, 3);
                Pen p5 = new Pen(Color.Goldenrod, 1);

                g.Clear(this.myPanelDraw.BackColor);
                g.DrawEllipse(p1, 70, 60, 300, 300);    // 左上角punkt x=70, y=60;   r=300
                g.DrawEllipse(p2, 670, 60, 300, 300);   // 左上角punkt x=670, y=60;   r=300
                g.DrawLine(p3, D1_x, D1_y, D1_x, D1_y); // Mittelpunkt Drum1
                g.DrawLine(p3, D1_x, 60, D2_x, 60);  // p1=(220, 60);  p2=(220, 60);

                g.DrawLine(p, (float)x1, (float)y1, (float)x2, (float)y2);
                g.DrawLine(p5, D1_x, D1_y, (float)x1, (float)y1);
                g.DrawLine(p4, (float)x1, (float)y1, (float)x1_tangent, (float)y1_tangent);
                g.Dispose();*/

                myPanelDraw.Refresh();
            }
            catch { }
        }

        #endregion

        #region InitChart
        private void InitChart()
        {
            ////////// IE Plot
            chartPeelAngle.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartPeelAngle.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartPeelAngle.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartPeelAngle.ChartAreas[0].AxisX.Title = "Time [s]";
            chartPeelAngle.ChartAreas[0].AxisY.Title = "Angle [°]"; //name of the X-Y axis
            chartPeelAngle.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartPeelAngle.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartPeelAngle.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 8);
            chartPeelAngle.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 8);
            chartPeelAngle.ChartAreas[0].CursorX.AutoScroll = true;

            Series series = new Series()
            {
                Name = "Peel Angle",
                Color = System.Drawing.Color.Red,
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

            Title titleIE = new Title()
            {
                Font = new Font("Segoe UI", 10),
                Text = "Peel Angle Measurement"
            };

            chartPeelAngle.Titles.Add(titleIE);
            chartPeelAngle.Series.Add(series);
            chartPeelAngle.Series.Add(seriesSetAngle);

            /////////// LC Plot
            chartLoadCell.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartLoadCell.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartLoadCell.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartLoadCell.ChartAreas[0].AxisX.Title = "Time [s]";
            chartLoadCell.ChartAreas[0].AxisY.Title = "Force [N]"; //name of the X-Y axis
            chartLoadCell.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartLoadCell.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartLoadCell.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 8);
            chartLoadCell.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 8);
            chartLoadCell.ChartAreas[0].CursorX.AutoScroll = true;

            Series series1 = new Series()
            {
                Name = "Load Cell1",
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };
            chartLoadCell.Series.Add(series1);

            Series series2 = new Series()
            {
                Name = "Load Cell2",
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Title titleLC = new Title()
            {
                Font = new Font("Segoe UI", 10),
                Text = "Force Measurement"
            };

            chartLoadCell.Titles.Add(titleLC);
            chartLoadCell.Series.Add(series2);

            ///////// Temperature plot
            chartTemperature.ChartAreas[0].AxisX.IsStartedFromZero = false; // in case we get negative number
            chartTemperature.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; // no grids
            chartTemperature.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            chartTemperature.ChartAreas[0].AxisX.Title = "Time [s]";
            chartTemperature.ChartAreas[0].AxisY.Title = "Temperature [°C]"; //name of the X-Y axis
            chartTemperature.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chartTemperature.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            chartTemperature.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 8);
            chartTemperature.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 8);
            chartTemperature.ChartAreas[0].CursorX.AutoScroll = true;

            Series series3 = new Series()
            {
                Name = "Current Temperature",
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.FastLine,
                IsXValueIndexed = true
            };

            Series series4 = new Series()
            {
                Name = "Setpoint Temperature",
                Color = System.Drawing.Color.Orange,
                ChartType = SeriesChartType.FastLine,
                BorderWidth = 2,
                IsXValueIndexed = true
            };

            Title titleT = new Title()
            {
                Font = new Font("Segoe UI", 10),
                Text = "Object Temperature"
            };

            chartTemperature.Titles.Add(titleT);
            chartTemperature.Series.Add(series3);
            chartTemperature.Series.Add(series4);
        }

        private void labelAmbientTemData_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Temperature Controller 
        private void buttonTemSensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_3.PortOpen_MEGA == 1)
                {
                    if(buttonTemSensor.Text == "Connect")
                    {
                        Form_3.PortMega.WriteLine("W");
                        buttonTemSensor.Text = "Disconnect";
                        iconPictureBoxAmbientTemperature.IconColor = Color.ForestGreen;
                        iconPictureBoxObjectTemperature.IconColor = Color.ForestGreen;
                    }
                    else
                    {
                        Form_3.PortMega.WriteLine("w");
                        buttonTemSensor.Text = "Connect";
                        iconPictureBoxAmbientTemperature.IconColor = Color.Firebrick;
                        iconPictureBoxObjectTemperature.IconColor = Color.Firebrick;
                        labelAmbientTemData.Text = "0";
                        labelObjectTemData.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to MEGA-Board!");
                }
            }
            catch { }
        }

        private void buttonHeating_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_3.PortOpen_MEGA == 1)
                {
                    if(labelSetTData.Text == "NaN")
                    {
                        MessageBox.Show("Please set the temperature");
                    }
                    else
                    {
                        if (buttonTemSensor.Text == "Disconnect" && !cooling)
                        {
                            Form_3.PortMega.WriteLine("J");
                            heating = true;
                            cooling = false;
                            iconPictureBoxPeltier.IconColor = Color.ForestGreen;
                            iconButtonHeat.IconChar = IconChar.DotCircle;
                            iconButtonHeat.IconFont = IconFont.Solid;
                            iconButtonHeat.IconColor = Color.SteelBlue;
                            iconButtonCool.IconChar = IconChar.Circle;
                            iconButtonCool.IconFont = IconFont.Regular;
                            iconButtonCool.IconColor = Color.DimGray;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to MEGA-Board!");
                }
            }
            catch { }
        }

        private void buttonCooling_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_3.PortOpen_MEGA == 1)
                {
                    if (buttonTemSensor.Text == "Disconnect" && !heating)
                    {
                        Form_3.PortMega.WriteLine("j");
                        cooling = true;
                        heating = false;
                        water_cooler = true;
                        iconPictureBoxPeltier.IconColor = Color.ForestGreen;
                        iconButtonCool.IconChar = IconChar.DotCircle;
                        iconButtonCool.IconFont = IconFont.Solid;
                        iconButtonCool.IconColor = Color.SteelBlue;
                        iconButtonHeat.IconChar = IconChar.Circle;
                        iconButtonHeat.IconFont = IconFont.Regular;
                        iconButtonHeat.IconColor = Color.DimGray;
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Not connected to MEGA-Board!");
                }
            }
            catch { }
        }

        private void buttonPeltierClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_3.PortOpen_MEGA == 1)
                {
                    if (buttonTemSensor.Text == "Disconnect")
                    {
                        Form_3.PortMega.WriteLine("B");
                        cooling = false;
                        heating = false;
                        iconPictureBoxPeltier.IconColor = Color.Firebrick;
                        iconButtonHeat.IconChar = IconChar.Circle;
                        iconButtonHeat.IconFont = IconFont.Regular;
                        iconButtonHeat.IconColor = Color.DimGray;
                        iconButtonCool.IconChar = IconChar.Circle;
                        iconButtonCool.IconFont = IconFont.Regular;
                        iconButtonCool.IconColor = Color.DimGray;
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to MEGA-Board!");
                }
            }
            catch { }
        }

        private void buttonCoolerSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_3.PortOpen_MEGA == 1)
                {
                    if (!heating && !cooling)
                    {
                        Form_3.PortMega.WriteLine("b");
                    }
                }
                else
                {
                    MessageBox.Show("Not connected to MEGA-Board!");
                }
            }
            catch { }
        }

        #endregion

        #region Run and Stop Measurement
        private void iconButtonRunMeasure_Click(object sender, EventArgs e)
        {

            try
            {
                if (Form_2.readyIE && Form_1.readyLC && Form_3.DMautoready && parameter_settings)
                {
                    if (Form_2.PortOpen == 1)
                    {
                        this.iconButtonRunMeasure.Enabled = false;
                        this.iconButtonStopMeasure.Enabled = true;
                        Form_2.PortUno.WriteLine("B");
                    }

                    if(Form_3.PortOpen_MEGA == 1)
                    {
                        var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                        principalForm.StartTest();
                    }
                }
                else
                {
                    MessageBox.Show("Test is not ready.");
                }
            }
            catch { }
        }

        private void iconButtonStopMeasure_Click(object sender, EventArgs e)
        {         
            //Parallel.Invoke(MainStopMeasureLC, MainStopMeasurePA);
            try
            {
                if (Form_2.PortOpen == 1)
                {
                    this.iconButtonRunMeasure.Enabled = true;
                    this.iconButtonStopMeasure.Enabled = false;
                    Form_2.PortUno.WriteLine("b");

                    iconPictureBoxPAM.IconColor = Color.Firebrick;
                    iconPictureBoxLC1.IconColor = Color.Firebrick;
                    iconPictureBoxLC2.IconColor = Color.Firebrick;
                }

                if(Form_3.PortOpen_MEGA == 1)
                {
                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                    principalForm.StopTest();
                }
            }
            catch { }
        }

        private void iconButtonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_2.PortOpen == 1)
                {
                    var principalIELC_Reset = System.Windows.Forms.Application.OpenForms.OfType<Form_2>().FirstOrDefault();
                    principalIELC_Reset.QuickReset();
                }

                if (Form_3.PortOpen_MEGA == 1)
                {
                    var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form_3>().FirstOrDefault();
                    principalForm.QuickReset();
                }

                foreach (var series in chartPeelAngle.Series)
                {
                    series.Points.Clear();
                }
                foreach (var series in chartLoadCell.Series)
                {
                    series.Points.Clear();
                }
                foreach (var series in chartTemperature.Series)
                {
                    series.Points.Clear();
                }
                counter = 0;
            }
            catch { }
        }

        #endregion

        #region Save File
        private void iconButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\Desktop";
            saveFile.Title = "Save your Test Data";
            saveFile.DefaultExt = "srt";
            saveFile.Filter = "csv file (*.csv)|*.csv|text file (*.txt)|*.txt|subtitle file (*.srt)|*.srt|All Files (*.*)|*.*";
            saveFile.RestoreDirectory = true;

            saveFile.FileName = DateTime.Now.ToString("yyyy-MM-dd") + " DoubleDrum_Tack_Test";

            string readyToSave1 = "Double Drum Tack Test" + "\r\n"
                + DateTime.Now.ToString("G") + "\r\n"
                + "Thickness [mm]\t" + labelTT.Text + "\r\n"
                + "Peel Angle [°]\t" + labelPA.Text + "\r\n"
                + "Peel Speed [mm/min]\t" + labelPS.Text + "\r\n"
                + "Peel Length [mm]\t" + labelPL.Text + "\r\n"
                + "Tape Width [mm]\t" + labelTW.Text + "\r\n"
                + "Tape Temperature [°C]\t" + labelSetTData.Text + "\r\n";

            string readyToSave2 = "Time [s]\tPeel Angle [°]\tForce1 [N]\tForce2 [N]\tPeel Force [N]" + "\r\n" + textBoxToSave.Text;
            string save_txt = readyToSave1 + "\r\n" + readyToSave2;
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

        private void buttonClearCMD_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to clear the data? Please save if needed!", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                textBoxToSave.Clear();
            }
            else { }
        }

        #endregion


    }
}
