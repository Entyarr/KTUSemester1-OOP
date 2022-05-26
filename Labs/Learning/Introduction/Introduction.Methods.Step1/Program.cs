using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Methods.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = Convert.ToChar(Console.Read());

            Program program = new Program();
            program.Display(character);

            Console.ReadKey();
        }

        void Display(char characterToDisplay)
        {
            for (int i = 1; i < 51; i++)
			{
                if(i % 5 == 0)
                    Console.WriteLine(characterToDisplay);
                else
                    Console.Write(characterToDisplay);
            Console.WriteLine("");
			} 
        }
    }
}
