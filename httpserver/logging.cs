using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace httpserver

{
    class Logging
    {
        const string Source = "Vores http server"; // navn på log
        const string sLog = "Application"; // type
        
        public static void WriteInfo(string message) // laver tjeck på om loggen eksistere
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }
            
            string machineName = "."; // this computer
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {
               
                log.WriteEntry(message, EventLogEntryType.Information); // skriver til loggen
                
            }
        }


    }
}
