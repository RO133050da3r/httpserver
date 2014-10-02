using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    public class HttpServer
    {
        /// <summary>
        /// Porten der opretter forbindelse
        /// </summary>
        public static readonly int DefaultPort = 8888; // åbner porten ud til browser
        private static readonly string RootCatalog = @"c:/temp/sometext.html"; // åbner filsti til root
        /// <summary>
        /// Run metode der starter streamen mellem browser og konsol
        /// </summary>
        public void Run() // metode navn
        {
            TcpListener serverSocket = new TcpListener(8888); // lytter på porten 8888
            serverSocket.Start(); // starter server socket
            TcpClient connectionSocket;
            while (true)
            {
            connectionSocket = serverSocket.AcceptTcpClient();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

                HandleRequest(ns);
                
            }
            connectionSocket.Close(); // lukker tcp client
            serverSocket.Stop(); // lukker tcp listener
        }

        public void HandleRequest(Stream ns)
        {
            StreamReader sr = new StreamReader(ns); // læser streams
            StreamWriter sw = new StreamWriter(ns); // skriver stream
            sw.AutoFlush = true; // enable automatic flushing

            // det er her at vi får svar.
            string s = sr.ReadLine(); // læser streamen
            if (s != null)
            {
               Console.WriteLine(s); // printer streamen normalt ud

            string[] words = s.Split(' '); // putter streamen i et array med mellemrum
            foreach (string word in words) // for hvert ord i collectionen
            {
                Console.WriteLine(word); // print ordet ud
            }

            string answer = "HTTP/1.0 200 OK\r\n\r\nHello World!"; // sender et http/1.0 ud
            sw.WriteLine(answer); // tager svar fra oven over og printer det til browseren
            Console.WriteLine(answer); // tager svar fra oven og printer det til console

            FileStream fs = File.OpenRead(RootCatalog); // tager filen og åbner den i dette tilfælde rootcatalog
            fs.CopyTo(sw.BaseStream); // tager file streamen og kopiere til basestream
            sw.BaseStream.Flush(); // flusher basestream
            sw.Flush(); // flusher streamwriter 
            }
            

            ns.Close(); // lukker streamen
        }

    }
}
