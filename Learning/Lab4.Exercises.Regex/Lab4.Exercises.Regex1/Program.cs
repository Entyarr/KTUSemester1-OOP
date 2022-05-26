using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Regex1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            string punctuation = "[\\s,.;:!?()\\-]+";
            Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd,punctuation));
            Console.ReadKey();
        }
    }
}
