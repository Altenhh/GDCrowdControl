﻿// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Crowd.Control.GD
{
    public static class Program
    {
        private static Process gdProcess;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--opengd")
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\GeometryDash.exe")
                {
                    WorkingDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash",
                    UseShellExecute  = false
                };

                gdProcess = Process.Start(processStartInfo);

                // doesn't open immediately so we will have to wait a bit
                Thread.Sleep(TimeSpan.FromSeconds(10));

                Write($"Started process: {gdProcess?.Id} (Geometry Dash)");
            }
            else
            {
                try
                {
                    gdProcess = Process.GetProcessesByName("GeometryDash")[0];
                    Write($"Hooked onto process: {gdProcess.Id} ({gdProcess.MainWindowTitle})");
                }
                catch
                {
                    Write("Failed to hook onto process", ConsoleColor.Red);
                    MessageBox.Show("Could not find Geometry Dash, please open Geometry dash and relaunch this software.", "Process not found");
                }
            }

            Console.WriteLine("Which action do you want to perform?");
            Console.WriteLine("1) Practice");
            Console.WriteLine("2) Retry");
            Console.WriteLine("3) Jump");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var result);

                SetForegroundWindow(gdProcess.MainWindowHandle);
                Thread.Sleep(TimeSpan.FromSeconds(5));

                switch (result)
                {
                    case 1:
                        GDButtonManager.DoAction(GDButtons.Practice, gdProcess);

                        break;

                    case 2:
                        GDButtonManager.DoAction(GDButtons.Retry, gdProcess);

                        break;

                    case 3:
                        GDButtonManager.DoAction(GDButtons.Jump, gdProcess);

                        break;
                }
            }

            gdProcess?.WaitForExit();
        }

        public static void Write(string message, ConsoleColor col = ConsoleColor.Gray)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(DateTime.Now.ToLongTimeString().PadRight(12));

            Console.ForegroundColor = col;
            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
