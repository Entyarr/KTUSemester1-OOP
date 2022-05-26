using System;

namespace Introduction.If.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            int numberCount;
            int inLine;

            Console.WriteLine("Įveskite kiek norite skaičių:");
            numberCount = int.Parse(Console.ReadLine());

            Console.WriteLine("ĮVeskite kiek norite skaičių vienoje eilutėje:");
            inLine = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = (char)Console.Read();
            Console.WriteLine();

            for (int i = 1; i < numberCount; i++)
            {
                if (i % inLine == 0)
                    Console.WriteLine(character);
                else
                    Console.Write(character);
            }

            Console.ReadKey();
        }
    }
}
