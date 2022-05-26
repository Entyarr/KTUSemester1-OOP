using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab4.Lab
{
    class InOut
    {
        /// <summary>
        /// Reads line from a file, sends the line to TaskUtils to find required words.
        /// </summary>
        /// <param name="fin">File name</param>
        /// <param name="punctuation">Punctuation to skip and split (already formed as regex)</param>
        /// <param name="vowels">List of words that start and end with vowels</param>
        /// <param name="longWords">List of longest words</param>
        public static void ReadFile(string fin, string punctuation, List<Words> vowels, List<Words> longWords)
        {
            using (StreamReader read = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    line = line.ToLower();
                    string[] parts = Regex.Split(line, punctuation);

                    vowels = TaskUtils.FindVowel(parts, vowels);
                    longWords = TaskUtils.FindLongest(parts, longWords);
                }
            }
        }

        /// <summary>
        /// Print given lists to a .txt file.
        /// </summary>
        /// <param name="fout">File name</param>
        /// <param name="vowelWords">List of words that start and end with vowels</param>
        /// <param name="longWords">List of longest words</param>
        public static void PrintToFile(string fout, List<Words> vowelWords, List<Words> longWords)
        {
            using (StreamWriter write = new StreamWriter(fout))
            {
                write.WriteLine("Žodžiai, kurių pradžia ir pabaiga yra balsė");
                write.WriteLine(new string('-', 17));
                write.WriteLine("Žodžiu kiekis: {0}", TaskUtils.WordCount(vowelWords));
                write.WriteLine(new string('-', 17));
                write.WriteLine("Kiekis | Žodis");
                write.WriteLine(new string('-', 17));
                for (int i = 0; i < 10 && i < vowelWords.Count; i++)
                {
                    write.WriteLine("{0,6} | {1} ", vowelWords[i].Amount, vowelWords[i].Word);
                }

                write.WriteLine("");
                write.WriteLine("");
                write.WriteLine("");

                write.WriteLine("Ilgiausi žodžiai");
                write.WriteLine(new string('-', 17));
                write.WriteLine("Kiekis | Žodis");
                write.WriteLine(new string('-', 17));
                foreach(Words word in longWords)
                {
                    write.WriteLine("{0,6} | {1} ", word.Amount, word.Word);
                }

            }
        }
    }
}
