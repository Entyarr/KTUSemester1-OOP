/*
2021 KTU 1st laboratory project
Author: Domas Kvedaras
Group: IF-1/1
Project number: U1-2 "Automobilių parkas"
This entire program uses the data from LLC "Žaibas" to find:
1. The most common car (or multiple) in the list and the number of how many times it appears.
2. All cars manufactured by Volvo.
3. All cars older than 10 years from today.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.AutoPark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cars> allCars = InOutUtils.ReadCars(@"vehicles2.csv");
            InOutUtils.PrintCars(allCars);
            InOutUtils.PrintCarsToTXT("Automobiliai.txt", allCars);

            List<string> manufacturers = TaskUtils.Manufacturers(allCars);
            int[] count= TaskUtils.CountCars(manufacturers, allCars);
            List<string> mostOccuring = TaskUtils.FindMostOccuring(manufacturers, count);
            InOutUtils.PrintMostOccuring(mostOccuring, count.Max());
            

            List<Cars> Volvos = TaskUtils.FilterVolvo(allCars, "Volvo");
            InOutUtils.PrintVolvos(Volvos);

            List<Cars> Oldies = TaskUtils.FindOldies(allCars);
            InOutUtils.PrintOldiesToCSV("Senienos.csv", Oldies);


            Console.ReadKey();
        }
    }
}
