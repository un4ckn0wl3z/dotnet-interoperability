using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter process ID: ");
            int pid = int.Parse(Console.ReadLine());
            var process = Process.GetProcessById(pid);
            bool is32bit = Is32BitProcess(process);
            Console.WriteLine("Process {0} {1} is 32 bit: {2}", process.ProcessName, pid, is32bit);
            Console.ReadKey();
        }

        [DllImport("kernel32")]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64);

        [StructLayout(LayoutKind.Sequential)]
        struct SystemInfo
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }


        [DllImport("kernel32")]
        static extern void GetNativeSystemInfo(out SystemInfo si);

        static bool Is32BitProcess(Process process)
        {
            SystemInfo si;
            GetNativeSystemInfo(out si);
            bool isWow64Proc;
            IsWow64Process(process.Handle, out isWow64Proc);
            return si.wProcessorArchitecture == 0 ||
                   si.wProcessorArchitecture == 9 &&
                   isWow64Proc;
        }
    }
}
