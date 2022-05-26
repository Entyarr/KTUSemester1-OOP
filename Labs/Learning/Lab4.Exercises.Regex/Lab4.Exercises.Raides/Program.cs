using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Raides
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);

            char ch = letters.FindCommon(letters);
            Console.WriteLine(ch);
            Console.WriteLine(letters.line);

            Console.WriteLine(letters.Get('Ą'));

                 

            InOut.PrintRepetitions(CFr, letters);

            Console.ReadKey();
        }
    }
}
