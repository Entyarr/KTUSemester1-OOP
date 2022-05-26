/*
2021 KTU 2nd laboratory project
Project number: U2-2 "Automobilių parkas"
This entire program uses the data from LLC "Žaibas" to find:
1. The most common car (or multiple) in the list and the number of how many times it appears.
2. The newest car (or multiple) in the list.
3. Cars, which have an expired or 1 month until technical inspection due date
*/

using System;
using System.Collections.Generic;

namespace Lab2.AutoPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Register firstPark = InOutUtils.ReadCars(@"vehiclesKaunas.csv");
            Register secondPark = InOutUtils.ReadCars(@"vehiclesVilnius.csv");
            InOutUtils.CreateTXTFile("Automobiliai.txt");
            InOutUtils.PrintCarsToTXT("Automobiliai.txt", firstPark);
            InOutUtils.PrintCarsToTXT("Automobiliai.txt", secondPark);
            
            List<string> manufacturers = new List<string>();
            manufacturers = firstPark.Manufacturers(manufacturers);
            manufacturers = secondPark.Manufacturers(manufacturers);
            int[] count = new int[manufacturers.Count];
            firstPark.CountCars(manufacturers, count);
            secondPark.CountCars(manufacturers, count);
            
            List<string> mostOccuring = new List<string>();
            int max = firstPark.FindMostOccuringInt(count);
            max = secondPark.FindMostOccuringInt(count);
            mostOccuring = firstPark.FindMostOccuring(manufacturers, count, max);
            mostOccuring = secondPark.FindMostOccuring(manufacturers, count, max);
            InOutUtils.PrintMostOccuring(mostOccuring, max);


            DateTime oneNewest = new DateTime(1, 1, 1);
            oneNewest = firstPark.FindNewestCar(oneNewest);
            oneNewest = secondPark.FindNewestCar(oneNewest);

            Register Newest = new Register();
            Newest = firstPark.CheckMultipleNewCars(oneNewest, Newest);
            Newest = secondPark.CheckMultipleNewCars(oneNewest, Newest);
            Console.WriteLine("Naujausi automobiliai:");
            InOutUtils.PrintCars(Newest);

            Register expired = new Register();
            expired = firstPark.FindExpired(expired);
            expired = secondPark.FindExpired(expired);
            InOutUtils.PrintExpiredToCSV("Apžiūra.csv", expired);


            Console.ReadKey();
        }
    }
}
