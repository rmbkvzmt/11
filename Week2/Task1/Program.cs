using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText(@"D:\PP2\Week2\Task1\input.txt");// местоположение нужного файла
            string str1 = new string(str.Reverse().ToArray());// присвоение для str1 перевернутое значение str при помощи reverse
            //но из-за того что у класса string нет конструктора, принимающего IEnumerable<char>, ToArray преобразовывает последовательность в массив
            if (str == str1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");              
            }
        }
    }
}