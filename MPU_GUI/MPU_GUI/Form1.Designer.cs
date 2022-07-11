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
            this.UpdateComPort = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.clearbtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.stopbtn2 = new System.Windows.Forms.Button();
            this.startbtn2 = new System.Windows.Forms.Button();
            this.clearbtn2 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateComPort);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // UpdateComPort
            // 
            this.UpdateComPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.UpdateComPort.Font = new System.Drawing.Font("新細明體", 12F);
            this.UpdateComPort.Location = new System.Drawing.Point(595, 20);
            this.UpdateComPort.Name = "UpdateComPort";
            this.UpdateComPort.Size = new System.Drawing.Size(175, 31);
            this.UpdateComPort.TabIndex = 4;
            this.UpdateComPort.Text = "Update Com Port";
            this.UpdateComPort.UseVisualStyleBackColor = false;
            // 
            // stopbtn
            // 
            this.stopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.stopbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.stopbtn.Location = new System.Drawing.Point(697, 144);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(82, 31);
            this.stopbtn.TabIndex = 3;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = false;
            // 
            // startbtn
            // 
            this.startbtn.BackColor = System.Drawing.Color.Pink;
            this.startbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.startbtn.Location = new System.Drawing.Point(695, 107);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(84, 31);
            this.startbtn.TabIndex = 2;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Font = new System.Drawing.Font("新細明體", 12F);
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Ports";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 107);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(660, 142);
            this.textBox1.TabIndex = 1;
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clearbtn.Font = new System.Drawing.Font("新細明體", 12F);
            this.clearbtn.Location = new System.Drawing.Point(697, 181);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(82, 31);
            this.clearbtn.TabIndex = 4;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 278);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(660, 137);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // stopbtn2
            // 
            this.stopbtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.stopbtn2.Font = new System.Drawing.Font("新細明體", 12F);
            this.stopbtn2.Location = new System.Drawing.Point(699, 326);
            this.stopbtn2.Name = "stopbtn2";
            this.stopbtn2.Size = new System.Drawing.Size(82, 31);
            this.stopbtn2.TabIndex = 7;
            this.stopbtn2.Text = "Stop";
            this.stopbtn2.UseVisualStyleBackColor = false;
            // 
            // startbtn2
            // 
            this.startbtn2.BackColor = System.Drawing.Color.Pink;
            this.startbtn2.Font = new System.Drawing.Font("新細明體", 12F);
            this.startbtn2.Location = new System.Drawing.Point(698, 289);
            this.startbtn2.Name = "startbtn2";
            this.startbtn2.Size = new System.Drawing.Size(84, 31);
            this.startbtn2.TabIndex = 6;
            this.startbtn2.Text = "Start";
            this.startbtn2.UseVisualStyleBackColor = false;
            // 
            // clearbtn2
            // 
            this.clearbtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clearbtn2.Font = new System.Drawing.Font("新細明體", 12F);
            this.clearbtn2.Location = new System.Drawing.Point(700, 366);
            this.clearbtn2.Name = "clearbtn2";
            this.clearbtn2.Size = new System.Drawing.Size(82, 31);
            this.clearbtn2.TabIndex = 8;
            this.clearbtn2.Text = "Clear";
            this.clearbtn2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 443);
            this.Controls.Add(this.clearbtn2);
            this.Controls.Add(this.stopbtn2);
            this.Controls.Add(this.startbtn2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startbtn);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button stopbtn2;
        private System.Windows.Forms.Button startbtn2;
        private System.Windows.Forms.Button clearbtn2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}

