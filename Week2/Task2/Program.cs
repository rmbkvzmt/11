using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static bool IsPrime(int ExpNum)//метод для проверки на prime
        {
            if (ExpNum == 1) return false;
            if (ExpNum == 2) return true;
            bool Booler = true;   
            for (int i = 2; i < ExpNum; ++i)
            {
                if (ExpNum % i == 0)   
                {
                    Booler = false;
                    break;
                }
            }
            return Booler; 
        }

        
        static void Main(string[] args)
        {
            FileStream FileStr = new FileStream(@"D:\PP2\Week2\Task2\input.txt", FileMode.Open, FileAccess.Read);//чтение нужного файла
            StreamReader str = new StreamReader(FileStr);
            string saver = str.ReadLine(); //сохранеине данных в строку
            string[] n = saver.Split(); // разбивание строки для предачи данных для дальнейшого массива
            int[] m = new int[n.Length];
            for (int i = 0; i < n.Length; i++)
            {
                m[i] = Convert.ToInt32(n[i]); // масиив с данными
            }
            string loc = @"D:\PP2\Week2\Task2\output.txt";
            File.Create(loc).Close();
            FileStream FileStr1 = new FileStream(loc, FileMode.Append, FileAccess.Write); //переписование данных в этот файл
            StreamWriter StrW = new StreamWriter(FileStr1);
            for (int i = 0; i < m.Length; i++)
            {
                if (IsPrime(m[i]) == true)
                {
                    StrW.Write(m[i] + " "); // нужные prime числа
                }

            }
            StrW.Close();
            FileStr.Close();
            str.Close();
        }
    }
}