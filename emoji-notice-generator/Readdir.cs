using System;
using System.Linq;

namespace emoji_notice_generator
{
    public class Readdir
    {
        public static System.IO.FileInfo[] readRawDir(string path)
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);

            return dirInfo.GetFiles();
        }

        public static string getFileNameOnly(System.IO.FileInfo finfo)
        {
            return finfo.Name.Substring(0, finfo.Name.Length - finfo.Extension.Length);
        }

        public static string[] readdir(string path)
        {
            System.IO.FileInfo[] rawDirList = readRawDir(path);

            return rawDirList.Select(getFileNameOnly).ToArray();
        }
    }
}