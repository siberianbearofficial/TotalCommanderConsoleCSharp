using System;

namespace TotalCommanderConsoleCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.defaultForegroundColor = ConsoleColor.Cyan;
            UserInterface.defaultBackgroundColor = ConsoleColor.Black;
            UserInterface.PrepareConsole();
            CommandReader.Start();
        }
    }
}
