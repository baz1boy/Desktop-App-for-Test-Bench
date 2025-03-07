namespace L298N_Control
{
    partial class Form_1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.textBoxCMD = new System.Windows.Forms.TextBox();
            this.chartLoadCell = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonClearCMD = new System.Windows.Forms.Button();
            this.textBoxDataSave = new System.Windows.Forms.TextBox();
            this.buttonSaveMData = new System.Windows.Forms.Button();
            this.groupBoxCOM = new System.Windows.Forms.GroupBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.iconPictureBoxOn = new FontAwesome.Sharp.IconPictureBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.labelPortName = new System.Windows.Forms.Label();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelReady = new System.Windows.Forms.Label();
            this.iconPictureBoxReady = new FontAwesome.Sharp.IconPictureBox();
            this.labelMeasuredData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelForceLC1 = new System.Windows.Forms.Label();
            this.labelForceLC2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadCell)).BeginInit();
            this.groupBoxCOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.Location = new System.Drawing.Point(22, 263);
            this.textBoxCMD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCMD.Multiline = true;
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCMD.Size = new System.Drawing.Size(403, 247);
            this.textBoxCMD.TabIndex = 1;
            // 
            // chartLoadCell
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLoadCell.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLoadCell.Legends.Add(legend1);
            this.chartLoadCell.Location = new System.Drawing.Point(732, 30);
            this.chartLoadCell.Name = "chartLoadCell";
            this.chartLoadCell.Size = new System.Drawing.Size(830, 480);
            this.chartLoadCell.TabIndex = 14;
            this.chartLoadCell.Text = "chart2";
            // 
            // buttonClearCMD
            // 
            this.buttonClearCMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearCMD.Location = new System.Drawing.Point(202, 224);
            this.buttonClearCMD.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearCMD.Name = "buttonClearCMD";
            this.buttonClearCMD.Size = new System.Drawing.Size(100, 32);
            this.buttonClearCMD.TabIndex = 16;
            this.buttonClearCMD.Text = "Clear";
            this.buttonClearCMD.UseVisualStyleBackColor = true;
            this.buttonClearCMD.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxDataSave
            // 
            this.textBoxDataSave.Location = new System.Drawing.Point(443, 61);
            this.textBoxDataSave.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDataSave.Multiline = true;
            this.textBoxDataSave.Name = "textBoxDataSave";
            this.textBoxDataSave.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDataSave.Size = new System.Drawing.Size(268, 449);
            this.textBoxDataSave.TabIndex = 17;
            // 
            // buttonSaveMData
            // 
            this.buttonSaveMData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveMData.Location = new System.Drawing.Point(325, 224);
            this.buttonSaveMData.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveMData.Name = "buttonSaveMData";
            this.buttonSaveMData.Size = new System.Drawing.Size(100, 32);
            this.buttonSaveMData.TabIndex = 18;
            this.buttonSaveMData.Text = "Save";
            this.buttonSaveMData.UseVisualStyleBackColor = true;
            this.buttonSaveMData.Click += new System.EventHandler(this.buttonSaveMData_Click);
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
            this.groupBoxCOM.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCOM.Name = "groupBoxCOM";
            this.groupBoxCOM.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCOM.Size = new System.Drawing.Size(280, 169);
            this.groupBoxCOM.TabIndex = 87;
            this.groupBoxCOM.TabStop = false;
            this.groupBoxCOM.Text = "COM Port";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(19, 77);
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
            this.iconPictureBoxOn.TabIndex = 102;
            this.iconPictureBoxOn.TabStop = false;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.ItemHeight = 25;
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
            this.comboBoxBaudRate.TabIndex = 90;
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpenPort.Location = new System.Drawing.Point(132, 119);
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
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(100, 25);
            this.labelPortName.TabIndex = 87;
            this.labelPortName.Text = "Port Name:";
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(132, 34);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(121, 33);
            this.comboBoxPortName.TabIndex = 88;
            this.comboBoxPortName.SelectedValueChanged += new System.EventHandler(this.comboBoxPortName_SelectedValueChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(325, 68);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 32);
            this.buttonStart.TabIndex = 88;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Location = new System.Drawing.Point(325, 107);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(100, 32);
            this.buttonStop.TabIndex = 89;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.Location = new System.Drawing.Point(325, 146);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 32);
            this.buttonReset.TabIndex = 90;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelReady
            // 
            this.labelReady.AutoSize = true;
            this.labelReady.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReady.Location = new System.Drawing.Point(651, 30);
            this.labelReady.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelReady.Name = "labelReady";
            this.labelReady.Size = new System.Drawing.Size(60, 25);
            this.labelReady.TabIndex = 101;
            this.labelReady.Text = "Ready";
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
            this.iconPictureBoxReady.TabIndex = 135;
            this.iconPictureBoxReady.TabStop = false;
            // 
            // labelMeasuredData
            // 
            this.labelMeasuredData.AutoSize = true;
            this.labelMeasuredData.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeasuredData.Location = new System.Drawing.Point(446, 30);
            this.labelMeasuredData.Name = "labelMeasuredData";
            this.labelMeasuredData.Size = new System.Drawing.Size(120, 25);
            this.labelMeasuredData.TabIndex = 136;
            this.labelMeasuredData.Text = "Measurement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 137;
            this.label2.Text = "User Command";
            // 
            // labelForceLC1
            // 
            this.labelForceLC1.AutoSize = true;
            this.labelForceLC1.BackColor = System.Drawing.Color.White;
            this.labelForceLC1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForceLC1.Location = new System.Drawing.Point(1419, 141);
            this.labelForceLC1.Name = "labelForceLC1";
            this.labelForceLC1.Size = new System.Drawing.Size(119, 20);
            this.labelForceLC1.TabIndex = 138;
            this.labelForceLC1.Text = "Load Cell1 Value";
            // 
            // labelForceLC2
            // 
            this.labelForceLC2.AutoSize = true;
            this.labelForceLC2.BackColor = System.Drawing.Color.White;
            this.labelForceLC2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForceLC2.Location = new System.Drawing.Point(1419, 168);
            this.labelForceLC2.Name = "labelForceLC2";
            this.labelForceLC2.Size = new System.Drawing.Size(119, 20);
            this.labelForceLC2.TabIndex = 139;
            this.labelForceLC2.Text = "Load Cell2 Value";
            // 
            // Form_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1564, 1040);
            this.Controls.Add(this.labelForceLC2);
            this.Controls.Add(this.labelForceLC1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMeasuredData);
            this.Controls.Add(this.iconPictureBoxReady);
            this.Controls.Add(this.labelReady);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxCOM);
            this.Controls.Add(this.buttonSaveMData);
            this.Controls.Add(this.textBoxDataSave);
            this.Controls.Add(this.buttonClearCMD);
            this.Controls.Add(this.chartLoadCell);
            this.Controls.Add(this.textBoxCMD);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form_1";
            this.Text = "Form_1";
            ((System.ComponentModel.ISupportInitialize)(this.chartLoadCell)).EndInit();
            this.groupBoxCOM.ResumeLayout(false);
            this.groupBoxCOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxReady)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxCMD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoadCell;
        private System.Windows.Forms.Button buttonClearCMD;
        private System.Windows.Forms.TextBox textBoxDataSave;
        private System.Windows.Forms.Button buttonSaveMData;
        private System.Windows.Forms.GroupBox groupBoxCOM;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelReady;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxOn;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxReady;
        private System.Windows.Forms.Label labelMeasuredData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelForceLC1;
        private System.Windows.Forms.Label labelForceLC2;
    }
}