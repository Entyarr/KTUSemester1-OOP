using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys1.txt";
            const string CFr = "Rezultatai1.txt";
            int No = InOut.LongestLine(CFd);
            InOut.RemoveLine(CFd, CFr, No);
            Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", No + 1);
            Console.ReadKey();
      
        }
    }
}
