using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Server.File.Def.Encryption;
using static Server.File.Def.Vars;

namespace Server.File.Def
{
    class Server
    {

        public static void RunHost()
        {
            Console.WriteLine("Do you want to receive logs of connections, disconnections time and messages that are was send?");
            Console.WriteLine("If you enter 'Y' you will be receive the logs in the console, 'N' for not receiving.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n$: ");
            Console.ForegroundColor = ConsoleColor.White;

            if (Console.ReadLine().ToLower() == "y")
            {
                Logs = true;
            }
            else { Logs = false; }

            Console.Clear();

            //seting the limit
            Console.WriteLine("Enter the limit of users that will be connected to the chat.");
            Console.WriteLine("If you leave it blank the max will be 2 users.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n$: ");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                MaxConnections = int.Parse(Console.ReadLine());
            }
            catch { MaxConnections = 2; }

            Console.Clear();

            #region start localhost and gen keys

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Remember that you have stop command that will close everything");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("===================================================================================\n\n");

            //starting listener
            listener.Prefixes.Add("http://localhost:8080/Chat/");
            listener.Start();

            Console.WriteLine("Starting local host...");
            Console.Write($"Listening on ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"http://localhost:8080/Chat/");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("\n\nGenerate SecretPassPhrase, SecretText...");

            //Gen keys
            SecretPassPhrase = GenerateText(15);
            SecretText = GenerateText(15);

            Console.Write("Server key for the clients: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Encrypt(SecretText, SecretPassPhrase) + "\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("===================================================================================\n\n");

            #endregion

            //starting async task
            Task.Run(() => ChatServer());

            //check for commands that enters in console
            back:
            switch (Console.ReadLine().ToLower())
            {
                case "stop":
                    Console.Clear();

                    //Stop the while
                    shouldStop = false;

                    //stop and close the localhost
                    listener.Stop();
                    listener.Close();

                    break;
                default:
                    Console.WriteLine("Command not found!");
                    goto back;
            }
        }

        #region Main Chat func

        private static void ChatServer()
        {
            while (shouldStop)
            {
                //set the vars 
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                try
                {
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            HandlePostRequest(request, response);
                            break;
                        default:
                            HandleGetRequest(response);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private static void HandlePostRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            //getting the message from the client and set the vars 
            using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                string[] data = reader.ReadToEnd().Split('&');

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].StartsWith("key="))
                    {
                        ClientSecretKey = data[i].Substring(4);
                    }
                    else if (data[i].StartsWith("message="))
                    {
                        Message = data[i].Substring(8);
                    }
                }
            }

            //Checking if the send correct key from the client
            if (Decrypt(ClientSecretKey, SecretPassPhrase) == SecretText)
            {

                //Checking if user connected or disconnect
                if (Message == "CONNECT")
                {
                    connectedClients++;
                    if (Logs == true)
                    {
                        Console.Write("Someone is connected to your server [ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(DateTime.Now);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ]\n");
                    }
                }

                if (Message == "DISCONNECT")
                {
                    connectedClients--;
                    if (Logs == true)
                    {
                        Console.Write("Someone is disconnected from your server [ ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(DateTime.Now);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ]\n");
                    }
                }

                //Check if the messae are not null
                if (!string.IsNullOrWhiteSpace(Message))
                {
                    //add a message
                    messages.Enqueue(Message);

                    if (Logs == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Message was received ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(DateTime.Now);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ]\n");
                    }

                    //send response to the client
                    byte[] buffers = Encoding.UTF8.GetBytes(Message);
                    response.ContentLength64 = buffers.Length;
                    using (Stream output = response.OutputStream)
                    {
                        output.Write(buffers, 0, buffers.Length);
                    }

                    response.Close();
                }
            }
        }

        private static void HandleGetRequest(HttpListenerResponse response)
        {
            //simple html code for the website
            string html = "<html><head>";
            html += "<style>body{background-color:rgb(" + 88 + "," + 81 + "," + 219 + ");}</style>";
            html += "<h1 style='text-align:center; color:white;'>Chat Messages</h1>";
            html += "<div style='background: linear-gradient(to bottom, #00b7ff 0%, #c8ff00 100%); border-radius: 10px; box-shadow: 0px 0px 10px 5px #888888; height: 500px; width: 500px; overflow-y:scroll; text-align:center; margin:0 auto;'>";

            //display all messages
            foreach (string m in messages)
            {
                html += "<p id='Message'>" + m + "</p>";
            }

            html += "</div>";

            //add the label to display the number of online users
            html += "<p style='text-align:center; color:white; id='UserOnline' >Online: " + connectedClients.ToString() + "</p>";

            //add the label to display the maximum number of connections
            html += "<p style='text-align:center; color:white; id='LimitConnection' >Max Connections: " + MaxConnections.ToString() + "</p>";
            html += "</body></html>";


            //response
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
            response.ContentLength64 = buffer.Length;
            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }

        }


        #endregion

    }
}
