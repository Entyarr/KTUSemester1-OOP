using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Self4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string lastCharacters;

            Console.WriteLine("Parašykite savo varda");
            name = Console.ReadLine();

            lastCharacters = name.Substring(name.Length - 1);
            char gender = char.Parse(lastCharacters);

            if (gender == 's')
            {
                lastCharacters = name.Substring(name.Length - 2);
                name = name.Remove(name.Length - 2);
                Console.Write("Labas, " + name);

                if (lastCharacters == "as")
                    Console.WriteLine("ai!");
                else if (lastCharacters == "is")
                    Console.WriteLine("i!");
                else if (lastCharacters == "ys")
                    Console.WriteLine("y!");
            }
            else
            {
                lastCharacters = name.Substring(name.Length - 1);
                name = name.Remove(name.Length - 1);
                Console.Write("Labas, " + name);

                if (lastCharacters == "a")
                    Console.WriteLine("a!");
                else if (lastCharacters == "ė")
                    Console.WriteLine("e!");
            }


            Console.ReadKey();
        }
    }
}
