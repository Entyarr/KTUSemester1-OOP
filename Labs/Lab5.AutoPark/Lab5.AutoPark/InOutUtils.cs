using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Lab5.AutoPark
{
    /// <summary>
    /// This class is used for file reading and printing to a console screen or files.
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Reads all all from a file into their corresponding paramaters, fileName is given when calling to the method.
        /// </summary>
        /// <param name="fileName">What file to read from</param>
        /// <returns>A container of transport with information.</returns>
        public static TransportRegister ReadTransport(string fileName)
        {
            TransportRegister Transports = new TransportRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);

            Transports.City = Lines[0];
            Transports.Address = Lines[1];
            Transports.PhoneNumber = Lines[2];

            foreach (string line in Lines)
            {
                if (line.Contains(";")) //Checks which lines in the file are the transport information
                {
                    string[] Values = line.Split(';');

                    string type = Values[0];
                    string reg = Values[1];
                    string make = Values[2];
                    string model = Values[3];
                    DateTime manufactDate = DateTime.Parse(Values[4]);
                    DateTime techInspect = DateTime.Parse(Values[5]);
                    double fuel = double.Parse(Values[6], new CultureInfo("en-US"));
                    double consumption = double.Parse(Values[7], new CultureInfo("en-US"));

                    switch(type)
                    {
                        case "CAR":
                            Car car = new Car(reg, make, model, manufactDate, techInspect, fuel, consumption);
                            Transports.Add(car);
                            break;
                        case "LORRY":
                            double volume = double.Parse(Values[8], new CultureInfo("en-US"));
                            Lorry lorry = new Lorry(reg, make, model, manufactDate, techInspect, fuel, consumption, volume);
                            Transports.Add(lorry);
                            break;
                        case "BUS":
                            int seats = int.Parse(Values[8]);
                            Bus bus = new Bus(reg, make, model, manufactDate, techInspect, fuel, consumption, seats);
                            Transports.Add(bus);
                            break;

                    }
                }
            }
            return Transports;
        }
        /// <summary>
        /// Prints all contents from the container transport onto a table in the console screen.
        /// </summary>
        /// <param name="label">Label of the table</param>
        /// <param name="transport">Register of transports (which holds the container)</param>
        public static void PrintTransport(string label, TransportRegister transport)
        {
            Console.WriteLine(new string('-', 122));
            Console.WriteLine("| {0,-118} |", label);
            Console.WriteLine(new string('-', 122));
            Console.WriteLine("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} | {7,5} | {8,5} |",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos", "Vietų", "Talpa");
            Console.WriteLine(new string('-', 122));

            for (int i = 0; i < transport.TransportCount(); i++)
            {
                Console.WriteLine(transport.GetTransport(i));
            }
            Console.WriteLine(new string('-', 122));
        }
        /// <summary>
        /// Prints the most common manufacturer
        /// </summary>
        /// <param name="manufacturer">Vehicle manufacturer</param>
        public static void PrintMostCommonManufacturer(Manufacturer manufacturer)
        {
            Console.WriteLine();
            Console.WriteLine("Daugiausia transporto priemonių priklauso:");
            Console.WriteLine("{0}, jiems priklauso {1}.", manufacturer.Make, manufacturer.Amount);
            Console.WriteLine();
        }
        /// <summary>
        /// Creates an empty TXT file with given name.
        /// </summary>
        /// <param name="fileName">Name of the TXT file.</param>
        public static void CreateTXTFile(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }
        /// <summary>
        /// Prints the same text as in method PrintTransport, but into a .txt file.
        /// </summary>
        /// <param name="fileName">Name of the TXT file.</param>
        /// <param name="transport">Register of transports (which holds the container)</param>
        public static void PrintTransportToTXT(string fileName, TransportRegister transport)
        {
            using (StreamWriter write = new StreamWriter(fileName, true))
            {
                write.WriteLine(string.Format("Filialas: {0}", transport.City));
                write.WriteLine(string.Format("Adresas: {0}", transport.Address));
                write.WriteLine(string.Format("Tel. numeris: {0}", transport.PhoneNumber));

                write.WriteLine(new string('-', 122));
                write.WriteLine(string.Format("| {0,-10} | {1,-10} | {2,-10} | {3,-15} | {4,-21} | {5,-5} | {6,-13} | {7,-5} | {8,-5} |",
                "Valst. Nr.", "Gamintojas", "Modelis", "Pagaminimo data", "Tech. apž. galiojimas", "Kuras", "Kuro sąnaudos", "Vietų", "Talpa"));
                write.WriteLine(new string('-', 122)); 
                for (int i = 0; i < transport.TransportCount(); i++)
                {
                    write.WriteLine(transport.GetTransport(i));
                }
                write.WriteLine(new string('-', 122));
            }
        }
        /// <summary>
        /// Prints all transports, who have an expired or an expiring technical inspection date.
        /// </summary>
        /// <param name="fileName">Name of the CSV file.</param>
        /// <param name="Expired">Register of all (which holds the container)</param>
        /// <param name="label">Label of the table</param>
        public static void PrintExpiredToTXT(string fileName, TransportRegister Expired, string label)
        {
            using (StreamWriter write = new StreamWriter(fileName, true))
            {
                write.WriteLine(new string('-', 64));
                write.WriteLine("| {0,-60} |", label);
                write.WriteLine(new string('-', 64));
                write.WriteLine("| {0,-10} | {1,-10} | {2,-10} | {3:21yyyy-MM-dd} |",
                    "Gamintojas", "Modelis", "Valst. nr.", "Tech. apž. galiojimas");
                write.WriteLine(new string('-', 64));

                for (int i = 0; i < Expired.TransportCount(); i++)
                {
                    write.WriteLine(Expired.GetTransport(i).FilteredString());
                }
                write.WriteLine(new string('-', 64));
                write.WriteLine();

            }
        }
       
    }
}
