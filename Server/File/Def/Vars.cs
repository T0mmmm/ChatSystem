using System.Collections.Concurrent;
using System.Net;

namespace Server.File.Def
{
    class Vars
    {
        public static HttpListener listener = new HttpListener();
        public static ConcurrentQueue<string> messages = new ConcurrentQueue<string>();

        public static bool shouldStop = true;
        public static bool Logs = false;
        public static int connectedClients = 0;
        public static int MaxConnections = 0;
        public static string Message = "";

        public static string SecretPassPhrase = "";
        public static string SecretText = "";
        public static string ClientSecretKey = "";
        public static string strinitVector = "";
    }
}
