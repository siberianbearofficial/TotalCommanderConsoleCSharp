using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommanderConsoleCSharp
{
    public class UserInterface
    {
        public static ConsoleColor defaultBackgroundColor;
        public static ConsoleColor defaultForegroundColor;

        private const string COMMAND_START = "command>> ";


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        public static void PrepareConsole()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;
            Console.BufferHeight = 40;
            Console.BufferWidth = 100;

            Console.BackgroundColor = defaultBackgroundColor;
            Console.ForegroundColor = defaultForegroundColor;
            Console.Clear();

            CreateTables();
        }
        private static void Print(string Text, int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Text);
        }

        public static void PrintDirectories(FileName[] dirNames)
        {
            PrintContent(dirNames, 2, 2, true);
        }

        public static void PrintFiles(FileName[] fileNames)
        {
            PrintContent(fileNames, 49, 2, false);
        }

        private static void PrintContent(FileName[] contentNames, int x, int y, bool flag)
        {
            if (contentNames == null) return;
            if (flag)
                ClearDirectoriesField();
            else
                ClearFilesField();
            int i = 0;
            foreach (FileName dirName in contentNames)
            {
                if (i >= 28) break;
                Print(dirName.shorted, x, y);
                y++; i++;
            }
        }

        public static void PrintCurrentDirectory(FileName currentDirectory)
        {
            ClearCurrentDirectoryField();
            Console.SetCursorPosition(2, 0);
            Console.Write(currentDirectory.shorted);
        }
        private static void ClearCurrentDirectoryField()
        {
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i < 42; i++) Console.Write("═");
        }

        public static void PrintFileContent(string[] contentLines)
        {
            List<string> contentLinesList = new();
            foreach (string line in contentLines)
            {
                string realline = line;
                while (realline.Length > 41)
                {
                    contentLinesList.Add(realline.Substring(0, 41));
                    realline = realline.Substring(42, realline.Length - 42);
                }
                contentLinesList.Add(realline);
            }
            ClearFilesField();
            int i = 0, x = 49, y = 2;
            foreach (string line in contentLinesList)
            {
                string realLine = line;
                if (i >= 28) break;
                Print(realLine, x, y);
                y++;
                i++;
            }
        }

        private static void ClearDirectoriesField()
        {
            int x = 2, y = 1;
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 43; j++)
                    Console.Write(" ");
                y++;
            }
        }

        private static void ClearFilesField()
        {
            int x = 48, y = 1;
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 43; j++)
                    Console.Write(" ");
                y++;
            }
        }

        public static void PrepareForReading()
        {
            Console.SetCursorPosition(0, 32);
            for (int i = 0; i < 90; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, 32);
            Console.Write(COMMAND_START);
        }

        private static void CreateTables()
        {
            CreateTable(0, 0, 45, 30);
            CreateTable(47, 0, 45, 30);
        }

        private static void CreateTable(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            Console.SetCursorPosition(x + width, y);
            Console.Write("╗");
            Console.SetCursorPosition(x + 1, y);
            for (int i = 0; i < width - 1; i++) {
                Console.Write("═");
            }
            for (int i = y + 1; i < y + height; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("║");
            }
            for (int i = y + 1; i < y + height; i++)
            {
                Console.SetCursorPosition(x + width, i);
                Console.Write("║");
            }
            Console.SetCursorPosition(x + 1, y + height);
            for (int i = 0; i < width - 1; i++)
            {
                Console.Write("═");
            }
            Console.SetCursorPosition(x, y + height);
            Console.Write("╚");
            Console.SetCursorPosition(x + width, y + height);
            Console.Write("╝");
        }
        public static void Log(int exception) {
            
            Log(new TME(exception).ToString());
        }

        public static void Log(string toPrint)
        {
            Print(toPrint, 0, 34);
        }
    }
}