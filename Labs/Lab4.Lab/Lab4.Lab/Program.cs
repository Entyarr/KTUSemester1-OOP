/*
2021 KTU 4th laboratory project
Project number: U4L-2 "Lygiavimas"
This entire program uses the data from text file "Knyga.txt" to find:
1. Words that start and end with a vowel and their occurances (List of up to 10).
2. Longest words and their occurances (List of up to 10).

*/
using System;
using System.Collections.Generic;

namespace Lab4.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Knyga.txt";
            const string CFr = "Rodikliai.txt";
            string punctuation = "[\\s,.;:!?()\\-]+"; ///Punctuation string formed as regex.

            List<Words> vowelWords = new List<Words>();
            List<Words> longWords = new List<Words>();
            InOut.ReadFile(CFd, punctuation, vowelWords, longWords);

            TaskUtils.Sort(vowelWords);
            TaskUtils.SortByLength(longWords);

            InOut.PrintToFile(CFr, vowelWords, longWords);
        }
    }
}
