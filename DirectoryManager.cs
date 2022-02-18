using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommanderConsoleCSharp
{
    public class DirectoryManager
    {
        public static List<FileName[]> GetDirectories(string path)
        {
            path = GetFullPath(path);
            if (Directory.Exists(path))
            {
                Directory.SetCurrentDirectory(path);
                UserInterface.Log(TME.DIRECTORY_SUCCESSFUL_CHANGED);
                return GetDirectoriesAndFiles();
            }
            else
            {
                UserInterface.Log(TME.DIRECTORY_DOES_NOT_EXIST);
                return null;
            }
        }
        public static List<FileName[]> GetCurrentDirectories()
        {
            return GetDirectories(Directory.GetCurrentDirectory());
        }
        public static FileName GetCurrentDirectory()
        {
            return new FileName(Directory.GetCurrentDirectory());
        }
        public static void ChangeDirectory(FileName dirName)
        {
            string dirPath = GetFullPath(dirName.fullName);
            UserInterface.Log(dirPath); return;
            if (Directory.Exists(dirPath))
            {
                Directory.SetCurrentDirectory(dirPath);
                UserInterface.Log(TME.DIRECTORY_SUCCESSFUL_CHANGED);
            } else
            {
                UserInterface.Log(TME.DIRECTORY_DOES_NOT_EXIST);
            }
        }
        public static void CreateDirectory(FileName dirName)
        {
            try
            {
                Directory.CreateDirectory(GetFullPath(dirName.fullName));
                UserInterface.Log(TME.DIRECTORY_SUCCESSFUL_CREATED);
            } catch (Exception)
            {
                UserInterface.Log(TME.DIRECTORY_CREATION_ERROR);
            }
        }
        public static void DeleteDirectory(FileName dirName)
        {
            DeleteDirectory(dirName, true);
        }
        public static void DeleteDirectory(FileName dirName, bool needConfirmation)
        {
            string dirPath = GetFullPath(dirName.fullName);
            if (Directory.Exists(dirPath))
            {
                if (Directory.GetFiles(dirPath).Length > 0 && needConfirmation)
                {
                    UserInterface.Log(TME.ASK_FOR_DIRECTORY_DELETION);
                    return;
                } else
                {
                    try
                    {
                        Directory.Delete(dirPath);
                        UserInterface.Log(TME.DIRECTORY_DELETED_SUCCESSFUL);
                    } catch (Exception)
                    {
                        UserInterface.Log(TME.DIRECTORY_DELETION_ERROR);
                    }
                }
            } else
            {
                UserInterface.Log(TME.DIRECTORY_DOES_NOT_EXIST);
            }
        }
        public static string GetFullPath(string path)
        {
            if (!path.Contains(":"))
            {
                path = Directory.GetCurrentDirectory() + @"\" + path;
            }
            return path;
        }
        public static List<FileName[]> GetDirectoriesAndFiles()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            List<FileName[]> dirFiles = new List<FileName[]>();
            dirFiles.Add(FileName.BuildFileNames(Directory.GetFiles(currentDirectory)));
            dirFiles.Add(FileName.BuildFileNames(Directory.GetDirectories(currentDirectory)));
            return dirFiles;
        }
    }
}
