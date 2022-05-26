using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            Console.WriteLine("Įveskitę sveikąjį skaičių, nuo kurio bus pradedama skaičiuot:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskitę didesnį sveikąjį skaičių, iki kurio bus skaičiuojama:");
            b = int.Parse(Console.ReadLine());

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
