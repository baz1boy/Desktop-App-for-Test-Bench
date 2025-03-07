namespace L298N_Control
{
    partial class Form_4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxCOM = new System.Windows.Forms.GroupBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.iconPictureBoxOn = new FontAwesome.Sharp.IconPictureBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.labelPortName = new System.Windows.Forms.Label();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.labelDU = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonRunDelivery = new System.Windows.Forms.Button();
            this.textBoxDeliverySpeedManual = new System.Windows.Forms.TextBox();
            this.buttonSetDUSpeedManual = new System.Windows.Forms.Button();
            this.buttonStopDelivery = new System.Windows.Forms.Button();
            this.labelDUPosition = new System.Windows.Forms.Label();
            this.labelPositionData = new System.Windows.Forms.Label();
            this.buttonRSP = new System.Windows.Forms.Button();
            this.labeldir = new System.Windows.Forms.Label();
            this.groupBoxAuto = new System.Windows.Forms.GroupBox();
            this.buttonSetDUSpeedAuto = new System.Windows.Forms.Button();
            this.textBoxDeliverySpeedAuto = new System.Windows.Forms.TextBox();
            this.labelCurrentSpeedDataAuto = new System.Windows.Forms.Label();
            this.labelCurrentSpeedAuto = new System.Windows.Forms.Label();
            this.labelLTSpeedAutoData = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelTimerData = new System.Windows.Forms.Label();
            this.labelLTpeedAuto = new System.Windows.Forms.Label();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.labelLTSpeedManualData = new System.Windows.Forms.Label();
            this.labelLTSpeedManual = new System.Windows.Forms.Label();
            this.labelAdjustmentD1 = new System.Windows.Forms.Label();
            this.labelCurrentSpeedDataManual = new System.Windows.Forms.Label();
            this.labelCurrentSpeedManual = new System.Windows.Forms.Label();
            this.label800Manual = new System.Windows.Forms.Label();
            this.labelDefaultSpeedManual = new System.Windows.Forms.Label();
            this.radioButtonBack = new System.Windows.Forms.RadioButton();
            this.radioButtonForward = new System.Windows.Forms.RadioButton();
            this.iconButtonForward = new FontAwesome.Sharp.IconButton();
            this.buttonManualStop = new System.Windows.Forms.Button();
            this.iconButtonBack = new FontAwesome.Sharp.IconButton();
            this.buttonManualRun = new System.Windows.Forms.Button();
            this.labeldirset = new System.Windows.Forms.Label();
            this.timerDU = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCMD = new System.Windows.Forms.TextBox();
            this.iconPictureBoxReady = new FontAwesome.Sharp.IconPictureBox();
            this.buttonClearCMD = new System.Windows.Forms.Button();
            this.groupBoxCOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).BeginInit();
            this.groupBoxAuto.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCOM
            // 
            this.groupBoxCOM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxCOM.Controls.Add(this.labelBaudRate);
            this.groupBoxCOM.Controls.Add(this.iconPictureBoxOn);
            this.groupBoxCOM.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxCOM.Controls.Add(this.buttonOpenPort);
            this.groupBoxCOM.Controls.Add(this.labelPortName);
            this.groupBoxCOM.Controls.Add(this.comboBoxPortName);
            this.groupBoxCOM.Location = new System.Drawing.Point(22, 22);
            this.groupBoxCOM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCOM.Name = "groupBoxCOM";
            this.groupBoxCOM.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxCOM.Size = new System.Drawing.Size(280, 169);
            this.groupBoxCOM.TabIndex = 87;
            this.groupBoxCOM.TabStop = false;
            this.groupBoxCOM.Text = "COM Port";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(19, 77);
            this.labelBaudRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(96, 25);
            this.labelBaudRate.TabIndex = 89;
            this.labelBaudRate.Text = "Baud Rate:";
            // 
            // iconPictureBoxOn
            // 
            this.iconPictureBoxOn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBoxOn.ForeColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxOn.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            this.iconPictureBoxOn.IconColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxOn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxOn.IconSize = 46;
            this.iconPictureBoxOn.Location = new System.Drawing.Point(24, 118);
            this.iconPictureBoxOn.Name = "iconPictureBoxOn";
            this.iconPictureBoxOn.Size = new System.Drawing.Size(95, 46);
            this.iconPictureBoxOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBoxOn.TabIndex = 115;
            this.iconPictureBoxOn.TabStop = false;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(132, 75);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBaudRate.TabIndex = 90;
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenPort.Location = new System.Drawing.Point(132, 119);
            this.buttonOpenPort.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(121, 37);
            this.buttonOpenPort.TabIndex = 91;
            this.buttonOpenPort.Text = "Open Port";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Location = new System.Drawing.Point(19, 39);
            this.labelPortName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(100, 25);
            this.labelPortName.TabIndex = 87;
            this.labelPortName.Text = "Port Name:";
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(132, 34);
            this.comboBoxPortName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(121, 33);
            this.comboBoxPortName.TabIndex = 88;
            this.comboBoxPortName.SelectedValueChanged += new System.EventHandler(this.comboBoxPortName_SelectedValueChanged);
            // 
            // labelDU
            // 
            this.labelDU.AutoSize = true;
            this.labelDU.Location = new System.Drawing.Point(50, 473);
            this.labelDU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDU.Name = "labelDU";
            this.labelDU.Size = new System.Drawing.Size(80, 25);
            this.labelDU.TabIndex = 101;
            this.labelDU.Text = "Delivery ";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConnect.Location = new System.Drawing.Point(181, 467);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(121, 37);
            this.buttonConnect.TabIndex = 102;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonRunDelivery
            // 
            this.buttonRunDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRunDelivery.Location = new System.Drawing.Point(379, 187);
            this.buttonRunDelivery.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRunDelivery.Name = "buttonRunDelivery";
            this.buttonRunDelivery.Size = new System.Drawing.Size(106, 35);
            this.buttonRunDelivery.TabIndex = 88;
            this.buttonRunDelivery.Text = "Run";
            this.buttonRunDelivery.UseVisualStyleBackColor = true;
            this.buttonRunDelivery.Click += new System.EventHandler(this.buttonRunDelivery_Click);
            // 
            // textBoxDeliverySpeedManual
            // 
            this.textBoxDeliverySpeedManual.Location = new System.Drawing.Point(379, 36);
            this.textBoxDeliverySpeedManual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxDeliverySpeedManual.Name = "textBoxDeliverySpeedManual";
            this.textBoxDeliverySpeedManual.Size = new System.Drawing.Size(105, 31);
            this.textBoxDeliverySpeedManual.TabIndex = 89;
            // 
            // buttonSetDUSpeedManual
            // 
            this.buttonSetDUSpeedManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetDUSpeedManual.Location = new System.Drawing.Point(490, 34);
            this.buttonSetDUSpeedManual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSetDUSpeedManual.Name = "buttonSetDUSpeedManual";
            this.buttonSetDUSpeedManual.Size = new System.Drawing.Size(117, 35);
            this.buttonSetDUSpeedManual.TabIndex = 90;
            this.buttonSetDUSpeedManual.Text = "Set Speed";
            this.buttonSetDUSpeedManual.UseVisualStyleBackColor = true;
            this.buttonSetDUSpeedManual.Click += new System.EventHandler(this.buttonSetDUSpeedManual_Click);
            // 
            // buttonStopDelivery
            // 
            this.buttonStopDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStopDelivery.Location = new System.Drawing.Point(501, 187);
            this.buttonStopDelivery.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonStopDelivery.Name = "buttonStopDelivery";
            this.buttonStopDelivery.Size = new System.Drawing.Size(106, 35);
            this.buttonStopDelivery.TabIndex = 105;
            this.buttonStopDelivery.Text = "Stop";
            this.buttonStopDelivery.UseVisualStyleBackColor = true;
            this.buttonStopDelivery.Click += new System.EventHandler(this.buttonStopDelivery_Click);
            // 
            // labelDUPosition
            // 
            this.labelDUPosition.AutoSize = true;
            this.labelDUPosition.Location = new System.Drawing.Point(25, 156);
            this.labelDUPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDUPosition.Name = "labelDUPosition";
            this.labelDUPosition.Size = new System.Drawing.Size(142, 25);
            this.labelDUPosition.TabIndex = 106;
            this.labelDUPosition.Text = "Current Position:";
            // 
            // labelPositionData
            // 
            this.labelPositionData.AutoSize = true;
            this.labelPositionData.Location = new System.Drawing.Point(261, 156);
            this.labelPositionData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPositionData.Name = "labelPositionData";
            this.labelPositionData.Size = new System.Drawing.Size(22, 25);
            this.labelPositionData.TabIndex = 107;
            this.labelPositionData.Text = "0";
            // 
            // buttonRSP
            // 
            this.buttonRSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRSP.Location = new System.Drawing.Point(24, 187);
            this.buttonRSP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRSP.Name = "buttonRSP";
            this.buttonRSP.Size = new System.Drawing.Size(143, 35);
            this.buttonRSP.TabIndex = 108;
            this.buttonRSP.Text = "Reset Position";
            this.buttonRSP.UseVisualStyleBackColor = true;
            this.buttonRSP.Click += new System.EventHandler(this.buttonRSP_Click);
            // 
            // labeldir
            // 
            this.labeldir.AutoSize = true;
            this.labeldir.Location = new System.Drawing.Point(202, 156);
            this.labeldir.Name = "labeldir";
            this.labeldir.Size = new System.Drawing.Size(41, 25);
            this.labeldir.TabIndex = 110;
            this.labeldir.Text = "DIR";
            // 
            // groupBoxAuto
            // 
            this.groupBoxAuto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxAuto.Controls.Add(this.buttonSetDUSpeedAuto);
            this.groupBoxAuto.Controls.Add(this.textBoxDeliverySpeedAuto);
            this.groupBoxAuto.Controls.Add(this.labelCurrentSpeedDataAuto);
            this.groupBoxAuto.Controls.Add(this.labelCurrentSpeedAuto);
            this.groupBoxAuto.Controls.Add(this.labelLTSpeedAutoData);
            this.groupBoxAuto.Controls.Add(this.labelTimer);
            this.groupBoxAuto.Controls.Add(this.labelTimerData);
            this.groupBoxAuto.Controls.Add(this.labelLTpeedAuto);
            this.groupBoxAuto.Controls.Add(this.buttonRunDelivery);
            this.groupBoxAuto.Controls.Add(this.labeldir);
            this.groupBoxAuto.Controls.Add(this.buttonStopDelivery);
            this.groupBoxAuto.Controls.Add(this.labelDUPosition);
            this.groupBoxAuto.Controls.Add(this.buttonRSP);
            this.groupBoxAuto.Controls.Add(this.labelPositionData);
            this.groupBoxAuto.Location = new System.Drawing.Point(319, 22);
            this.groupBoxAuto.Name = "groupBoxAuto";
            this.groupBoxAuto.Size = new System.Drawing.Size(633, 235);
            this.groupBoxAuto.TabIndex = 113;
            this.groupBoxAuto.TabStop = false;
            this.groupBoxAuto.Text = "Auto Mode";
            // 
            // buttonSetDUSpeedAuto
            // 
            this.buttonSetDUSpeedAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetDUSpeedAuto.Location = new System.Drawing.Point(490, 34);
            this.buttonSetDUSpeedAuto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSetDUSpeedAuto.Name = "buttonSetDUSpeedAuto";
            this.buttonSetDUSpeedAuto.Size = new System.Drawing.Size(117, 35);
            this.buttonSetDUSpeedAuto.TabIndex = 149;
            this.buttonSetDUSpeedAuto.Text = "Set Speed";
            this.buttonSetDUSpeedAuto.UseVisualStyleBackColor = true;
            this.buttonSetDUSpeedAuto.Click += new System.EventHandler(this.buttonSetDUSpeedAuto_Click);
            // 
            // textBoxDeliverySpeedAuto
            // 
            this.textBoxDeliverySpeedAuto.Location = new System.Drawing.Point(379, 36);
            this.textBoxDeliverySpeedAuto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxDeliverySpeedAuto.Name = "textBoxDeliverySpeedAuto";
            this.textBoxDeliverySpeedAuto.Size = new System.Drawing.Size(105, 31);
            this.textBoxDeliverySpeedAuto.TabIndex = 129;
            // 
            // labelCurrentSpeedDataAuto
            // 
            this.labelCurrentSpeedDataAuto.AutoSize = true;
            this.labelCurrentSpeedDataAuto.Location = new System.Drawing.Point(261, 39);
            this.labelCurrentSpeedDataAuto.Name = "labelCurrentSpeedDataAuto";
            this.labelCurrentSpeedDataAuto.Size = new System.Drawing.Size(42, 25);
            this.labelCurrentSpeedDataAuto.TabIndex = 147;
            this.labelCurrentSpeedDataAuto.Text = "800";
            // 
            // labelCurrentSpeedAuto
            // 
            this.labelCurrentSpeedAuto.AutoSize = true;
            this.labelCurrentSpeedAuto.Location = new System.Drawing.Point(25, 39);
            this.labelCurrentSpeedAuto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentSpeedAuto.Name = "labelCurrentSpeedAuto";
            this.labelCurrentSpeedAuto.Size = new System.Drawing.Size(218, 25);
            this.labelCurrentSpeedAuto.TabIndex = 148;
            this.labelCurrentSpeedAuto.Text = "Current Speed [steps/sec]:";
            // 
            // labelLTSpeedAutoData
            // 
            this.labelLTSpeedAutoData.AutoSize = true;
            this.labelLTSpeedAutoData.Location = new System.Drawing.Point(261, 78);
            this.labelLTSpeedAutoData.Name = "labelLTSpeedAutoData";
            this.labelLTSpeedAutoData.Size = new System.Drawing.Size(22, 25);
            this.labelLTSpeedAutoData.TabIndex = 146;
            this.labelLTSpeedAutoData.Text = "4";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(25, 117);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(60, 25);
            this.labelTimer.TabIndex = 144;
            this.labelTimer.Text = "Timer:";
            // 
            // labelTimerData
            // 
            this.labelTimerData.AutoSize = true;
            this.labelTimerData.Location = new System.Drawing.Point(261, 117);
            this.labelTimerData.Name = "labelTimerData";
            this.labelTimerData.Size = new System.Drawing.Size(104, 25);
            this.labelTimerData.TabIndex = 143;
            this.labelTimerData.Text = "00:00:00:00";
            // 
            // labelLTpeedAuto
            // 
            this.labelLTpeedAuto.AutoSize = true;
            this.labelLTpeedAuto.Location = new System.Drawing.Point(25, 78);
            this.labelLTpeedAuto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLTpeedAuto.Name = "labelLTpeedAuto";
            this.labelLTpeedAuto.Size = new System.Drawing.Size(228, 25);
            this.labelLTpeedAuto.TabIndex = 145;
            this.labelLTpeedAuto.Text = "Linear Travel Speed [mm/s]:";
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxManual.Controls.Add(this.labelLTSpeedManualData);
            this.groupBoxManual.Controls.Add(this.labelLTSpeedManual);
            this.groupBoxManual.Controls.Add(this.labelAdjustmentD1);
            this.groupBoxManual.Controls.Add(this.labelCurrentSpeedDataManual);
            this.groupBoxManual.Controls.Add(this.labelCurrentSpeedManual);
            this.groupBoxManual.Controls.Add(this.label800Manual);
            this.groupBoxManual.Controls.Add(this.labelDefaultSpeedManual);
            this.groupBoxManual.Controls.Add(this.radioButtonBack);
            this.groupBoxManual.Controls.Add(this.buttonSetDUSpeedManual);
            this.groupBoxManual.Controls.Add(this.radioButtonForward);
            this.groupBoxManual.Controls.Add(this.iconButtonForward);
            this.groupBoxManual.Controls.Add(this.buttonManualStop);
            this.groupBoxManual.Controls.Add(this.iconButtonBack);
            this.groupBoxManual.Controls.Add(this.buttonManualRun);
            this.groupBoxManual.Controls.Add(this.labeldirset);
            this.groupBoxManual.Controls.Add(this.textBoxDeliverySpeedManual);
            this.groupBoxManual.Location = new System.Drawing.Point(319, 269);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(633, 235);
            this.groupBoxManual.TabIndex = 114;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "Manual Test";
            // 
            // labelLTSpeedManualData
            // 
            this.labelLTSpeedManualData.AutoSize = true;
            this.labelLTSpeedManualData.Location = new System.Drawing.Point(261, 78);
            this.labelLTSpeedManualData.Name = "labelLTSpeedManualData";
            this.labelLTSpeedManualData.Size = new System.Drawing.Size(22, 25);
            this.labelLTSpeedManualData.TabIndex = 130;
            this.labelLTSpeedManualData.Text = "4";
            // 
            // labelLTSpeedManual
            // 
            this.labelLTSpeedManual.AutoSize = true;
            this.labelLTSpeedManual.Location = new System.Drawing.Point(25, 78);
            this.labelLTSpeedManual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLTSpeedManual.Name = "labelLTSpeedManual";
            this.labelLTSpeedManual.Size = new System.Drawing.Size(228, 25);
            this.labelLTSpeedManual.TabIndex = 129;
            this.labelLTSpeedManual.Text = "Linear Travel Speed [mm/s]:";
            // 
            // labelAdjustmentD1
            // 
            this.labelAdjustmentD1.AutoSize = true;
            this.labelAdjustmentD1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdjustmentD1.Location = new System.Drawing.Point(25, 158);
            this.labelAdjustmentD1.Name = "labelAdjustmentD1";
            this.labelAdjustmentD1.Size = new System.Drawing.Size(164, 23);
            this.labelAdjustmentD1.TabIndex = 128;
            this.labelAdjustmentD1.Text = "Adjustment Control:";
            // 
            // labelCurrentSpeedDataManual
            // 
            this.labelCurrentSpeedDataManual.AutoSize = true;
            this.labelCurrentSpeedDataManual.Location = new System.Drawing.Point(261, 39);
            this.labelCurrentSpeedDataManual.Name = "labelCurrentSpeedDataManual";
            this.labelCurrentSpeedDataManual.Size = new System.Drawing.Size(42, 25);
            this.labelCurrentSpeedDataManual.TabIndex = 118;
            this.labelCurrentSpeedDataManual.Text = "800";
            // 
            // labelCurrentSpeedManual
            // 
            this.labelCurrentSpeedManual.AutoSize = true;
            this.labelCurrentSpeedManual.Location = new System.Drawing.Point(25, 39);
            this.labelCurrentSpeedManual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentSpeedManual.Name = "labelCurrentSpeedManual";
            this.labelCurrentSpeedManual.Size = new System.Drawing.Size(218, 25);
            this.labelCurrentSpeedManual.TabIndex = 119;
            this.labelCurrentSpeedManual.Text = "Current Speed [steps/sec]:";
            // 
            // label800Manual
            // 
            this.label800Manual.AutoSize = true;
            this.label800Manual.Location = new System.Drawing.Point(261, 117);
            this.label800Manual.Name = "label800Manual";
            this.label800Manual.Size = new System.Drawing.Size(42, 25);
            this.label800Manual.TabIndex = 117;
            this.label800Manual.Text = "800";
            // 
            // labelDefaultSpeedManual
            // 
            this.labelDefaultSpeedManual.AutoSize = true;
            this.labelDefaultSpeedManual.Location = new System.Drawing.Point(25, 117);
            this.labelDefaultSpeedManual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDefaultSpeedManual.Name = "labelDefaultSpeedManual";
            this.labelDefaultSpeedManual.Size = new System.Drawing.Size(217, 25);
            this.labelDefaultSpeedManual.TabIndex = 116;
            this.labelDefaultSpeedManual.Text = "Default Speed [steps/sec]:";
            // 
            // radioButtonBack
            // 
            this.radioButtonBack.AutoSize = true;
            this.radioButtonBack.Location = new System.Drawing.Point(490, 113);
            this.radioButtonBack.Name = "radioButtonBack";
            this.radioButtonBack.Size = new System.Drawing.Size(109, 29);
            this.radioButtonBack.TabIndex = 115;
            this.radioButtonBack.TabStop = true;
            this.radioButtonBack.Text = "backward";
            this.radioButtonBack.UseVisualStyleBackColor = true;
            // 
            // radioButtonForward
            // 
            this.radioButtonForward.AutoSize = true;
            this.radioButtonForward.Location = new System.Drawing.Point(490, 78);
            this.radioButtonForward.Name = "radioButtonForward";
            this.radioButtonForward.Size = new System.Drawing.Size(95, 29);
            this.radioButtonForward.TabIndex = 114;
            this.radioButtonForward.TabStop = true;
            this.radioButtonForward.Text = "forward";
            this.radioButtonForward.UseVisualStyleBackColor = true;
            // 
            // iconButtonForward
            // 
            this.iconButtonForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonForward.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButtonForward.IconColor = System.Drawing.Color.DimGray;
            this.iconButtonForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonForward.IconSize = 30;
            this.iconButtonForward.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButtonForward.Location = new System.Drawing.Point(147, 187);
            this.iconButtonForward.Name = "iconButtonForward";
            this.iconButtonForward.Size = new System.Drawing.Size(105, 35);
            this.iconButtonForward.TabIndex = 112;
            this.iconButtonForward.UseVisualStyleBackColor = true;
            this.iconButtonForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iconButtonForward_MouseDown);
            this.iconButtonForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.iconButtonForward_MouseUp);
            // 
            // buttonManualStop
            // 
            this.buttonManualStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManualStop.Location = new System.Drawing.Point(501, 187);
            this.buttonManualStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonManualStop.Name = "buttonManualStop";
            this.buttonManualStop.Size = new System.Drawing.Size(106, 35);
            this.buttonManualStop.TabIndex = 107;
            this.buttonManualStop.Text = "Stop";
            this.buttonManualStop.UseVisualStyleBackColor = true;
            this.buttonManualStop.Click += new System.EventHandler(this.buttonManualStop_Click);
            // 
            // iconButtonBack
            // 
            this.iconButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonBack.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconButtonBack.IconColor = System.Drawing.Color.DimGray;
            this.iconButtonBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonBack.IconSize = 30;
            this.iconButtonBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButtonBack.Location = new System.Drawing.Point(25, 187);
            this.iconButtonBack.Name = "iconButtonBack";
            this.iconButtonBack.Size = new System.Drawing.Size(105, 35);
            this.iconButtonBack.TabIndex = 111;
            this.iconButtonBack.UseVisualStyleBackColor = true;
            this.iconButtonBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iconButtonBack_MouseDown);
            this.iconButtonBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.iconButtonBack_MouseUp);
            // 
            // buttonManualRun
            // 
            this.buttonManualRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonManualRun.Location = new System.Drawing.Point(379, 187);
            this.buttonManualRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonManualRun.Name = "buttonManualRun";
            this.buttonManualRun.Size = new System.Drawing.Size(105, 35);
            this.buttonManualRun.TabIndex = 106;
            this.buttonManualRun.Text = "Run";
            this.buttonManualRun.UseVisualStyleBackColor = true;
            this.buttonManualRun.Click += new System.EventHandler(this.buttonManualRun_Click);
            // 
            // labeldirset
            // 
            this.labeldirset.AutoSize = true;
            this.labeldirset.Location = new System.Drawing.Point(374, 78);
            this.labeldirset.Name = "labeldirset";
            this.labeldirset.Size = new System.Drawing.Size(87, 25);
            this.labeldirset.TabIndex = 113;
            this.labeldirset.Text = "Direction:";
            // 
            // timerDU
            // 
            this.timerDU.Interval = 1;
            this.timerDU.Tick += new System.EventHandler(this.timerDU_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 141;
            this.label2.Text = "User Command";
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCMD.Location = new System.Drawing.Point(22, 239);
            this.textBoxCMD.Multiline = true;
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCMD.Size = new System.Drawing.Size(280, 217);
            this.textBoxCMD.TabIndex = 140;
            // 
            // iconPictureBoxReady
            // 
            this.iconPictureBoxReady.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBoxReady.ForeColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxReady.IconChar = FontAwesome.Sharp.IconChar.CircleNotch;
            this.iconPictureBoxReady.IconColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxReady.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxReady.IconSize = 30;
            this.iconPictureBoxReady.Location = new System.Drawing.Point(22, 474);
            this.iconPictureBoxReady.Name = "iconPictureBoxReady";
            this.iconPictureBoxReady.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBoxReady.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBoxReady.TabIndex = 142;
            this.iconPictureBoxReady.TabStop = false;
            // 
            // buttonClearCMD
            // 
            this.buttonClearCMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearCMD.Location = new System.Drawing.Point(202, 202);
            this.buttonClearCMD.Name = "buttonClearCMD";
            this.buttonClearCMD.Size = new System.Drawing.Size(100, 32);
            this.buttonClearCMD.TabIndex = 116;
            this.buttonClearCMD.Text = "Clear";
            this.buttonClearCMD.UseVisualStyleBackColor = true;
            this.buttonClearCMD.Click += new System.EventHandler(this.buttonClearCMD_Click);
            // 
            // Form_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1564, 1040);
            this.Controls.Add(this.buttonClearCMD);
            this.Controls.Add(this.iconPictureBoxReady);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCMD);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.groupBoxAuto);
            this.Controls.Add(this.groupBoxCOM);
            this.Controls.Add(this.labelDU);
            this.Controls.Add(this.buttonConnect);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_4_FormClosed);
            this.groupBoxCOM.ResumeLayout(false);
            this.groupBoxCOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).EndInit();
            this.groupBoxAuto.ResumeLayout(false);
            this.groupBoxAuto.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCOM;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonRunDelivery;
        private System.Windows.Forms.TextBox textBoxDeliverySpeedManual;
        private System.Windows.Forms.Button buttonSetDUSpeedManual;
        private System.Windows.Forms.Label labelDU;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStopDelivery;
        private System.Windows.Forms.Label labelDUPosition;
        private System.Windows.Forms.Label labelPositionData;
        private System.Windows.Forms.Button buttonRSP;
        private System.Windows.Forms.Label labeldir;
        private System.Windows.Forms.GroupBox groupBoxAuto;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.Timer timerDU;
        private FontAwesome.Sharp.IconButton iconButtonForward;
        private FontAwesome.Sharp.IconButton iconButtonBack;
        private System.Windows.Forms.Button buttonManualRun;
        private System.Windows.Forms.Button buttonManualStop;
        private System.Windows.Forms.RadioButton radioButtonBack;
        private System.Windows.Forms.RadioButton radioButtonForward;
        private System.Windows.Forms.Label labeldirset;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCMD;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxReady;
        private System.Windows.Forms.Button buttonClearCMD;
        private System.Windows.Forms.Label labelTimerData;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelLTSpeedAutoData;
        private System.Windows.Forms.Label labelLTpeedAuto;
        private System.Windows.Forms.Label label800Manual;
        private System.Windows.Forms.Label labelDefaultSpeedManual;
        private System.Windows.Forms.Label labelCurrentSpeedDataAuto;
        private System.Windows.Forms.Label labelCurrentSpeedAuto;
        private System.Windows.Forms.Label labelCurrentSpeedDataManual;
        private System.Windows.Forms.Label labelCurrentSpeedManual;
        private System.Windows.Forms.Label labelAdjustmentD1;
        private System.Windows.Forms.Button buttonSetDUSpeedAuto;
        private System.Windows.Forms.TextBox textBoxDeliverySpeedAuto;
        private System.Windows.Forms.Label labelLTSpeedManualData;
        private System.Windows.Forms.Label labelLTSpeedManual;
    }
}