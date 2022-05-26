using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Lab1.AutoPark
{
    /// <summary>
    /// This class is used for file reading and printing to a console screen or files.
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Reads all cars from a file into their corresponding paramaters, fileName is given when calling to the method.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Cars> ReadCars(string fileName)
        {
            List<Cars> Cars = new List<Cars>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            for(int i = 0; i < Lines.Count(); i++)
            {
                string[] Values = Lines[i].Split(';');

                string reg = Values[0];
                string make = Values[1];
                string model = Values[2];
                DateTime manufactDate = DateTime.Parse(Values[3]);
                DateTime techInspect = DateTime.Parse(Values[4]);
                double fuel = double.Parse(Values[5], new CultureInfo("en-US"));
                double consumption = double.Parse(Values[6], new CultureInfo("en-US"));

                Cars car = new Cars(reg, make, model, manufactDate, techInspect, fuel, consumption);
                Cars.Add(car);
            }
            return Cars;
        }

        /// <summary>
        /// Prints all contents from the list Cars onto a table.
        /// </summary>
        /// <param name="Cars"></param>
        public static void PrintCars(List<Cars> Cars)
        {
            Console.WriteLine(new string('-', 106));
            Console.WriteLine("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} |",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos");
            Console.WriteLine(new string('-', 106));

            foreach (Cars car in Cars)
            {
                Console.WriteLine("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} |",
                    car.LicensePlate, car.Make, car.Model, car.ManufactureDate, car.TechInspect, car.Fuel, car.Consumption);
            }
            Console.WriteLine(new string('-', 106));

        }

        /// <summary>
        /// Prints the same text as in method PrintCars to a .txt file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Cars"></param>
        public static void PrintCarsToTXT(string fileName, List<Cars> Cars)
        {
            string[] lines = new string[Cars.Count + 4];
            lines[0] = String.Format("----------------------------------------------------------------------------------------------------------");
            lines[1] = String.Format("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} | ",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos");
            lines[2] = String.Format("----------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < Cars.Count; i++)
            {
                lines[i + 3] = String.Format("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} |",
                    Cars[i].LicensePlate, Cars[i].Make, Cars[i].Model, Cars[i].ManufactureDate, Cars[i].TechInspect, Cars[i].Fuel, Cars[i].Consumption);
            }
            lines[Cars.Count + 3] = String.Format("----------------------------------------------------------------------------------------------------------");
            File.WriteAllLines(fileName, lines, Encoding.UTF8);

        }


        /// <summary>
        /// Prints which car make appears the most and how many times it appears in the car park.
        /// </summary>
        /// <param name="mostOccuring"></param>
        /// <param name="max"></param>
        public static void PrintMostOccuring(List<string> mostOccuring, int max)
        {
            Console.WriteLine();
            Console.WriteLine("Daugiausiai priklauso:");
            foreach (string mostoccuring in mostOccuring)
            {
                Console.WriteLine("{0} = {1}", mostoccuring, max);
            }
        }

        /// <summary>
        /// Prints all previously found Volvos.
        /// If no Volvo cars are found, it prints the table and leaves it empty.
        /// </summary>
        /// <param name="Volvos"></param>
        public static void PrintVolvos(List<Cars> Volvos)
        {
            Console.WriteLine();
            Console.WriteLine("Visi Volvo automobiliai esantys saraše:");
            Console.WriteLine(new string('-', 46));
            Console.WriteLine("| {0,-10} | {1,-10} | {2,-16} |",
                "Valst. Nr.",  "Modelis", "Pagaminimo metai");
            Console.WriteLine(new string('-', 46));

            foreach (Cars volvo in Volvos)
            {
                Console.WriteLine("| {0,-10} | {1,-10} | {2,16:yyyy} |",
                    volvo.LicensePlate, volvo.Model, volvo.ManufactureDate);
            }
            Console.WriteLine(new string('-', 46));

        }

        /// <summary>
        /// Prints all cars older than 10 years into a .csv file, fileName is given when calling to the method.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Oldies"></param>
        public static void PrintOldiesToCSV(string fileName, List<Cars> Oldies)
        {
            string[] lines = new string[Oldies.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                "Valst. Nr.", "Gamintojas", "Markė", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos");
            for (int i = 0; i < Oldies.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3:yyyy-MM};{4:yyyy-MM-dd};{5};{6}",
                    Oldies[i].LicensePlate, Oldies[i].Make, Oldies[i].Model, Oldies[i].ManufactureDate, Oldies[i].TechInspect, Oldies[i].Fuel, Oldies[i].Consumption);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
