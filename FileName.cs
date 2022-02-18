using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommanderConsoleCSharp
{
    public class FileName
    {
        public string fullName;
        public string name;
        public string shorted;
        public FileName(string gotName)
        {
            fullName = gotName;
            name = GetNameFromPath(gotName);
            shorted = GetShortedVariant(gotName);
        }
        private string GetNameFromPath(string got)
        {
            if (got.Contains(@"\"))
            {
                string[] got_splitted = got.Split(@"\");
                return got_splitted[got_splitted.Length - 1].Trim();
            }
            return got.Trim();
        }
        private string GetShortedVariant(string got)
        {
            if (got.Length > 41)
            {
                got = got.Substring(0, 35) + "..." + got.Substring(got.Length - 4, 4);
            }
            return got.Replace(@":\ref", @":\");
        }
        public static FileName[] BuildFileNames(string[] gotNames)
        {
            FileName[] builtFileNames = new FileName[gotNames.Length];
            for (int i = 0; i < gotNames.Length; i++)
            {
                builtFileNames[i] = new FileName(gotNames[i]);
            }
            return builtFileNames;
        }
    }
}
