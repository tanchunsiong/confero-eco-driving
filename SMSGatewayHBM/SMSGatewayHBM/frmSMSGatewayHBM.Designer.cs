namespace SMSGatewayHBM
{
    partial class frmSMSGatewayHBM
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
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.timerHeartBeat = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(12, 12);
            this.txtoutput.Multiline = true;
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtoutput.Size = new System.Drawing.Size(268, 249);
            this.txtoutput.TabIndex = 0;
            // 
            // timerHeartBeat
            // 
            this.timerHeartBeat.Interval = 10000;
            this.timerHeartBeat.Tick += new System.EventHandler(this.timerHeartBeat_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmSMSGatewayHBM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtoutput);
            this.Name = "frmSMSGatewayHBM";
            this.Text = "SMS Gateway Heartbeat Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.Timer timerHeartBeat;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

