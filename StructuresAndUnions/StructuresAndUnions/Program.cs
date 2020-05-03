using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StructuresAndUnions
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = Process.GetProcessesByName("calc1")[0];
            var hCalc = calc.MainWindowHandle;
            NativeFunctions.SetForegroundWindow(hCalc);

            INPUT[] inputs = new INPUT[1];
            //Thread.Sleep(2000);
            inputs[0].type = InputType.INPUT_KEYBOARD;
            inputs[0].ki.wVk = VirtualKeys.VK_0 + 3;
            NativeFunctions.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            //Thread.Sleep(2000);

            inputs[0].ki.wVk = VirtualKeys.VK_PLUS;
            NativeFunctions.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            //Thread.Sleep(2000);

            inputs[0].ki.wVk = VirtualKeys.VK_0 + 4;
            NativeFunctions.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            //Thread.Sleep(2000);

            inputs[0].ki.wVk = VirtualKeys.VK_ENTER;
            NativeFunctions.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            //Thread.Sleep(2000);


            Console.ReadKey();

        }
    }
}
