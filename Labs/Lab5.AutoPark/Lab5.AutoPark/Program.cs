/*
2021 KTU 5th laboratory project
Project number: U5-2 "Automobilių parkas"
This entire program uses the data from LLC "Žaibas" to find:
1. Branch, which has on average older cars.
2. Which make has the most cars in all branches.
3. Sorted cars, which appear in all branches. 
4. Cars, which have an expiring (3 months or less) technical inspection due date.
*/

using System;
using System.Collections.Generic;

namespace Lab5.AutoPark
{
    class Program
    {
        const string Auto = "Automobiliai.txt";
        const string Expired = "Apžiūra.txt";
        static void Main(string[] args)
        {
            TransportRegister firstPark = InOutUtils.ReadTransport(@"vehiclesKaunas.csv");
            TransportRegister secondPark = InOutUtils.ReadTransport(@"vehiclesVilnius.csv");
            TransportRegister thirdPark = InOutUtils.ReadTransport(@"vehiclesMarijampolė.csv");

            InOutUtils.CreateTXTFile(Auto);
            InOutUtils.PrintTransportToTXT(Auto, firstPark);
            InOutUtils.PrintTransportToTXT(Auto, secondPark);
            InOutUtils.PrintTransportToTXT(Auto, thirdPark);

            ///First point
            double avgone = firstPark.AverageAge();
            double avgtwo = secondPark.AverageAge();
            double avgthree = thirdPark.AverageAge();
            if (avgone > avgtwo && avgone > avgthree)
            {
                InOutUtils.PrintTransport("Seniausi automobiliai - " + firstPark.City, firstPark);
            }
            else if (avgtwo > avgone && avgtwo > avgthree)
            {
                InOutUtils.PrintTransport("Seniausi automobiliai - " + secondPark.City, secondPark);
            }
            else if(avgthree > avgone && avgthree > avgtwo)
            {
                InOutUtils.PrintTransport("Seniausi automobiliai - " + thirdPark.City, thirdPark);
            }

            ///Second point
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            manufacturers = firstPark.FindManufacturers(manufacturers);
            manufacturers = secondPark.FindManufacturers(manufacturers);
            manufacturers = thirdPark.FindManufacturers(manufacturers);
            Manufacturer mostCommon = firstPark.FindMostCommon(manufacturers);
            InOutUtils.PrintMostCommonManufacturer(mostCommon);


            ///Third point
            TransportRegister masterList = new TransportRegister();
            masterList.CreateMasterList(masterList, firstPark);
            masterList.CreateMasterList(masterList, secondPark);
            masterList.CreateMasterList(masterList, thirdPark);
            masterList.Sort();
            InOutUtils.PrintTransport("Visos transporto priemonės", masterList);

            ///Fourth point.
            TransportRegister firstExpiring = firstPark.FindExpired();
            TransportRegister secondExpiring = secondPark.FindExpired();
            TransportRegister thirdExpiring= thirdPark.FindExpired();

            InOutUtils.CreateTXTFile(Expired);
            InOutUtils.PrintExpiredToTXT(Expired, firstExpiring, "Kauno filialo transporto priemonės");
            InOutUtils.PrintExpiredToTXT(Expired, secondExpiring, "Vilniaus filialo transporto priemonės");
            InOutUtils.PrintExpiredToTXT(Expired, thirdExpiring, "Marijampolės filialo transporto priemonės");

            Console.ReadKey();
        }
    }
}
