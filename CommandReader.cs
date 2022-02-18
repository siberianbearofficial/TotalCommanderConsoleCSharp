using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommanderConsoleCSharp
{
    public class CommandReader
    {
        // Commands
        private const string CHANGE_DIR = "cd";
        private const string OPEN = "open";
        private const string EXIT = "exit";
        private const string CREATE_DIR = "crdir";
        private const string DELETE_DIR = "deldir";
        private const string YES = "y";
        private const string NO = "n";

        public static void Start()
        {
            Show();
            Update();
        }

        private static void Show()
        {
            List<FileName[]> fileNamesList = DirectoryManager.GetCurrentDirectories();
            UserInterface.PrintDirectories(fileNamesList[1]);
            UserInterface.PrintFiles(fileNamesList[0]);
            UserInterface.PrintCurrentDirectory(DirectoryManager.GetCurrentDirectory());
        }

        private static void ProcessCommand(string command)
        {
            string[] commandSplitted = command.Split(" ");
            if (commandSplitted.Length > 1) {
                ExecuteCommand(commandSplitted[0].ToLower(), new FileName(commandSplitted[1]));
            }
        }

        private static void ExecuteCommand(string commandType, FileName commandDetails)
        {
            switch (commandType)
            {
                case CHANGE_DIR:
                    {
                        DirectoryManager.ChangeDirectory(commandDetails);
                        Show();
                        break;
                    }
                case OPEN:
                    {
                        FileManager.OpenFile(commandDetails);
                        break;
                    }
                case EXIT:
                    {
                        Environment.Exit(0);
                        break;
                    }
                case CREATE_DIR:
                    {
                        DirectoryManager.CreateDirectory(commandDetails);
                        break;
                    }
                case DELETE_DIR:
                    {
                        DirectoryManager.DeleteDirectory(commandDetails);
                        break;
                    }
                case YES:
                    {
                        DirectoryManager.DeleteDirectory(commandDetails, true);
                        break;
                    }
                case NO:
                    {
                        break;
                    }
                default:
                    {
                        UserInterface.Log(TME.NO_SUCH_COMMAND_EXCEPTION);
                        break;
                    }
            }
        }
        private static void Update()
        {
            while (true)
            {
                UserInterface.PrepareForReading();
                ProcessCommand(Console.ReadLine());
            }
        }
    }
}
