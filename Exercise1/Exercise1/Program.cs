using System;
using System.Diagnostics;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string source = "Demo";
            const string machineName = "DESKTOP-6V59FHL";
            const string logName = "Application";

            if (!EventLog.SourceExists(source, machineName))
            {
                EventSourceCreationData mySourceData = new EventSourceCreationData(source, logName);
                EventLog.CreateEventSource(mySourceData);
            }

            EventLog logDemo = new EventLog(logName, machineName, source);
            logDemo.WriteEntry("Event written to Application Log",
                                EventLogEntryType.Information,
                                234,
                                Convert.ToInt16(3));
        }
    }
}
