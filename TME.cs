using System.Collections.Generic;

namespace TotalCommanderConsoleCSharp
{
    public class TME
    {
        private int EXCEPTION_CODE = -1;
        private const int width = 41;

        // Exception codes:
        public const int NO_SUCH_COMMAND_EXCEPTION = 0;
        public const int DIRECTORY_SUCCESSFUL_CHANGED = 1;
        public const int DIRECTORY_DOES_NOT_EXIST = 2;
        public const int FILE_SUCCESSFUL_OPENED = 3;
        public const int FILE_OPEN_ERROR = 4;
        public const int FILE_DOES_NOT_EXIST = 5;
        public const int DIRECTORY_CREATION_ERROR = 6;
        public const int DIRECTORY_SUCCESSFUL_CREATED = 7;
        public const int ASK_FOR_DIRECTORY_DELETION = 8;
        public const int DIRECTORY_DELETED_SUCCESSFUL = 9;
        public const int FILE_DELETED_SUCCESSFUL = 10;
        public const int DIRECTORY_DELETION_ERROR = 11;
        public const int FILE_DELETION_ERROR = 12;

        private Dictionary<int, string> ExceptionTexts = new Dictionary<int, string>
        {
            { NO_SUCH_COMMAND_EXCEPTION, "No command with such name exists." },
            { DIRECTORY_SUCCESSFUL_CHANGED, "Directory was successfully changed." },
            { DIRECTORY_DOES_NOT_EXIST, "Directory does not exist." },
            { FILE_SUCCESSFUL_OPENED, "File was opened." },
            { FILE_OPEN_ERROR, "Error occured while reading file." },
            { FILE_DOES_NOT_EXIST, "File does not exist." },
            { DIRECTORY_CREATION_ERROR, "Error occured while creating directory." },
            { DIRECTORY_SUCCESSFUL_CREATED, "Directory was successfully created." },
            { ASK_FOR_DIRECTORY_DELETION, "Do you want to delete this directory? It is irreversible (y/n)" },
            { DIRECTORY_DELETED_SUCCESSFUL, "Directory was deleted successfully" },
            { DIRECTORY_DELETION_ERROR, "Error occured while deleting directory" },
            { FILE_DELETED_SUCCESSFUL, "File was deleted successfully" },
            { FILE_DELETION_ERROR, "Error occured while deleting file" }
        };
        public TME(int exception)
        {
            if (ExceptionTexts.ContainsKey(exception))
            {
                EXCEPTION_CODE = exception;
            }
        }
        public override string ToString()
        {
            if (EXCEPTION_CODE < 0) return "";
            return AdaptToNessessaryWidth(ExceptionTexts[EXCEPTION_CODE]);
        }
        private string AdaptToNessessaryWidth(string got)
        {
            while (got.Length < width)
            {
                got += " ";
            }
            return got;
        }
    }
}
