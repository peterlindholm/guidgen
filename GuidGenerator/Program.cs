using System;
using System.Runtime.InteropServices;

namespace GuidGenerator
{
    class Program
    {
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);

        [STAThread]
        static void Main(string[] args)
        {
            OpenClipboard(IntPtr.Zero);
            var guid = Guid.NewGuid().ToString("D");
            var ptr = Marshal.StringToHGlobalUni(guid);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
}
