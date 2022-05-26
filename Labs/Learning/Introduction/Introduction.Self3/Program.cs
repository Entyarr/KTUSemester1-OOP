using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Self3
{
    class Program
    {
        static void Main(string[] args)
        {
            double first, second;
            char operation;
            double result = 0;

            Console.WriteLine("Įveskitę pirmąjį skaičių:");
            first = double.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite kokią operaciją norit padaryti ( '+' '-' '*' '/')");
            operation = (char)Console.Read();
            Console.ReadLine();

            Console.WriteLine("Įveskitę antrąjį skaičių:");
            second = double.Parse(Console.ReadLine());



            if (operation == '+')
                result = first + second;
            else if (operation == '-')
                result = first - second;
            else if (operation == '*')
                result = first * second;
            else if (operation == '/')
                result = first / second;
            else
            {
                Console.WriteLine("Klaidinga operacija");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("{0} {1} {2} = {3}", first, operation, second, result);

            Console.ReadKey();
        }
    }
}
