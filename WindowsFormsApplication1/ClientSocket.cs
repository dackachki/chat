using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using TestLibrary;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace Client_
{
    class ClientSocket
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket socketC;


        public void Appendtext(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }
        public bool startClient(IPAddress add)
        {

            socketC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (socketC.Connected)
            {
                MessageBox.Show("이미 연결중입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int port;

            if (!int.TryParse(serverF.serverForm.txtPort.Text, out port))
            {
                MessageBox.Show("포트번호가 유효하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serverF.serverForm.txtPort.Focus();
                serverF.serverForm.txtPort.SelectAll();
                return false;
            }
            try { socketC.Connect(add, port); }

            // catch에 return 가능 넣으면 무조건 실행됨
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            

            Appendtext(serverF.serverForm.txtLog, "서버 연결됨");

            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = socketC;                          //AsyncCallBack
            socketC.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);

            return true;

        }
         public void DataReceived(IAsyncResult ar)
             {
                 AsyncObject obj = (AsyncObject)ar.AsyncState;
                //IAsyncResult
                 int received = obj.WorkingSocket.EndReceive(ar);
            
             //받은 데이터가 없을때 
             if (received <= 0)
                {
                   obj.WorkingSocket.Close();
                  return;
                 }
        //받은걸 UTF8로 인코딩
        string text = Encoding.UTF8.GetString(obj.Buffer);

        // 0x01 기준으로 짜른다. 보낼떄 "0x01"을 데이터 사이에 집어 넣어서
        // tokens[0] - 보낸 사람 IP
        // tokens[1] - 보낸 메세지
        string[] tokens = text.Split('#');
        string ip = tokens[0];
        string msg = tokens[1];
           

        Appendtext(serverF.serverForm.txtLog, string.Format("[server에게 받음]{0} : {1}", ip, msg));

        //데이터 수신 후 버퍼 비워주기
        obj.ClearBuffer();
        //다시 수신대기
        obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
         }

      public void SendD(object sender, EventArgs e)
             {   
            
        //소켓이 바인딩이 되었는지 boolean값 리턴 
        if (!socketC.IsBound)
        {
            MessageBox.Show("서버가 실행중이 아닙니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        string txt = serverF.serverForm.txtInput.Text.Trim();
        if (string.IsNullOrEmpty(txt))
        {
            MessageBox.Show("내용을 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serverF.serverForm.txtInput.Focus();
            return;
        }
        //  localendpoint = EndPoint 가 바인딩되는 로컬 IP 주소와 포트 번호 리턴
        IPEndPoint ip = (IPEndPoint)socketC.LocalEndPoint;
        string addr = ip.Address.ToString();
        
        string nick = serverF.serverForm.txtId.ToString();
            if (string.IsNullOrEmpty(nick))
            {
                nick = addr;
            }
            //문자열을 utf8 바이트로 인코딩 GetBytes <-> GetString
            byte[] bts = Encoding.UTF8.GetBytes(addr + "#" + txt + "#" + nick);

            //서버로 전송
            socketC.Send(bts);

        Appendtext(serverF.serverForm.txtLog, string.Format("[보냄] {0}: {1}", addr, txt));
            serverF.serverForm.txtInput.Clear();

    }
        public void ConnectSockets(Socket socketC) { 
                
                if (socketC.Connected)
                {
                    MessageBox.Show("이미 연결중입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                 int port;
                if (!int.TryParse(serverF.serverForm.txtPort.Text, out port))
                {
                    MessageBox.Show("포트번호가 유효하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serverF.serverForm.txtPort.Focus();
                serverF.serverForm.txtPort.SelectAll();
                    return;
                }
                try { socketC.Connect(serverF.serverForm.txtAdd.Text, port); }

                catch (Exception ev)
                {
                    MessageBox.Show(ev.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
            Appendtext(serverF.serverForm.txtLog, "서버 연결됨");

                  AsyncObject obj = new AsyncObject(4096);

                  obj.WorkingSocket = socketC;                
                                                                        //AsyncCallBack
                socketC.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
            }
            
    }
}
