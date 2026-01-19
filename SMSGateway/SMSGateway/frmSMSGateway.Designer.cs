namespace SMSGateway
{
    partial class frmSMSGateway
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
            this.timerSendSMS = new System.Windows.Forms.Timer(this.components);
            this.timerReadSMS = new System.Windows.Forms.Timer(this.components);
            this.timerLogging = new System.Windows.Forms.Timer(this.components);
            this.timerBenchMark = new System.Windows.Forms.Timer(this.components);
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.lblUptime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerSendSMS
            // 
            this.timerSendSMS.Interval = 5000;
            this.timerSendSMS.Tick += new System.EventHandler(this.timerSendSMS_Tick);
            // 
            // timerReadSMS
            // 
            this.timerReadSMS.Interval = 5000;
            this.timerReadSMS.Tick += new System.EventHandler(this.timerReadSMS_Tick);
            // 
            // timerLogging
            // 
            this.timerLogging.Interval = 5000;
            this.timerLogging.Tick += new System.EventHandler(this.timerLogging_Tick);
            // 
            // timerBenchMark
            // 
            this.timerBenchMark.Interval = 60000;
            this.timerBenchMark.Tick += new System.EventHandler(this.timerBenchMark_Tick);
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(12, 28);
            this.txtoutput.Multiline = true;
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(374, 233);
            this.txtoutput.TabIndex = 0;
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(12, 9);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(0, 13);
            this.lblUptime.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 273);
            this.Controls.Add(this.lblUptime);
            this.Controls.Add(this.txtoutput);
            this.Name = "Form1";
            this.Text = "SMS Gateway";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.Timer timerSendSMS;
        private System.Windows.Forms.Timer timerReadSMS;
        private System.Windows.Forms.Timer timerLogging;
        private System.Windows.Forms.Timer timerBenchMark;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.Label lblUptime;
    }
}

