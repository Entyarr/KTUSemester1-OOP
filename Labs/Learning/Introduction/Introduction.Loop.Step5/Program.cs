using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 15;

            Console.WriteLine("Skaičiai nuo {0} iki {1}, jų kvadratai ir kubai:", a, b);
            for (int i = a; i < b; i++)
            {
                Console.WriteLine("{0}  {1}  {2}", i, i * i, i * i * i);
            }

            Console.WriteLine("Buvo suskaičiuota: {0} kartų.", b - a);

            Console.ReadKey();
        }
    }
}
