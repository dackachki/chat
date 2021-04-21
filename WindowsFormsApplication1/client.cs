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

namespace WindowsFormsApplication1
{
    public partial class client : Form
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket SocketTest;
        public client()
        {
            InitializeComponent();
            SocketTest = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _textAppender = new AppendTextDelegate(Appendtext);
        }

        private void Appendtext(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }
       
        void onConnectSrv(object sender , EventArgs e) {
                if(SocketTest.Connected)
                {
                    MessageBox.Show("이미 연결중입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MessageBox.Show("포트번호가 유효하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
                txtPort.SelectAll();
                return;
            }
            try { SocketTest.Connect(txtAdd.Text, port); }
            
            catch(Exception ev){
                MessageBox.Show(ev.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Appendtext(txtLog, "서버 연결됨");

            AsyncObject obj = new AsyncObject(4096);

            obj.WorkingSocket = SocketTest;                 
            
            //AsyncCallBack
            SocketTest.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        private void DataReceived(IAsyncResult ar)
        {

            AsyncObject obj = (AsyncObject)ar.AsyncState;

                                              
            //IAsyncResult
            int received = obj.WorkingSocket.EndReceive(ar);

            //받은 데이터가 없을때 

            if(received <= 0 )
            {
                obj.WorkingSocket.Close();
                return;
            }

            //받은걸 UTF8로 인코딩
            string text = Encoding.UTF8.GetString(obj.Buffer);

            // 0x01 기준으로 짜른다. 보낼떄 "0x01"을 데이터 사이에 집어 넣어서
            // tokens[0] - 보낸 사람 IP
            // tokens[1] - 보낸 메세지
            string[] tokens = text.Split('\x01');
            string ip = tokens[0];
            string msg = tokens[1];

            Appendtext(txtLog, string.Format("[server받음]{0} : {1}", ip, msg));

            //데이터 수신 후 버퍼 비워주기
            obj.ClearBuffer();
            //다시 수신대기
            
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
        }
        void SendD(object sender , EventArgs e)
        {
            //소켓이 바인딩이 되었는지 boolean값 리턴 
            if(!SocketTest.IsBound)
            {
                MessageBox.Show("서버가 실행중이 아닙니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string txt = txtInput.Text.Trim();
            if(string.IsNullOrEmpty(txt))
            {
                MessageBox.Show("내용을 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInput.Focus();
                return;
            }
                                                    //  localendpoint = EndPoint 가 바인딩되는 로컬 IP 주소와 포트 번호 리턴
            IPEndPoint ip = (IPEndPoint)SocketTest.LocalEndPoint;
            string addr = ip.Address.ToString();
            string id = txtId.Text.ToString();
           
            id += '/'+ addr;
            if (id.Length <= 0)
            {
                id = addr+'/'+ addr;
            }

            //문자열을 utf8 바이트로 인코딩 GetBytes <-> GetString
            byte[] bts = Encoding.UTF8.GetBytes(id + "\x01" + txt);

            //서버로 전송
            SocketTest.Send(bts);

            Appendtext(txtLog, string.Format("[보냄] {0}: {1}", addr, txt));
            txtInput.Clear();

        }

      
    }
}
