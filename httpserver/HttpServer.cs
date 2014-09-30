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
        public static readonly int DefaultPort = 8888;
        private static readonly string RootCatalog = @"c:/temp/sometext.html";
        /// <summary>
        /// Run metode der starter streamen mellem browser og konsol
        /// </summary>
        public void Run()
        {
            TcpListener serverSocket = new TcpListener(8888);
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            // det er her at vi får svar.
            string s = sr.ReadLine();
            Console.WriteLine(s);

            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            string answer = "HTTP/1.0 200 OK\r\n\r\nHello World!";
            sw.WriteLine(answer);
            Console.WriteLine(answer);

            FileStream fs = File.OpenRead(RootCatalog);
            fs.CopyTo(sw.BaseStream);
            sw.BaseStream.Flush();
            sw.Flush();

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
    }
}
