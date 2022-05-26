using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
{
    class DogsRegister
    {
        private List<Dog> AllDogs;

        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }

        public Dog GetDog(int index)
        {
            return AllDogs[index];
        }

        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        public List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        /*public Dog OldestByBreed(DogsRegister AllDogs)
        {
            Dog newOldest = filteredByBreed[0]; // means least value
            for (int i = 1; i < filteredByBreed.Count; i++)
            {
                if (DateTime.Compare(filteredByBreed[i].BirthDate, newOldest.BirthDate) < 0)
                {
                    newOldest = filteredByBreed[i];
                }
            }
            return newOldest;
        }*/
        public int PopularBreed(List<Dog> Dogs, Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;

        }
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null)
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }

        public List<Dog> FilterByVaccinationExpired()
        {
            List<Dog> UnvaxxedDoggos = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.RequiresVaccination)
                {
                    UnvaxxedDoggos.Add(dog);
                }
            }
            return UnvaxxedDoggos;
        }

        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}

