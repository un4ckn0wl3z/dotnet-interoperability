using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInterop
{
    class Program
    {
        [DllImport("user32")]
        extern static bool MessageBeep(uint sound);

        static void Main(string[] args)
        {
            MessageBeep(0x10);
        }
    }
}
