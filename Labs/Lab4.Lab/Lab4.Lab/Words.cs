using System;

namespace Lab4.Lab
{
    class Words
    {
        /// <summary>
        /// A single word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// A single words occurances in the text file
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Creates a word
        /// </summary>
        /// <param name="word">Word</param>
        public Words(string word)
        {
            this.Word = word;
            this.Amount = 1;
        }

        /// <summary>
        /// Compares two words parameters
        /// </summary>
        /// <param name="other">Word to compare</param>
        /// <returns>Comparison results</returns>
        public int CompareTo(Words other)
        {
            int num;

            num = this.Amount.CompareTo(other.Amount);
            if (this.Amount == other.Amount)
            {
                num = this.Word.CompareTo(other.Word);
                num *= -1; ///Reverses the order in which it would sort
            }
            return num;
        }

    }
}
