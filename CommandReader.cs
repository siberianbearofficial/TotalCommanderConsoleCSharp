using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommanderConsoleCSharp
{
    public class CommandReader
    {
        private UserInterface ui;
        private FileManager fm;
        public CommandReader(UserInterface ui)
        {
            this.ui = ui;
            fm = new FileManager();
        }
        public void Start()
        {
            ui.PrintDirectories(fm.GetCurrentDirectories());
            ui.PrintCurrentDirectory(fm.currentDirectory);
            while (true)
            {
                ui.PrepareForReading();
                Console.Write("command>> ");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    Environment.Exit(0);
                } else if (command.Contains("cd"))
                {
                    ui.PrintDirectories(fm.GetDirectories(@command.Substring(3)));
                    ui.PrintCurrentDirectory(fm.currentDirectory);
                }
            }
        }
    }
}
