using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace httpserver

{
    class Logging
    {        
        // her erklære vi vores log og vores loggingkilde
        const string Source = "Vores http server";
        const string sLog = "Application";
        
        // her opretter vi et event log
        public static void WriteInfo(string message)
        {
            // her fortæller vi systemet at hvis kilden til vores log ikke eksistere, skal den oprette en
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }
            
            string machineName = "."; // this computer
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {  
                //system skriver og sender en event/besked til vores logbog
                log.WriteEntry(message, EventLogEntryType.Information);
            }
        }

        // Det samme sker her, bare med en Error besked
        public static void WriteError(string message)
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }

            string machineName = "."; // this computer
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {
                log.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        // Det samme sker her, bare med en Warning besked
        public static void WriteWarning(string message)
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }

            string machineName = "."; // this computer
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {
                log.WriteEntry(message, EventLogEntryType.Warning);
            }
        }
    }
}
