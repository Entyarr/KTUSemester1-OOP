using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                Console.Write("{0} ", ch);
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
