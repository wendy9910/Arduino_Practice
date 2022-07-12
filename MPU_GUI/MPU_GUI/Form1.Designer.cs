namespace MPU_GUI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RComPortbtn = new System.Windows.Forms.Button();
            this.RBTbtn = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.clearbtn = new System.Windows.Forms.Button();
            this.GetBTbtn = new System.Windows.Forms.Button();
            this.UpdateComPort = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startbtn = new System.Windows.Forms.Button();
            this.GetComPortbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RComPortbtn);
            this.groupBox1.Controls.Add(this.RBTbtn);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.clearbtn);
            this.groupBox1.Controls.Add(this.GetBTbtn);
            this.groupBox1.Controls.Add(this.UpdateComPort);
            this.groupBox1.Controls.Add(this.stopbtn);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.startbtn);
            this.groupBox1.Controls.Add(this.GetComPortbtn);
            this.groupBox1.Location = new System.Drawing.Point(19, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RComPortbtn
            // 
            this.RComPortbtn.BackColor = System.Drawing.Color.PowderBlue;
            this.RComPortbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.RComPortbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RComPortbtn.Location = new System.Drawing.Point(14, 93);
            this.RComPortbtn.Name = "RComPortbtn";
            this.RComPortbtn.Size = new System.Drawing.Size(284, 44);
            this.RComPortbtn.TabIndex = 8;
            this.RComPortbtn.Text = "Receiving by Com Port";
            this.RComPortbtn.UseVisualStyleBackColor = false;
            this.RComPortbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // RBTbtn
            // 
            this.RBTbtn.BackColor = System.Drawing.Color.PowderBlue;
            this.RBTbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.RBTbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RBTbtn.Location = new System.Drawing.Point(324, 93);
            this.RBTbtn.Name = "RBTbtn";
            this.RBTbtn.Size = new System.Drawing.Size(265, 44);
            this.RBTbtn.TabIndex = 7;
            this.RBTbtn.Text = "Receiving by BT";
            this.RBTbtn.UseVisualStyleBackColor = false;
            this.RBTbtn.Click += new System.EventHandler(this.RBTbtn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(324, 64);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(265, 23);
            this.comboBox2.TabIndex = 6;
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clearbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.clearbtn.Location = new System.Drawing.Point(624, 104);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(86, 32);
            this.clearbtn.TabIndex = 4;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            // 
            // GetBTbtn
            // 
            this.GetBTbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GetBTbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.GetBTbtn.Location = new System.Drawing.Point(324, 24);
            this.GetBTbtn.Name = "GetBTbtn";
            this.GetBTbtn.Size = new System.Drawing.Size(265, 31);
            this.GetBTbtn.TabIndex = 5;
            this.GetBTbtn.Text = "Get BT";
            this.GetBTbtn.UseVisualStyleBackColor = false;
            this.GetBTbtn.Click += new System.EventHandler(this.GetBTbtn_Click);
            // 
            // UpdateComPort
            // 
            this.UpdateComPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.UpdateComPort.Font = new System.Drawing.Font("新細明體", 14F);
            this.UpdateComPort.Location = new System.Drawing.Point(751, 20);
            this.UpdateComPort.Name = "UpdateComPort";
            this.UpdateComPort.Size = new System.Drawing.Size(248, 117);
            this.UpdateComPort.TabIndex = 4;
            this.UpdateComPort.Text = "Update Com Port";
            this.UpdateComPort.UseVisualStyleBackColor = false;
            // 
            // stopbtn
            // 
            this.stopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stopbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.stopbtn.Location = new System.Drawing.Point(624, 62);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(86, 36);
            this.stopbtn.TabIndex = 3;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = false;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(284, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // startbtn
            // 
            this.startbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.startbtn.Location = new System.Drawing.Point(624, 24);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(86, 31);
            this.startbtn.TabIndex = 2;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = false;
            // 
            // GetComPortbtn
            // 
            this.GetComPortbtn.BackColor = System.Drawing.Color.PaleGreen;
            this.GetComPortbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.GetComPortbtn.Location = new System.Drawing.Point(14, 20);
            this.GetComPortbtn.Name = "GetComPortbtn";
            this.GetComPortbtn.Size = new System.Drawing.Size(284, 35);
            this.GetComPortbtn.TabIndex = 0;
            this.GetComPortbtn.Text = "Get COM Port";
            this.GetComPortbtn.UseVisualStyleBackColor = false;
            this.GetComPortbtn.Click += new System.EventHandler(this.GetComPortbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1017, 428);
            this.textBox1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 648);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdateComPort;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button GetComPortbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button clearbtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button RComPortbtn;
        private System.Windows.Forms.Button RBTbtn;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button GetBTbtn;
    }
}

