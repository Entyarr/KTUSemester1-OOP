using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {

            DogsRegister register = InOutUtils.ReadDogs(@"dogs.csv");
            //DogsContainer copy = new DogsContainer(register);


            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs("doggies", register);

            int id = 122;
            string name = "Jonas";
            string breed = "A";
            DateTime birthDate = new DateTime(1, 1, 1);
            Gender gender = (Gender)1;
            

            Dog doggie1 = new Dog(id, name, breed, birthDate, gender);

            //register.Put(doggie1, 2);
            register.Insert(doggie1, 3);
            //register.RemoveAt(0);
            //register.Remove(doggie1);

            register.Sort();

            InOutUtils.PrintDogs("doggies Put Insert", register);
            InOutUtils.PrintDogs("copy", copy);

            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();

            /*
            Console.WriteLine(register.DogsCount());

            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
                oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);

            List<Dog> unvaxxedDogs = register.FilterByVaccinationExpired();
            Console.WriteLine("Nevakcinuoti šunys:");
            InOutUtils.PrintUnvaxxed(unvaxxedDogs);


            /*List<string> Breeds = register.FindBreeds(register);
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            /*
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();

            List<Dog> FilteredByBreed = register.FilterByBreed(register, selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Dog oldestBreed = register.OldestByBreed(FilteredByBreed);
            Console.WriteLine("Seniausias {0}", selectedBreed);
            Console.WriteLine("Vardas: {0}, Amžius: {1}",
                oldestBreed.Name, oldestBreed.CalculateAge());

            */

            Console.ReadKey();
        }
    }
}
