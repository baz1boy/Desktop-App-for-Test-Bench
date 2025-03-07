namespace L298N_Control
{
    partial class Form_2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelPortName = new System.Windows.Forms.Label();
            this.textBoxCMD = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonClearCMD = new System.Windows.Forms.Button();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.chartAngleChange = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPeelAngle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelAngleChange = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.iconPictureBoxOn = new FontAwesome.Sharp.IconPictureBox();
            this.textBoxMeasuredData = new System.Windows.Forms.TextBox();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.buttonSetAngle = new System.Windows.Forms.Button();
            this.textBoxDegreeSet = new System.Windows.Forms.TextBox();
            this.buttonStopMeasure = new System.Windows.Forms.Button();
            this.buttonStartMeasure = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDegree = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelMeasuredData = new System.Windows.Forms.Label();
            this.iconPictureBoxReady = new FontAwesome.Sharp.IconPictureBox();
            this.labelReady = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartAngleChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeelAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).BeginInit();
            this.SuspendLayout();
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
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBaudRate.TabIndex = 77;
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(132, 34);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(121, 33);
            this.comboBoxPortName.TabIndex = 76;
            this.comboBoxPortName.SelectedValueChanged += new System.EventHandler(this.comboBoxPortName_SelectedValueChanged);
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(19, 77);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(96, 25);
            this.labelBaudRate.TabIndex = 75;
            this.labelBaudRate.Text = "Baud Rate:";
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Location = new System.Drawing.Point(19, 39);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(100, 25);
            this.labelPortName.TabIndex = 74;
            this.labelPortName.Text = "Port Name:";
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.Location = new System.Drawing.Point(22, 263);
            this.textBoxCMD.Multiline = true;
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCMD.Size = new System.Drawing.Size(403, 247);
            this.textBoxCMD.TabIndex = 73;
            // 
            // buttonClearCMD
            // 
            this.buttonClearCMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearCMD.Location = new System.Drawing.Point(202, 224);
            this.buttonClearCMD.Name = "buttonClearCMD";
            this.buttonClearCMD.Size = new System.Drawing.Size(100, 32);
            this.buttonClearCMD.TabIndex = 79;
            this.buttonClearCMD.Text = "Clear";
            this.buttonClearCMD.UseVisualStyleBackColor = true;
            this.buttonClearCMD.Click += new System.EventHandler(this.buttonClearData_Click);
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenPort.Location = new System.Drawing.Point(132, 119);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(121, 37);
            this.buttonOpenPort.TabIndex = 78;
            this.buttonOpenPort.Text = "Open Port";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // chartAngleChange
            // 
            chartArea3.Name = "ChartArea1";
            this.chartAngleChange.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartAngleChange.Legends.Add(legend3);
            this.chartAngleChange.Location = new System.Drawing.Point(732, 30);
            this.chartAngleChange.Name = "chartAngleChange";
            this.chartAngleChange.Size = new System.Drawing.Size(830, 480);
            this.chartAngleChange.TabIndex = 81;
            this.chartAngleChange.Text = "chart1";
            // 
            // chartPeelAngle
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPeelAngle.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartPeelAngle.Legends.Add(legend4);
            this.chartPeelAngle.Location = new System.Drawing.Point(732, 531);
            this.chartPeelAngle.Name = "chartPeelAngle";
            this.chartPeelAngle.Size = new System.Drawing.Size(830, 480);
            this.chartPeelAngle.TabIndex = 82;
            this.chartPeelAngle.Text = "chart2";
            // 
            // labelAngleChange
            // 
            this.labelAngleChange.AutoSize = true;
            this.labelAngleChange.BackColor = System.Drawing.Color.White;
            this.labelAngleChange.Location = new System.Drawing.Point(1419, 126);
            this.labelAngleChange.Name = "labelAngleChange";
            this.labelAngleChange.Size = new System.Drawing.Size(22, 25);
            this.labelAngleChange.TabIndex = 83;
            this.labelAngleChange.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.iconPictureBoxOn);
            this.groupBox1.Controls.Add(this.labelBaudRate);
            this.groupBox1.Controls.Add(this.labelPortName);
            this.groupBox1.Controls.Add(this.comboBoxPortName);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.buttonOpenPort);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 169);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM Port";
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
            this.iconPictureBoxOn.TabIndex = 93;
            this.iconPictureBoxOn.TabStop = false;
            // 
            // textBoxMeasuredData
            // 
            this.textBoxMeasuredData.Location = new System.Drawing.Point(443, 61);
            this.textBoxMeasuredData.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMeasuredData.Multiline = true;
            this.textBoxMeasuredData.Name = "textBoxMeasuredData";
            this.textBoxMeasuredData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMeasuredData.Size = new System.Drawing.Size(268, 449);
            this.textBoxMeasuredData.TabIndex = 92;
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveData.Location = new System.Drawing.Point(325, 224);
            this.buttonSaveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Size = new System.Drawing.Size(100, 32);
            this.buttonSaveData.TabIndex = 91;
            this.buttonSaveData.Text = "Save";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // buttonSetAngle
            // 
            this.buttonSetAngle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetAngle.Location = new System.Drawing.Point(325, 30);
            this.buttonSetAngle.Name = "buttonSetAngle";
            this.buttonSetAngle.Size = new System.Drawing.Size(100, 32);
            this.buttonSetAngle.TabIndex = 90;
            this.buttonSetAngle.Text = "Set Angle";
            this.buttonSetAngle.UseVisualStyleBackColor = true;
            this.buttonSetAngle.Click += new System.EventHandler(this.buttonSetAngle_Click);
            // 
            // textBoxDegreeSet
            // 
            this.textBoxDegreeSet.Location = new System.Drawing.Point(325, 68);
            this.textBoxDegreeSet.Name = "textBoxDegreeSet";
            this.textBoxDegreeSet.Size = new System.Drawing.Size(100, 31);
            this.textBoxDegreeSet.TabIndex = 89;
            this.textBoxDegreeSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDegreeSet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxDegreeSet_MouseClick);
            // 
            // buttonStopMeasure
            // 
            this.buttonStopMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStopMeasure.Location = new System.Drawing.Point(325, 146);
            this.buttonStopMeasure.Name = "buttonStopMeasure";
            this.buttonStopMeasure.Size = new System.Drawing.Size(100, 32);
            this.buttonStopMeasure.TabIndex = 88;
            this.buttonStopMeasure.Text = "Stop";
            this.buttonStopMeasure.UseVisualStyleBackColor = true;
            this.buttonStopMeasure.Click += new System.EventHandler(this.buttonStopMeasure_Click);
            // 
            // buttonStartMeasure
            // 
            this.buttonStartMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartMeasure.Location = new System.Drawing.Point(325, 107);
            this.buttonStartMeasure.Name = "buttonStartMeasure";
            this.buttonStartMeasure.Size = new System.Drawing.Size(100, 32);
            this.buttonStartMeasure.TabIndex = 87;
            this.buttonStartMeasure.Text = "Start";
            this.buttonStartMeasure.UseVisualStyleBackColor = true;
            this.buttonStartMeasure.Click += new System.EventHandler(this.buttonStartMeasure_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 85;
            this.label2.Text = "User Command";
            // 
            // labelDegree
            // 
            this.labelDegree.AutoSize = true;
            this.labelDegree.BackColor = System.Drawing.Color.White;
            this.labelDegree.Location = new System.Drawing.Point(1419, 643);
            this.labelDegree.Name = "labelDegree";
            this.labelDegree.Size = new System.Drawing.Size(22, 25);
            this.labelDegree.TabIndex = 87;
            this.labelDegree.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.Location = new System.Drawing.Point(325, 185);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 32);
            this.buttonReset.TabIndex = 93;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelMeasuredData
            // 
            this.labelMeasuredData.AutoSize = true;
            this.labelMeasuredData.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeasuredData.Location = new System.Drawing.Point(446, 30);
            this.labelMeasuredData.Name = "labelMeasuredData";
            this.labelMeasuredData.Size = new System.Drawing.Size(120, 25);
            this.labelMeasuredData.TabIndex = 94;
            this.labelMeasuredData.Text = "Measurement";
            // 
            // iconPictureBoxReady
            // 
            this.iconPictureBoxReady.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBoxReady.ForeColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxReady.IconChar = FontAwesome.Sharp.IconChar.CircleNotch;
            this.iconPictureBoxReady.IconColor = System.Drawing.Color.Firebrick;
            this.iconPictureBoxReady.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxReady.IconSize = 30;
            this.iconPictureBoxReady.Location = new System.Drawing.Point(616, 30);
            this.iconPictureBoxReady.Name = "iconPictureBoxReady";
            this.iconPictureBoxReady.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBoxReady.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBoxReady.TabIndex = 137;
            this.iconPictureBoxReady.TabStop = false;
            // 
            // labelReady
            // 
            this.labelReady.AutoSize = true;
            this.labelReady.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReady.Location = new System.Drawing.Point(651, 30);
            this.labelReady.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelReady.Name = "labelReady";
            this.labelReady.Size = new System.Drawing.Size(60, 25);
            this.labelReady.TabIndex = 136;
            this.labelReady.Text = "Ready";
            // 
            // Form_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1564, 1040);
            this.Controls.Add(this.iconPictureBoxReady);
            this.Controls.Add(this.labelMeasuredData);
            this.Controls.Add(this.labelReady);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSetAngle);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.textBoxDegreeSet);
            this.Controls.Add(this.buttonStopMeasure);
            this.Controls.Add(this.textBoxMeasuredData);
            this.Controls.Add(this.buttonStartMeasure);
            this.Controls.Add(this.labelDegree);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelAngleChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartPeelAngle);
            this.Controls.Add(this.chartAngleChange);
            this.Controls.Add(this.textBoxCMD);
            this.Controls.Add(this.buttonClearCMD);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Name = "Form_2";
            this.Text = "Form_2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_2_FormClosed);
            this.Load += new System.EventHandler(this.Form_2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartAngleChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeelAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.TextBox textBoxCMD;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonClearCMD;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAngleChange;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeelAngle;
        private System.Windows.Forms.Label labelAngleChange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDegree;
        private System.Windows.Forms.Button buttonStopMeasure;
        private System.Windows.Forms.Button buttonStartMeasure;
        private System.Windows.Forms.Button buttonSetAngle;
        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.TextBox textBoxMeasuredData;
        public System.Windows.Forms.TextBox textBoxDegreeSet;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxOn;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelMeasuredData;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxReady;
        private System.Windows.Forms.Label labelReady;
    }
}