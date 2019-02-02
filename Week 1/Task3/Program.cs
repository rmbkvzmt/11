using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine()); 
            int[] a = new int[n]; //создание массива        
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());    //ввод элементо массива     
            }
            
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " " + a[i] + " ");    //дубликаты  
            }

        }
    }
}
