using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win32Errors
{
    class Program
    {
        [DllImport("kernel32", EntryPoint = "OpenThread", SetLastError = true)]
        static extern IntPtr OpenThreadInternal(uint access, bool inheritHandle, int id);

        static IntPtr OpenThread(uint access, int id)
        {
            var handle = OpenThreadInternal(access, false, id);
            if (handle != IntPtr.Zero)
                return handle;
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            return IntPtr.Zero;
        }


        private const int SYNCHRONIZE = 0x00100000;

        static void Main(string[] args)
        {
            Console.Write("Enter thread ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var hThread = OpenThread(SYNCHRONIZE, id);
                Console.WriteLine("Opened handle successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }


            Console.ReadKey();
        }
    }
}
