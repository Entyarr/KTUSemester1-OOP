using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab4.Lab
{
    class TaskUtils
    {
        /// <summary>
        /// Creates a list of words that start and end with vowels
        /// </summary>
        /// <param name="parts">Single line from text file seperated into words</param>
        /// <param name="vowel">List of words that start and end with vowels</param>
        /// <returns>List of words that start and end with vowels</returns>
        public static List<Words> FindVowel(string[] parts, List<Words> vowel)
        {
            foreach (string word in parts)
            {
                if (FirstEqualLast(word))
                {
                    int index = InList(vowel, word);

                    if (index > -1)
                    {
                        vowel[index].Amount++;
                    }
                    else
                    {
                        Words newWord = new Words(word);
                        vowel.Add(newWord);
                    }
                }
            }
            return vowel;
        }

        /// <summary>
        /// Creates a list of 10 longest words
        /// </summary>
        /// <param name="parts">Single line from text file seperated into words</param>
        /// <param name="longWords">List of longest words</param>
        /// <returns>List of longest words</returns>
        public static List<Words> FindLongest(string[] parts, List<Words> longWords)
        {
            foreach (string word in parts)
            {

                int index = InList(longWords, word);
                if (index > -1)
                {
                    longWords[index].Amount++;
                }
                else if (longWords.Count < 10 && word != "")
                {
                    Words newWord = new Words(word);
                    longWords.Add(newWord);
                }
                else if(word != "")
                {
                    index = ShortestIndex(longWords);
                    Words newWord = new Words(word);
                    longWords[index] = newWord;
                }
            }
            return longWords;
        }

        /// <summary>
        /// Checks and finds what index given word is in
        /// </summary>
        /// <param name="list">List of words</param>
        /// <param name="check">Word to check in list</param>
        /// <returns>What index the word is in, if -1, the word is not in the list</returns>
        private static int InList(List<Words> list, string check)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Word.Equals(check))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds is te given word begins and ends with a vowel
        /// </summary>
        /// <param name="word">Given word to check</param>
        /// <returns>Whether the word begins and ends with a vowel</returns>
        private static bool FirstEqualLast(string word)
        {
            if (word.Length > 0) //checks if it's actually a word 
            {
                Match longMatched = Regex.Match(word, @"^([aąeęėiįouųūy]).*[aąeęėiįouųūy]$");
                Match oneLetterMatched = Regex.Match(word, @"^[aąeęėiįouųūy]$"); ///Finds if the word is a single vowel
                if (longMatched.Success)
                    return true;
                if (oneLetterMatched.Success)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Finds index, in which there is the shortest word in the list
        /// </summary>
        /// <param name="list">List of words</param>
        /// <returns>Shortest words index in list</returns>
        private static int ShortestIndex(List<Words> list)
        {
            int index = 0;
            Words shortest = list[index];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Word.Length < list[index].Word.Length) index = i;
            }

            return index;
        }

        /// <summary>
        /// Finds how many words there are in the whole list using "Amount" parameter.
        /// </summary>
        /// <param name="words">List of words</param>
        /// <returns>Amount of words</returns>
        public static int WordCount(List<Words> words)
        {
            int sum = 0;

            foreach (Words word in words) sum += word.Amount;

            return sum;

        }

        /// <summary>
        /// Selection sort, sorts by amount and alphabet order
        /// </summary>
        /// <param name="word">List of words to sort</param>
        public static void Sort(List<Words> word)
        {

            int hold; ///will hold i value to sort 
            Words temp; ///temp space for word
            for (int i = 0; i < word.Count - 1; i++)
            {
                hold = i;
                for (int j = i + 1; j < word.Count; j++)
                {
                    if (word[hold].CompareTo(word[j]) < 0) hold = j;
                }
                temp = word[hold];
                word[hold] = word[i];
                word[i] = temp;
            }

        }
        
        /// <summary>
        /// Selection sort, sorts by word length
        /// </summary>
        /// <param name="word">List of words</param>
        public static void SortByLength(List<Words> word)
        {
            int hold; ///will hold i value to sort 
            Words temp; ///temp space for word
            for (int i = 0; i < word.Count - 1; i++)
            {
                hold = i;
                for (int j = i + 1; j < word.Count; j++)
                {
                    if (word[hold].Word.Length < word[j].Word.Length) hold = j;
                }
                temp = word[hold];
                word[hold] = word[i];
                word[i] = temp;
            }
        }
    }
}
