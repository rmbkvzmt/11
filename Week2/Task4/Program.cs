using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string NewFile = Console.ReadLine(); // ввод файла
            string path = @"D:\Test"; // исходное местоположение
            string path1 = @"D:\C#"; // будущее местоположение
            string NewFile1 = Path.Combine(path, NewFile); // объединяет строку в путь
            string NewFile2 = Path.Combine(path1, NewFile); 
            FileStream fstr = File.Create(NewFile1); 
            fstr.Close(); 
            File.Copy(NewFile1, NewFile2, true); 
            File.Delete(NewFile1); 
        }
    }
}
