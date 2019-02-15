using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirIn = new DirectoryInfo(@"D:\Test");
            PrintInfo(dirIn, 0);
        }

        static void PrintInfo(FileSystemInfo info, int a)
        {
            string str = new string(' ', a);
            Console.WriteLine(str + info.Name);

            if (info.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] n = ((DirectoryInfo)info).GetFileSystemInfos();
                for (int i = 0; i < n.Length; ++i)
                {
                    PrintInfo(n[i], a + 3);
                }
            }
        }
    }
}