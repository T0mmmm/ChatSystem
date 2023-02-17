using System;
using System.Net;
using System.Windows.Forms;
using static Client.Files.Def.Var;

namespace Client.Menu.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            //check if the text are only eng letters and numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUsername.Text, @"^[a-zA-Z0-9 ]+$"))
            {
                txtUsername.Clear();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //simple checks on null text you can make it in one if with &&
            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                MessageBox.Show("Enter the host name (website url).\nThat the server side give you.", "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Enter any username.", "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtKey.Text.Length < 16)
            {
                MessageBox.Show("Enter a key for your text encryption.\nThe minimum key size are 16 symbols or letters.", "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtServerKey.Text))
            {
                MessageBox.Show("Enter a server key.", "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //set the vars
            strHost = txtHost.Text;
            strUsername = txtUsername.Text;
            strKey = txtKey.Text;
            strServerKey = txtServerKey.Text;

            //Simple Check if the host are full
            if (GetUserOnline() == GetLimitConnection())
            {
                MessageBox.Show("Host are full or down.", "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //open the chat (ChatControl)
            var myControl = new Client.Menu.Controls.ChatControl();
            pMain.Controls.Clear();
            pMain.Controls.Add(myControl);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //simple check to don't get - online user
            if (ConnectionWasSend == false)
            {
                return;
            }

            //sending request for disconnect
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strHost);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                string message = "message=" + "DISCONNECT"; // The message that the client want to send //same as connect method in chatControl
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
        }

        #region GetOnline - GetLimit

        private int GetLimitConnection()
        {
            //try to download strings from the url
            try
            {
                using (var client = new WebClient())
                {
                    string html = client.DownloadString(strHost);
                    int startIndex = html.IndexOf("<p style='text-align:center; color:white; id='LimitConnection' >Max Connections: ") + 81;
                    int endIndex = html.IndexOf("</p></body></html>");
                    return int.Parse(html.Substring(startIndex, endIndex - startIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }


        private int GetUserOnline()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string html = client.DownloadString(strHost);
                    int startIndex = html.LastIndexOf("<p style='text-align:center; color:white; id='UserOnline' >Online: ") + 67;
                    int endIndex = html.LastIndexOf("</p><p style='text-align:center; color:white; id='LimitConnection' >Max Connections: ");
                    return int.Parse(html.Substring(startIndex, endIndex - startIndex));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ChatSystemClient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        #endregion

    }
}
