
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;
using Client_;
using SrvC;

namespace WindowsFormsApplication1
{
    public partial class serverF : Form
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        ClientSocket socketC2 = null;
        ServerSocket socketC = null;
        public IPAddress add;
        List<Socket> connectedClient = new List<Socket>();
        public static serverF serverForm;
        int state = 0;
        bool IsActive = false;

        public serverF()
        {
            InitializeComponent();
            _textAppender = new AppendTextDelegate(AppendText);
            serverForm = this;
        }
        void AppendText(Control ctrl, string s)
        {   //invoke...? thread 관련 
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }

        void OnFormLoaded(object sender, EventArgs e)
        {   //pc ip 가져오기
            IPHostEntry aa = Dns.GetHostEntry(Dns.GetHostName());

            /*
            AddressFamily = 네트워크 유형
            SocketType = 데이터 연결
            ProtocolType = 특정 네트워크 프로토콜
            비동기 다중 = stream + tcp?
            소켓초기화
           */
 
            foreach (IPAddress addr in aa.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    add = addr;
                    break;
                }
            }
            if (add == null)
                // 로컬호스트 주소를 사용한다.
                add = IPAddress.Loopback;

            txtAdd.Text = add.ToString();
            
            btSend.Enabled = false;
            txtLog.BackColor = System.Drawing.Color.Gray;
            txtInput.BackColor = System.Drawing.Color.Gray;
           
        }
        private void btnNxtF_Click(object sender, EventArgs e)
        {
            socketC2 = new ClientSocket();
            IsActive = socketC2.startClient(add);
            

            if (IsActive)
            {
                state = 2;
                btSend.Enabled = true;
                txtLog.BackColor = System.Drawing.Color.White;
                txtInput.BackColor = System.Drawing.Color.White;
                btConnect.Enabled = false;
                btnNxtF.Text = "서버 접속중";
                btnNxtF.Enabled = false;
                serverForm.Text = "Client";
            }
        }

    

        private void btConnect_Click(object sender, EventArgs e)
        {
            socketC = new ServerSocket();
           IsActive = socketC.startServer(add);
            
            if (IsActive) {
                state = 1;
                btSend.Enabled = true;
                txtLog.BackColor = System.Drawing.Color.White;
                txtInput.BackColor = System.Drawing.Color.White;
                btnNxtF.Enabled = false;
                btConnect.Enabled = false;
                btConnect.Text = "서버 ON";
                serverForm.Text = "Server";
            }
            
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if(state == 1)
            {
                socketC.OnSendData(sender,e);
                
            }
            if(state == 2)
            {
                socketC2.SendD(sender, e);
                
            }

        }
    }
}
    
    

