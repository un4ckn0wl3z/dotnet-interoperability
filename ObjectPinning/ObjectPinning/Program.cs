using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPinning
{
    class Program
    {

        [DllImport("SampleNativeDll")]
        static extern int SetData([MarshalAs(UnmanagedType.LPArray)] int[] data);

        [DllImport("SampleNativeDll")]
        static extern int DoCalc();



        static void Main(string[] args)
        {
            var data = Enumerable.Range(0, 10).Select(i => i + 1).ToArray();
            Console.WriteLine("SetData: " + SetData(data));
            Console.WriteLine("DoCalc: " + DoCalc());

            Console.WriteLine("Press any key to call GC.Collect()");
            Console.ReadLine();
            GC.Collect();

            Console.WriteLine("DoCalc: " + DoCalc());

            Console.ReadKey();
        }
    }
}
