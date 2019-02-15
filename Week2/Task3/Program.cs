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
            DirectoryInfo dirIn = new DirectoryInfo(@"D:\Test");//начальная папка
            PrintInfo(dirIn, 0);
        }

        static void PrintInfo(FileSystemInfo info, int a)// метод для вывода остальных папок
        {
            string str = new string(' ', a);
            Console.WriteLine(str + info.Name);

            if (info.GetType() == typeof(DirectoryInfo))// выражение типа
            {
                FileSystemInfo[] n = ((DirectoryInfo)info).GetFileSystemInfos();
                for (int i = 0; i < n.Length; ++i)
                {
                    PrintInfo(n[i], a + 5);//расстояние
                }
            }
        }
    }
}