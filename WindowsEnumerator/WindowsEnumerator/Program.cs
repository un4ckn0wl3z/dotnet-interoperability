using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEnumerator
{
    class Program
    {

        delegate bool EnumWindowsProc(IntPtr hwnd, int lParam);

        [DllImport("user32")]
        static extern bool EnumWindows(EnumWindowsProc proc, int lParam);


        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32")]
        static extern bool IsWindowVisible(IntPtr hWnd);

        static void Main(string[] args)
        {
            var sb = new StringBuilder(256);
            EnumWindows((hwnd, lParam) =>
            {
                if (IsWindowVisible(hwnd))
                {
                    GetWindowText(hwnd, sb, 256);
                    if (sb.Length > 0)
                    {
                        Console.WriteLine("{0, 8:X}: {1}", hwnd.ToInt32(), sb.ToString());
                    }


                }

                return true;
            }, 0);

            Console.ReadLine();

        }
    }
}
