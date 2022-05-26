using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Self2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double functionResult=0;

            Console.WriteLine("Įveskite x reikšmę:");
            x = double.Parse(Console.ReadLine());

            if(x >= -4 && x <= 0)
            {
                functionResult = Math.Cos(x);           //cos x 
            }
            else
                if(x > 0 && x <= 4)
                 {
                functionResult = 1 / Math.Pow((x + 5), 3);
                 }
            else
            {
                functionResult = Math.Pow(Math.Pow(x, 2) + 1, 0.5);
            }


            //1/(x+5)3



            Console.WriteLine(" Reikšmė x = {0}, fx = {1}", x, functionResult);
            Console.ReadKey();
        }
    }
}
