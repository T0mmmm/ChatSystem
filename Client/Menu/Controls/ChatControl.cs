using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client.Files.Def.Encryption;
using static Client.Files.Def.Var;

namespace Client.Menu.Controls
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }

        private void ChatControl_Load(object sender, EventArgs e)
        {

            //Try to send a connect message
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strHost);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string message = "message=" + "CONNECT"; //dont encrypt this the server don't have the key of decryption
                string postData = message + "&key=" + strServerKey;
                byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = data.Length;
                System.IO.Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                ConnectionWasSend = true;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            //Run async tasks
            Task.Run(() => GetLatestMessage());
            Task.Run(() => GetUserOnline());
        }


        #region getmessage, getonline
        private async void GetUserOnline()
        {
            while (true)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        string html = await client.GetStringAsync(strHost);
                        int startIndex = html.LastIndexOf("<p style='text-align:center; color:white; id='UserOnline' >Online: ") + 67;
                        int endIndex = html.LastIndexOf("</p><p style='text-align:center; color:white; id='LimitConnection' >Max Connections: ");
                        string onlineUsers = html.Substring(startIndex, endIndex - startIndex);
                        lblOnline.Text = "Online: " + onlineUsers;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Delay 10 sec
                await Task.Delay(10000);
            }

        }


        private async void GetLatestMessage()
        {
            while (true)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(strHost);
                        if (response.IsSuccessStatusCode)
                        {
                            string html = await response.Content.ReadAsStringAsync();

                            //finding the message without the html code
                            int startIndex = html.LastIndexOf("<p id='Message'") + 15;
                            int endIndex = html.LastIndexOf("</p></div>");
                            LastMessgae = html.Substring(startIndex + 1, endIndex - startIndex - 1);

                            //don't get spam messages
                            if (LastMessgae != CurrentMessage)
                            {
                                CurrentMessage = LastMessgae;

                                switch (CurrentMessage)
                                {
                                    case "CONNECT":
                                        rtbChat.AppendText("Someone is connect" + Environment.NewLine);
                                        break;
                                    case "DISCONNECT":
                                        rtbChat.AppendText("Someone is disconnect" + Environment.NewLine);
                                        break;
                                    default:
                                        rtbChat.AppendText(Decrypt(CurrentMessage, strKey) + Environment.NewLine);
                                        break;
                                }
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //1sec delay
                await Task.Delay(1000);
            }
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            //simple check for null messages
            if (string.IsNullOrWhiteSpace(rtbMessage.Text))
            {
                return;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strHost);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string message = "message=" + Encrypt(strUsername + ": " + rtbMessage.Text, strKey); // The message that the client wants to send
                string postData = message + "&key=" + strServerKey; // Add the key to the request data
                byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = data.Length;
                System.IO.Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            rtbMessage.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Refresh everything and clear rtbChat
            rtbChat.Clear();
            rtbChat.Refresh();
            rtbMessage.Refresh();
            rtbChat.AppendText("Chat was cleared for you." + Environment.NewLine);
        }

        private void rtbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            //check if user press enter in rtbmessage
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }
    }
}
