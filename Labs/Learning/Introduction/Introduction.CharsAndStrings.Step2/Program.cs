using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                Console.WriteLine("{0} - {1}", ch, (int)ch);
            }
            Console.ReadKey();
        }
    }
}
