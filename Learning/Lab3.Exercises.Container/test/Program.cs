using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[16];

            arr[0] = "A";
            arr[1] = "H";
            arr[2] = "H";
            arr[3] = "A";
            arr[4] = "S";
            arr[5] = "D";
            arr[6] = "G";

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);

            }

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Equals("A"))
                {
                    arr[i].Remove("A");
                }

            }

            Console.ReadKey();

        }
    }
}
