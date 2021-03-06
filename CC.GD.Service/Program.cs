﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using CC.GD.Service.Actions;

namespace CC.GD.Service
{
    public static class Program
    {
        private static Process gdProcess;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public static void Main(string[] args)
        {
            getGdProcess(args);

            var store = new ActionsStore();

            Console.WriteLine("Which action do you want to perform?");

            foreach (var plugin in store.AvailablePlugins)
            {
                var pActions = plugin.GetActions();
                List<CCAction> actions = new List<CCAction>();

                foreach (var action in store.AvailableActions)
                {
                    if (pActions.Any(a => a.Name == action.Name))
                        actions.Add(action);
                }

                foreach (var action in actions)
                    Console.WriteLine($"{action.Id}) {action.Name} ({action.Price}) [{plugin.Name}]");
            }

            while (true)
            {
                int.TryParse(Console.ReadLine(), out var result);
                var action = Activator.CreateInstance(store.AvailableActions.FirstOrDefault(a => a.Id == result)?.GetType()) as CCAction;

                if (gdProcess != null) SetForegroundWindow(gdProcess.MainWindowHandle);

                Thread.Sleep(TimeSpan.FromSeconds(5));

                action?.Start();
            }
        }

        private static void getGdProcess(string[] args)
        {
            if (args.Length > 0 && args[0] == "--opengd")
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\GeometryDash.exe")
                {
                    WorkingDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash",
                    UseShellExecute = false
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
                }
            }
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
