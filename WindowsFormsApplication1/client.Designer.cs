namespace WindowsFormsApplication1
{
    partial class client
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
            this.lbPort = new System.Windows.Forms.Label();
            this.lbAdd = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(183, 28);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(34, 12);
            this.lbPort.TabIndex = 15;
            this.lbPort.Text = "port :";
            // 
            // lbAdd
            // 
            this.lbAdd.AutoSize = true;
            this.lbAdd.Location = new System.Drawing.Point(15, 28);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(23, 12);
            this.lbAdd.TabIndex = 14;
            this.lbAdd.Text = "ip :";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(484, 332);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 13;
            this.btSend.Text = "전송";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.SendD);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(356, 23);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 12;
            this.btConnect.Text = "연결";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.onConnectSrv);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(49, 334);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(417, 21);
            this.txtInput.TabIndex = 11;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(49, 82);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(417, 222);
            this.txtLog.TabIndex = 10;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(239, 23);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 9;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(66, 23);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(100, 21);
            this.txtAdd.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(472, 23);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 16;
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 378);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbAdd);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAdd);
            this.Name = "client";
            this.Text = "Client";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbAdd;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.TextBox txtId;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}