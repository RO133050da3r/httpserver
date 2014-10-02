using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    class Program
    {
        private const string CRLF = "\r\n"; 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello http server");

            HttpServer HS = new HttpServer();
            HS.Run();

            Console.ReadKey();
        }

    }
}
