using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParkAndRide_REST.Logic
{
    public  class ScriptLauncher
    {
        
        public static void runningScript(string pathToPython,string pathToScript)
        {
            //string args = "C:/Users/Daniel/source/repos/SCRIPT/webscraping.py";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pathToPython;
            start.Arguments = string.Format("{0}", pathToScript);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Process.Start(start);
        }
    }
}
