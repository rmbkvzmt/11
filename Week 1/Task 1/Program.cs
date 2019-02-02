using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n ;
            n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];//array
            for (int i = 0; i < n; ++i)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            bool k = false;
            int cnt = 0;
            for (int i = 0; i < n; ++i) {
                k = false;
                if (a[i] <= 1) continue; //если член массива меньше или равен 1, то они не отпадают
                for (int j = 2; j <= a[i]/2; ++j)//prime
                    if (a[i]% j == 0) k = true;//изначально k=false, но если число не будет prime, то он будет равен true. После этого начнется вывод false
                if (!k) cnt++; //подсчет prime-ов
            }
            Console.WriteLine(cnt);
            for (int i = 0; i < n; ++i)
            {
                k = false;
                if (a[i] <= 1) continue; 
                for (int j = 2; j <= a[i] / 2; ++j)
                    if (a[i] % j == 0) k = true;
                if (!k) Console.Write(a[i] + "  ");
            }
        }
    }
}