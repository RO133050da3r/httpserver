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

        /// <summary>
        /// Run metode der starter streamen mellem browser og konsol
        /// </summary>
        public void Run()
        {
            TcpListener serverSocket = new TcpListener(65080);
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
            Console.WriteLine(sr.ReadLine());

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
        private static readonly string RootCatalog = "c:/temp";
    }
}
