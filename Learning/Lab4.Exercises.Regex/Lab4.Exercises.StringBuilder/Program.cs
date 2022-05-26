using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.StringBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            string punctuation = " .,!?:;()\t'";
            string name = "Arvydas";
            string surname = "Sabonis";
            TaskUtils.Process(CFd, CFr, punctuation, name, surname);
            Console.ReadKey();
        }
    }
}
