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
        
        public string GetFullPath(string got)
        {
            string currentDirectory = this.currentDirectory;
            if (got.Contains(".."))
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
                    got = currentDirectory;
                }
                else
                {
                    got = currentDirectory;
                }
            }
            else if (got == "")
            {
                got = currentDirectory;
            }
            else if (!got.Contains(":"))
            {
                got = currentDirectory + @"\" + got;
            }
            got = got.Replace(@"\\", @"\");
            return got;
        }
        public string ProcessName(string got)
        {
            if (got.Contains(@"\"))
            {
                string[] got_splitted = got.Split(@"\");
                return got_splitted[got_splitted.Length - 1].Trim();
            } else
            {
                return got.Trim();
            }
        }
        public List<string[]> GetCurrentDirectories()
        {
            List<string[]> dirFiles = new List<string[]>();
            dirFiles.Add(ProcessNames(Directory.GetFiles(currentDirectory)));
            dirFiles.Add(Directory.GetDirectories(currentDirectory));
            return dirFiles;
        }

        private string[] ProcessNames(string[] got)
        {
            string[] processed = new string[got.Length];
            for (int i = 0; i < got.Length; i++)
            {
                processed[i] = ProcessName(got[i]);
            }
            return processed;
        }

        public void CreateDirectory(string dirName)
        {
            try
            {
                Directory.CreateDirectory(currentDirectory + dirName);
                UserInterface.Log(TME.DIRECTORY_SUCCESSFUL_CREATED);
            }
            catch (Exception)
            {
                UserInterface.Log(TME.DIRECTORY_CREATION_ERROR);
            }
        }

        public void TryDeleteDirectory(string dirName)
        {
            string dirPath = currentDirectory + dirName;
            Console.WriteLine(dirPath);
            if (Directory.Exists(dirPath))
            {
                if (Directory.GetFiles(dirPath).Length == 0)
                {
                    try
                    {
                        DeleteDirectory(dirPath);
                        UserInterface.Log(TME.DIRECTORY_DELETED_SUCCESSFUL);
                    } catch (Exception e)
                    {
                        UserInterface.Log(TME.DIRECTORY_DELETION_ERROR);
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    UserInterface.Log(TME.ASK_FOR_DIRECTORY_DELETION);
                    lastDirectory = dirPath;
                }
            } else
            {
                UserInterface.Log(TME.DIRECTORY_DOES_NOT_EXIST);
            }
        }

        private void DeleteDirectory(string fullPath)
        {
            Directory.Delete(fullPath);
        }

        private string lastDirectory;

        public void DeleteLastDirectory()
        {
            try
            {
                Directory.Delete(lastDirectory);
                UserInterface.Log(TME.DIRECTORY_DELETED_SUCCESSFUL);
            }
            catch (Exception)
            {
                UserInterface.Log(TME.DIRECTORY_DELETION_ERROR);
            }
        }

        private static string[] ReadFile(string path)
        {
            List<string> fileContent = new();
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    fileContent.Add(s);
                }
            }
            return fileContent.ToArray();
        }

        public static void OpenFile(FileName fileName)
        {
            string filePath = DirectoryManager.GetFullPath(fileName.fullName);
            if (File.Exists(filePath))
            {
                try
                {
                    string[] fileContent = ReadFile(filePath);
                    UserInterface.PrintFileContent(fileContent);
                    UserInterface.Log(TME.FILE_SUCCESSFUL_OPENED);
                } catch (Exception)
                {
                    UserInterface.Log(TME.FILE_OPEN_ERROR);
                }
            } else
            {
                UserInterface.Log(TME.FILE_DOES_NOT_EXIST);
            }
        }
    }
}