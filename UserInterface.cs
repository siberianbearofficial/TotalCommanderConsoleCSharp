using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommanderConsoleCSharp
{
    public class UserInterface
    {
        private static ConsoleColor defaultBackgroundColor;
        private static ConsoleColor defaultForegroundColor;
        public UserInterface(ConsoleColor fg, ConsoleColor bg)
        {
            defaultBackgroundColor = bg;
            defaultForegroundColor = fg;
            PrepareConsole();
        }
        public UserInterface()
        {
            PrepareConsole();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        private void PrepareConsole()
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
        private void print(string Text, int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Text);
        }

        public void PrintDirectories(string[] lines)
        {
            if (lines == null) return;
            ClearDirectoriesField();
            int i = 0, x = 2, y = 2;
            foreach (string line in lines)
            {
                string realLine = line;
                if (i >= 28) break;
                if (line.Length > 41)
                {
                    realLine = line.Substring(0, 35) + "..." + line.Substring(line.Length - 4, 3);
                }
                realLine = realLine.Replace(@":\ref", @":\");
                print(realLine, x, y);
                y++;
                i++;
            }
        }

        public void PrintCurrentDirectory(string currentDirectory)
        {
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i < 42; i++) Console.Write("═");
            Console.SetCursorPosition(2, 0);
            if (currentDirectory.Length > 42)
            {
                currentDirectory = currentDirectory.Substring(0, 36) + "..." + currentDirectory.Substring(currentDirectory.Length - 4, 3);
            }
            currentDirectory = currentDirectory.Replace(@":\ref", @":\");
            Console.Write(currentDirectory);
        }

        private void ClearDirectoriesField()
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

        public void PrepareForReading()
        {
            Console.SetCursorPosition(0, 32);
            for (int i = 0; i < 90; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, 32);
        }

        private void CreateTables()
        {
            CreateTable(0, 0, 45, 30);
            CreateTable(47, 0, 45, 30);
        }

        private void CreateTable(int x, int y, int width, int height)
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
    }
}
