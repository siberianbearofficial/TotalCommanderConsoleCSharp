using System;

namespace TotalCommanderConsoleCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // FileManager.GetDirectories();
            UserInterface ui = new UserInterface(ConsoleColor.Green, ConsoleColor.Black);
            (new CommandReader(ui)).Start();
        }
    }
}
