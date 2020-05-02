using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoints
{
    class Program
    {
        [DllImport("kernel32", EntryPoint = "Sleep")]
        static extern void DoNothing(uint msec);

        //[DllImport("kernel32", ExactSpelling = true)]
        //[DllImport("kernel32")]
        [DllImport("kernel32", ExactSpelling = true)]
        static extern IntPtr CreateJobObjectW(IntPtr securityAttributes, string name);

        [DllImport("kernel32")]
        static extern IntPtr CloseHandle(IntPtr handle);

        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("waiting for a while...");
                DoNothing(2000);

                var newJob = CreateJobObjectW(IntPtr.Zero, "myjob");
                Console.WriteLine("Job handle: {0}", newJob);
                CloseHandle(newJob);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
