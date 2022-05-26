using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Lab2.AutoPark
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
        /// <returns>A list of cars with information</returns>
        public static Register ReadCars(string fileName)
        {
            Register Cars = new Register();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);

            Cars.City = Lines[0];
            Cars.Address = Lines[1];
            Cars.PhoneNumber = Lines[2];

            foreach(string line in Lines)
            {
                if (line.Contains(";")) //Checks which lines in the file are the car information
                {
                    string[] Values = line.Split(';');

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
            }
            return Cars;
        }

        /// <summary>
        /// Prints all contents from the list Cars onto a table in the console screen.
        /// </summary>
        /// <param name="Cars"></param>
        public static void PrintCars(Register Cars)
        {
            Console.WriteLine(new string('-', 106));
            Console.WriteLine("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} |",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos");
            Console.WriteLine(new string('-', 106));

            for(int i = 0; i < Cars.CarsCount(); i++)
            {
                Console.WriteLine(Cars.GetCar(i).ToString());
            }
            Console.WriteLine(new string('-', 106));

        }

        /// <summary>
        /// Creates a TXT file by the name of fileName, if there is information stored in the file, it deletes them.
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateTXTFile(string fileName)
        {
            if (new FileInfo(fileName).Length > 0)
            {
                File.WriteAllText(fileName, string.Empty);
            }
        }

        /// <summary>
        /// Prints the same text as in method PrintCars, but into a .txt file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Cars"></param>
        public static void PrintCarsToTXT(string fileName, Register Cars)
        {
            
            string[] lines = new string[Cars.CarsCount() + 7]; //+7 is required, to compensate for 4 additional lines that make up the table
            lines[0] = String.Format("Filialas: {0}", Cars.City);
            lines[1] = String.Format("Adresas: {0}", Cars.Address);
            lines[2] = String.Format("Tel. numeris: {0}", Cars.PhoneNumber);

            lines[3] = String.Format("----------------------------------------------------------------------------------------------------------");
            lines[4] = String.Format("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} | ",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos");
            lines[5] = String.Format("----------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < Cars.CarsCount(); i++)
            {
                lines[i + 6] = String.Format(Cars.GetCar(i).ToString());
            }
            lines[Cars.CarsCount() + 6] = String.Format("----------------------------------------------------------------------------------------------------------");
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints which car make appears the most and how many times it appears in the car park.
        /// </summary>
        /// <param name="mostOccuring"></param>
        /// <param name="max"></param>
        public static void PrintMostOccuring(List<string> mostOccuring, int max)
        {
            Console.WriteLine("Abiejuose filialų automobilių parkuose daugiausiai pasriklauso:");
            foreach (string mostoccuring in mostOccuring)
            {
                Console.WriteLine("{0} = {1}", mostoccuring, max);
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Prints all cars, who have an expired or an expiring technical inspection date.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Expired"></param>
        public static void PrintExpiredToCSV(string fileName, Register Expired)
        {
            string[] lines = new string[Expired.CarsCount() + 1];
            lines[0] = String.Format("{0};{1};{2};{3}",
                "Gamintojas", "Modelis", "Valst. nr.", "Tech. apž. galiojimas");
            for(int i = 0; i < Expired.CarsCount(); i++)
            {
                lines[i+1] = Expired.GetCar(i).FilteredString();

            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
