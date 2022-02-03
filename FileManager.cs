using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommanderConsoleCSharp
{
    public class FileManager
    {
        public string currentDirectory;

        public FileManager()
        {
            currentDirectory = Directory.GetCurrentDirectory();
        }
        public string[] GetDirectories(string path)
        {
            if (path == "..")
            {
                var currentDirectoryList = currentDirectory.Split(@"\");
                if (currentDirectoryList.Length >= 2)
                {
                    currentDirectory = "";
                    for (int i = 0; i < currentDirectoryList.Length - 1; i++)
                    {
                        currentDirectory += currentDirectoryList[i] + @"\";
                    }
                    currentDirectory = currentDirectory.Remove(currentDirectory.Length - 1);
                    if (!currentDirectory.Contains(@"\")) currentDirectory += @"\";
                    path = currentDirectory;
                }
                else
                {
                    path = currentDirectory;
                }
            }
            else if (!path.Contains(":"))
            {
                path = currentDirectory + @"\" + path;
            }
            path = path.Replace(@"\\", @"\");

            if (Directory.Exists(path))
            {
                currentDirectory = path;
                Console.WriteLine("Directory was successfully changed.                     ");
                return GetCurrentDirectories();
            } else
            {
                Console.WriteLine("Directory does not exist.                               ");
                return null;
            }
        }
        public string[] GetCurrentDirectories()
        {
            return Directory.GetDirectories(currentDirectory);
        }

        public static void GetFiles()
        {
            string path = @"C:\users";
            var dirs = Directory.GetFiles(path);
            int line = 0;
            UserInterface ui = new UserInterface();
            foreach (var dir in dirs)
            {
                // ui.print(dir, 0, line);
                line++;
            }


            Directory.Delete(path);  // Удаление директории
            if (Directory.Exists(path))
            {
                // Если директория существует
            }
            Directory.Move(path, path);  // Копирование директории (без удаления из предыдущего местоположения)
            Directory.GetCreationTime(path);  // Получить время создания директории
        }

        public string ReadFile()
        {
            string ready = "";
            string path = @"C:\test\1.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        ready += s;
                    }
                }
            }
            return ready;
        }
    }
}
