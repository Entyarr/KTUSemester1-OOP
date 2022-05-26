using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Butai
{
    class Program
    {
        static void Main(string[] args)
        {
            Apartments register = InOutUtils.ReadFile(@"Butai.csv");

            Console.Write("Įveskite kiek norite kambarių: ");
            int WantRooms = int.Parse(Console.ReadLine());
            Console.Write("Įveskite nuo kelinto aukšto: ");
            int WantMinFloor = int.Parse(Console.ReadLine());
            Console.Write("Įveskite iki kelinto aukšto: ");
            int WantMaxFloor = int.Parse(Console.ReadLine());
            Console.Write("Įveskite norimą kainą: ");
            int WantPrice = int.Parse(Console.ReadLine());

            register.FindFloors();

            List<Apt> FilteredApts = new List<Apt>();

            register.FilterByRooms(FilteredApts, WantRooms);
            register.FilterByFloors(FilteredApts, WantMinFloor, WantMaxFloor);
            register.FilterByPrice(FilteredApts, WantPrice);

            Console.WriteLine("Butai pagal jūsų norus:");
            InOutUtils.PrintApts(FilteredApts);

            Console.ReadKey();

        }
    }
}
