using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Globalization;
using System.Diagnostics;
using TestLibrary;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace SrvC
{
    public class ServerSocket      // 서버 기능 소켓
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket socketC;
       
        IPAddress add;
        bool Sstate; // false = off / true = on
       


        public ServerSocket()
        {
            _textAppender = new AppendTextDelegate(AppendText);
        }
        
        public String GetCurrectIPAddres()
        {
            return GetIP();
        }

     
       public bool startServer(IPAddress addr)
        {
            add = addr;
            socketC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port;
            if (!int.TryParse(serverF.serverForm.txtPort.Text, out port))
            {
                MessageBox.Show("포트번호가 입력되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serverF.serverForm.txtPort.Focus();
                serverF.serverForm.txtPort.SelectAll();
                return false;
            }
            

    // 서버에서 클라이언트의 연결 요청을 대기하기 위해
    // 소켓을 열어둔다.
            IPEndPoint serverEP = new IPEndPoint(add, port);
            socketC.Bind(serverEP);
            socketC.Listen(10);

            // 비동기적으로 클라이언트의 연결 요청을 받는다.
            socketC.BeginAccept(AcceptCallback ,null);
            serverF.serverForm.txtLog.Text += "서버 호스팅중";
            return true;
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

       

        public void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            // 데이터 수신을 끝낸다.
            int received = obj.WorkingSocket.EndReceive(ar);

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            if (received <= 0)
            {
                obj.WorkingSocket.Close();
                return;
            }

            // 텍스트로 변환한다.
            string text = Encoding.UTF8.GetString(obj.Buffer);

            // 0x01 기준으로 짜른다.
            // tokens[0] - 보낸 사람 IP
            // tokens[1] - 보낸 메세지
            string[] tokens = text.Split('#');
            string ip = tokens[0];
            string msg = tokens[1];
            string nick = tokens[2];

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.
            AppendText(serverF.serverForm.txtLog, string.Format("[Client]{0}: {1}", ip, msg));

            // for을 통해 "역순"으로 클라이언트에게 데이터를 보낸다.
            for (int i = connectedClient.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClient[i];
                if (socket != obj.WorkingSocket)
                {
                    try { socket.Send(obj.Buffer); }
                    catch
                    {
                        // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                        try { socket.Dispose(); } catch { }
                        connectedClient.RemoveAt(i);
                    }
                }
            }

            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
        }

        String GetIP()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

        // 접속된 클라이언트 소켓리스트
        List<Socket> connectedClient = new List<Socket>();

        public void AcceptCallback(IAsyncResult ar)
        {
            ServerSocket srv = new ServerSocket();
            // 요청받은 연결 수락
            Socket client = socketC.EndAccept(ar);

            // 다시 안열어주면 연결을 못받음?
            socketC.BeginAccept(AcceptCallback, null);


            //4096이 일반적인 buffersize?
            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = client;

            connectedClient.Add(client);
            string clientIp = client.RemoteEndPoint.ToString();
            AppendText(serverF.serverForm.txtLog, string.Format("클라이언트 (@ {0})가 연결되었습니다.", client.RemoteEndPoint));
            AppendText(serverF.serverForm.txtList, clientIp);

            //client 데이터 recieve
            client.BeginReceive(obj.Buffer, 0, 4096, 0, srv.DataReceived, obj);

        }
       public void OnSendData(object sender, EventArgs e)
        {
            // 서버가 대기중인지 확인한다.
            if (!socketC.IsBound)
            {
                MessageBox.Show("서버가 실행중이 아닙니다..", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 보낼 텍스트
            string tts = serverF.serverForm.txtInput.Text.Trim();
            if (string.IsNullOrEmpty(tts))
            {
                MessageBox.Show("내용을 입력해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serverF.serverForm.txtInput.Focus();
                return;
            }
            
            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(add.ToString() + '#' + tts);
            int l = connectedClient.Count;
            serverF.serverForm.lbdebug.Text = l.ToString();
            // 연결된 모든 클라이언트에게 전송한다.
            for (int i = connectedClient.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClient[i];
                try { socket.Send(bDts); }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try { socket.Dispose(); } catch { }
                    connectedClient.RemoveAt(i);
                }
            }

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(serverF.serverForm.txtLog, string.Format("[Server]{0}: {1}", add.ToString(), tts));
            serverF.serverForm.txtInput.Clear();
        }
    }
    }

