using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5.Exercises.Register
{
    static class InOutUtils
    {
        public static Register ReadAnimals(string fileName)
        {
            Register animals = new Register();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);

                Gender gender;
                Enum.TryParse(values[5], out gender); //tries to convert value to enum 

                switch(type)
                {
                    case "DOG":
                        bool aggressive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggressive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GUINEA":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                }
            }

            return animals;
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);

                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }

        public static void PrintAnimals(string label, Register animals)
        {
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("| {0,-85} |", label);
            Console.WriteLine(new string('-', 105));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-12} | {6,-13} |",
                "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agresyvus?", "Vakcinos data");
            Console.WriteLine(new string('-', 105));
            for (int i = 0; i < animals.ACount(); i++)
            {
                //Animal animal = animals.GetAnimal(i);
                //if (animal is Cat cat)
                    Console.WriteLine(animals.GetAnimal(i));
                //if (animal is Dog dog)
                   // Console.WriteLine(dog);
                //if (animal is GuineaPig guineaPig)
                   // Console.WriteLine(guineaPig);


            }
            Console.WriteLine(new string('-', 105));
        }
        public static void PrintUnvaxxed(List<Dog> Bad)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |",
                "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));

            foreach (Dog Dogs in Bad)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                    Dogs.ID, Dogs.Name, Dogs.Breed, Dogs.BirthDate, Dogs.Gender);
            }
            Console.WriteLine(new string('-', 74));

        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}",
                "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                    Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
