using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Crowd.Control.GD
{
    public static class Program
    {
        private static Process gdProcess;

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--opengd")
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash\GeometryDash.exe")
                {
                    WorkingDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Geometry Dash",
                    UseShellExecute = false
                };

                gdProcess = Process.Start(processStartInfo);
                Console.WriteLine(gdProcess?.Id);
            }
            else
            {
                try
                {
                    gdProcess = Process.GetProcessesByName("GeometryDash")[0];
                    Console.WriteLine($"Hooked onto process: {gdProcess.Id} ({gdProcess.MainWindowTitle})");
                }
                catch
                {
                    MessageBox.Show("Could not find Geometry Dash, please open Geometry dash and relaunch this software.", "Process not found");
                }
            }

            gdProcess?.WaitForExit();
        }
    }
}
