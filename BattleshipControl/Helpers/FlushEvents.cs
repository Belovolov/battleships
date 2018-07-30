using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;

namespace BattleshipControl.Helpers 
{
    /// <summary>
    /// Class that provides a static method for flushing mouse events
    /// It is used to surpass a queueing of mouse clicks even when the control is disabled
    /// Author: Rod Stephens
    /// Link: http://csharphelper.com/blog/2015/08/flush-click-events-in-c/#comment-202780
    /// Date: 26/08/2015
    /// </summary>
    class EventHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PeekMessage(out NativeMessage message,
            IntPtr handle, uint filterMin, uint filterMax, uint flags);
        private const UInt32 WM_MOUSEFIRST = 0x0200;
        private const UInt32 WM_MOUSELAST = 0x020D;
        public const int PM_REMOVE = 0x0001;

        // Flush all pending mouse events.
        public static void FlushMouseMessages()
        {
            NativeMessage msg;
            // Repeat until PeekMessage returns false.
            while (PeekMessage(out msg, IntPtr.Zero,
                WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE));
        }
    }
    
}
