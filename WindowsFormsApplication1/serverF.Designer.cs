namespace WindowsFormsApplication1
{
    partial class serverF
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbAdd = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.btnNxtF = new System.Windows.Forms.Button();
            this.lbdebug = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtList = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lbAdd
            // 
            this.lbAdd.AutoSize = true;
            this.lbAdd.Location = new System.Drawing.Point(13, 26);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(73, 12);
            this.lbAdd.TabIndex = 0;
            this.lbAdd.Text = "ip address :";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(252, 26);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(27, 12);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "Port";
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(92, 23);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(100, 21);
            this.txtAdd.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(303, 22);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(69, 312);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(452, 21);
            this.txtInput.TabIndex = 4;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(22, 315);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(29, 12);
            this.lbInput.TabIndex = 5;
            this.lbInput.Text = "입력";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(9, 72);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(608, 217);
            this.txtLog.TabIndex = 6;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(446, 22);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 7;
            this.btConnect.Text = "호스팅";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(542, 310);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 8;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btnNxtF
            // 
            this.btnNxtF.Location = new System.Drawing.Point(527, 22);
            this.btnNxtF.Name = "btnNxtF";
            this.btnNxtF.Size = new System.Drawing.Size(75, 23);
            this.btnNxtF.TabIndex = 9;
            this.btnNxtF.Text = "client";
            this.btnNxtF.UseVisualStyleBackColor = true;
            this.btnNxtF.Click += new System.EventHandler(this.btnNxtF_Click);
            // 
            // lbdebug
            // 
            this.lbdebug.AutoSize = true;
            this.lbdebug.Location = new System.Drawing.Point(13, 57);
            this.lbdebug.Name = "lbdebug";
            this.lbdebug.Size = new System.Drawing.Size(25, 12);
            this.lbdebug.TabIndex = 10;
            this.lbdebug.Text = "test";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(608, 23);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(650, 72);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ReadOnly = true;
            this.txtList.Size = new System.Drawing.Size(173, 217);
            this.txtList.TabIndex = 12;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(723, 22);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 13;
            // 
            // serverF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 358);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbdebug);
            this.Controls.Add(this.btnNxtF);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbAdd);
            this.Name = "serverF";
            this.Text = "Waiting..";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAdd;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btnNxtF;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.TextBox txtAdd;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtInput;
        public System.Windows.Forms.TextBox txtLog;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.Label lbdebug;
        public System.Windows.Forms.TextBox txtList;
    }
}

