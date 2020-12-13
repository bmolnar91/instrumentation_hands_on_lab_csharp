using System;
using System.Diagnostics;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog myLog = new EventLog("X", "localhost", "Demo");
            Trace.AutoFlush = true;
            EventLogTraceListener myListener = new EventLogTraceListener(myLog);
            Trace.WriteLine("This is a test");
        }
    }
}
