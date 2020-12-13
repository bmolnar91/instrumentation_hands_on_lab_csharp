using System;
using System.Diagnostics;
using System.Management;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToEventLog();
        }

        public static void WriteToEventLog()
        {
            WqlEventQuery demoQuery = new WqlEventQuery("__InstanceCreationEvent",
                          new TimeSpan(0, 0, 1),
                          "TargetInstance ISA \"Win32_Process\"");
            ManagementEventWatcher demoWatcher = new ManagementEventWatcher();
            demoWatcher.Query = demoQuery;
            demoWatcher.Options.Timeout = new TimeSpan(0, 0, 30);
            Console.WriteLine("Open an application to trigger an event.");
            ManagementBaseObject e = demoWatcher.WaitForNextEvent();
            EventLog demoLog = new EventLog("Chap10Demo");
            demoLog.Source = "Demo";
            String eventName = ((ManagementBaseObject)e["TargetInstance"])["Name"].ToString();
            Console.WriteLine(eventName);
            demoLog.WriteEntry(eventName, EventLogEntryType.Information);
            demoWatcher.Stop();
        }
    }
}
