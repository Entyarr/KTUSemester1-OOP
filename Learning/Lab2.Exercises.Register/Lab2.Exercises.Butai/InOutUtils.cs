using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2.Exercises.Butai
{
    class InOutUtils
    {
        public static Apartments ReadFile(string filename)
        {
            Apartments Apts = new Apartments();
            string[] Lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');

                int number = int.Parse(Values[0]);
                double area = double.Parse(Values[1]);
                int rooms = int.Parse(Values[2]);
                int price = int.Parse(Values[3]);
                int phonenumber = int.Parse(Values[4]);

                Apt apt = new Apt(number, area, rooms, price, phonenumber);
                if (!Apts.Contains(apt))
                {
                    Apts.Add(apt);
                }
            }
            return Apts;
        }

        /*public static void PrintApts(Apartments Apts)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("Numeris, Kambariai, Kaina, Aukstis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < Apts.AptsCount(); i++)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    Apts.GetApt(i).Number, Apts.GetApt(i).Rooms, Apts.GetApt(i).Price, Apts.GetApt(i).Floor);
            }
            Console.WriteLine(new string('-', 74));
        }*/

        public static void PrintApts(List<Apt> Apts)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,13} | {2,11} | {3,6} | {4,9} |",
                "Buto nr.", "Kambarių sk.", "Bendras pl.", "Kaina", "Tel. nr.");
            Console.WriteLine(new string('-', 74));
            foreach(Apt apt in Apts)
            {
                Console.WriteLine("| {0,8} | {1,13} | {2,11} | {3,6} | {4,9} |",
                    apt.Number, apt.Rooms, apt.Area, apt.Price, apt.PhoneNumber);
            }
            Console.WriteLine(new string('-', 74));
        }
    }
}
