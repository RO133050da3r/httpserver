using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    internal class Program
    {
        private const string CRLF = "\r\n";

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello http server");

            HttpServer HS = new HttpServer();
            HS.Run();

            Console.ReadKey();
        }

    }
}
