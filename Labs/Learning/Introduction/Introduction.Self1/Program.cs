using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Self1
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            int numAmount;
            int inLine;

            Console.WriteLine("Įveskite kiek skaičių norite spausdinti");
            numAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite, kiek skaičių norite eilutėje");
            inLine = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = (char)Console.Read();
            Console.WriteLine();

            for (int i = 0; i < numAmount; i++)
            {
                for (int j = 0; j < inLine; j++)
                {
                    Console.Write(character);
                    numAmount--;
                    if (numAmount == 0) break;

                }
                Console.WriteLine();
                if (numAmount == 0) break;
            }

            Console.ReadKey();
        }
    }
}
