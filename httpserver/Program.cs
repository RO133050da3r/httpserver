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
            Logging.WriteInfo("Server started"); // skriver at serveren er startet til event log

            HttpServer HS = new HttpServer(); // laver et nyt objekt af server class
            HS.Run(); // kør funktion til server

            Console.ReadKey(); // gør at man kan læse konsollen
        }

    }
}
