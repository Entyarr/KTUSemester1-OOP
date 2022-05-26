using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar, endChar;
            Console.WriteLine("Įveskite raidę raidžių intervalo pradžiai");
            startChar = Console.ReadLine()[0];
            Console.WriteLine("Įveskite raidę raidžių intervalo pabaigai");
            endChar = (char)Console.Read();
            for (char ch = startChar; ch <= endChar; ch++)
            {
                Console.WriteLine("{0} - {1}", ch, (int)ch);
            }
            Console.ReadKey();
        }
    }
}
