using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Analize
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFa = "Analize.txt";
            const string vowels = "AEIYOUaeiyouĄąĘęĖėĮįŲųŪū";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            TaskUtils.Process(CFd, CFr, CFa, punctuation, vowels);
        }
    }
}
