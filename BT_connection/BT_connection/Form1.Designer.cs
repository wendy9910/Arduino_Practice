namespace BT_connection
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
            this.scan_bt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // scan_bt
            // 
            this.scan_bt.BackColor = System.Drawing.Color.PowderBlue;
            this.scan_bt.Font = new System.Drawing.Font("新細明體", 14F);
            this.scan_bt.ForeColor = System.Drawing.SystemColors.InfoText;
            this.scan_bt.Location = new System.Drawing.Point(264, 21);
            this.scan_bt.Name = "scan_bt";
            this.scan_bt.Size = new System.Drawing.Size(274, 44);
            this.scan_bt.TabIndex = 0;
            this.scan_bt.Text = "Scan BT Devices";
            this.scan_bt.UseVisualStyleBackColor = false;
            this.scan_bt.Click += new System.EventHandler(this.scan_bt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.textBox1.Location = new System.Drawing.Point(26, 88);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(750, 324);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.scan_bt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scan_bt;
        private System.Windows.Forms.TextBox textBox1;
    }
}

