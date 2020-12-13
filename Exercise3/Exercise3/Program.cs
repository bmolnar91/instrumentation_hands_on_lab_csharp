using System;
using System.Diagnostics;
using System.Timers;

namespace Exercise3
{
    class Program
    {
        static PerformanceCounter HeapCounter = null;
        static PerformanceCounter ExceptionCounter = null;
        static Timer DemoTimer;

        static void Main(string[] args)
        {
            DemoTimer = new Timer(3000);
            DemoTimer.Elapsed += new ElapsedEventHandler(OnTick);
            DemoTimer.Enabled = true;

            HeapCounter = new PerformanceCounter(".NET CLR Memory", "# of Bytes in all Heaps");
            HeapCounter.InstanceName = "_Global_";

            ExceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceptions thrown");
            ExceptionCounter.InstanceName = "_Global_";

            Console.WriteLine("Press [Enter] to Quit Program");
        }

        static void OnTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("# of Bytes in all Heaps: " + HeapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions thrown : " + ExceptionCounter.NextValue().ToString());
        }
    }
}
