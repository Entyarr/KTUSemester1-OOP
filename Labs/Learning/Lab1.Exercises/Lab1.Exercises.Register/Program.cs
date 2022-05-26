using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] point = {1, 2, 3, 4, 5, 1};
            int count = 0;
            permute(point, 1, point.Length - 1, ref count);
            Console.WriteLine("buvo eiluciu " + count);
            Console.ReadKey();
        }

        static void permute(int[] point, int i, int n, ref int count)
        {
            if (i == n)
            {
                for (int m = 0; m < point.Length; m++)
                {
                    Console.Write(point[m] + " ");
                }
                count++;

                Console.WriteLine();
            }
            else
            {
                for (int j = i; j < n; j++)
                {
                    swap(ref point[i], ref point[j]);
                    permute(point, i + 1, n, ref count);
                    swap(ref point[i], ref point[j]);

                }
            }
        }

        static void swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }
    }
}
