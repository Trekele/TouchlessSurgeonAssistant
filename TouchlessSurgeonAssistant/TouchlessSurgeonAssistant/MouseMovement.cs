using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TouchlessSurgeonAssistant
{
    class MouseMovement
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static void LeftMouseClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static Point GetPointFromFingers(Finger finger, Screen screen)
        {
            var xNormalized = screen.Intersect(finger, true, 1.0F).x;
            var yNormalized = screen.Intersect(finger, true, 1.0F).y;

            var x = (xNormalized * screen.WidthPixels);
            var y = screen.HeightPixels - (yNormalized * screen.HeightPixels);

            return new Point() { X = x, Y = y };
        }
    }
}
