using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4.Exercises.Raides
{
    /** To count letters frequency */
    class LettersFrequency
    {
        private const int CMax = 1024;
        private int[] Frequency;  // Frequency of letters 
        public string line { get; set; }
        public LettersFrequency()
        {
            line = "";
            Frequency = new int[CMax];
            for (int i = 0; i < CMax; i++)
                Frequency[i] = 0;
        }
        public int Get(char character)
        {
            return Frequency[character];
        }
        //------------------------------------------------------------ 
        /** Counts repetition of letters. */
        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (('a' <= line[i] && line[i] <= 'z') ||
                    ('A' <= line[i] && line[i] <= 'Z'))
                    Frequency[line[i]]++;
            }
        }

        public char FindCommon(LettersFrequency letters)
        {
            char g = 'g';
            int max = 0;
            for(char ch = 'a'; ch <= 'z'; ch++)
            {
                if (max < Get(ch))
                {
                    max = Get(ch);
                    g = ch;

                }
            }
            return g;

        }
    }
    //------------------------------------------------------------
}
