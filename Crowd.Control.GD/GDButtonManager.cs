// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Crowd.Control.GD
{
    public class GDButtonManager
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, Keys wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public static void DoAction(GDButtons actionToDo, Process gdProcess)
        {
            var window = FindWindowEx(FindWindow("GeometryDash", null), IntPtr.Zero, "Edit", null);

            switch (actionToDo)
            {
                case GDButtons.Retry:
                    Program.SetForegroundWindow(gdProcess.MainWindowHandle);
                    Thread.Sleep(10000);
                    SendMessage(window, 0x000c, 0, " key");
                    PostMessage(window, 0x0100, Keys.Escape, IntPtr.Zero);
                    Click(GDButtonsLocation.Retry);

                    break;

                case GDButtons.Practice:
                    Program.SetForegroundWindow(gdProcess.MainWindowHandle);
                    Thread.Sleep(10000);
                    SendMessage(window, 0x000c, 0, " key");
                    PostMessage(window, 0x0100, Keys.Escape, IntPtr.Zero);
                    Click(GDButtonsLocation.Practice);

                    break;

                case GDButtons.Jump:
                    Click(changePosition: false);

                    break;
            }

            void Click(MousePoint position = new MousePoint(), bool changePosition = true)
            {
                if (changePosition)
                    CursorControl.SetCursorPosition(position);

                CursorControl.MouseEvent(MouseEventFlags.LeftDown);
                CursorControl.MouseEvent(MouseEventFlags.LeftUp);
            }
        }
    }

    public enum GDButtons
    {
        Retry,
        Practice,
        Jump
    }

    public static class GDButtonsLocation
    {
        public static MousePoint Retry = new MousePoint(1384, 646);

        public static MousePoint Practice = new MousePoint(534, 651);
    }
}
