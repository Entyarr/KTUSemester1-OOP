/*
2021 KTU 3rd laboratory project
Project number: U3-2 "Automobilių parkas"
This entire program uses the data from LLC "Žaibas" to find:
1. Branch, which has on average older cars.
2. The newest car (or multiple) in the list.
3. Cars, which appear in both branches.
4. Cars, which have an expired or 1 month until technical inspection due date
*/

using System;
using System.Collections.Generic;

namespace Lab3.AutoPark
{
    class Program
    {
        const string Auto = "Automobiliai.txt";
        static void Main(string[] args)
        {
            Register firstPark = InOutUtils.ReadCars(@"vehiclesKaunas.csv");
            Register secondPark = InOutUtils.ReadCars(@"vehiclesVilnius.csv");
            InOutUtils.CreateTXTFile(Auto);
            InOutUtils.PrintCarsToTXT(Auto, firstPark);
            InOutUtils.PrintCarsToTXT(Auto, secondPark);

            ///First point.
            double avgone = firstPark.AverageAge();
            double avgtwo = secondPark.AverageAge();
            if (avgone > avgtwo)
            {
                InOutUtils.PrintCars("Seniausi automobiliai - " + firstPark.City, firstPark);
            }
            else if (avgtwo > avgone)
            {
                InOutUtils.PrintCars("Seniausi automobiliai - " + secondPark.City, secondPark);
            }

            ///Second point
            Register mistakes = new Register();
            mistakes = firstPark.FindMistakes(mistakes, secondPark);
            InOutUtils.PrintMistakesToCSV("Klaidos.csv", mistakes);

            ///Third point
            DateTime oneNewest = new DateTime(1, 1, 1);
            oneNewest = firstPark.FindNewestCar(oneNewest);
            oneNewest = secondPark.FindNewestCar(oneNewest);

            Register Newest = new Register();
            Newest = firstPark.CheckMultipleNewCars(oneNewest, Newest);
            Newest = secondPark.CheckMultipleNewCars(oneNewest, Newest);
            InOutUtils.PrintCars("Naujausi automobiliai", Newest);

            ///Fourth point.
            Register expired = new Register();
            expired = firstPark.FindExpired(expired);
            expired = secondPark.FindExpired(expired);
            expired.Sort();
            InOutUtils.PrintExpiredToCSV("Apžiūra.csv", expired);


            Console.ReadKey();
        }
    }
}
