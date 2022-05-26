using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class Register
    {
        private AnimalsContainer all;

        public Register()
        {
            all = new AnimalsContainer();
        }

        public Register(AnimalsContainer animals
            )
        {
            all = new AnimalsContainer();
            for(int i = 0; i < all.Count; i++)
            {
                this.all.Add(animals.Get(i));
            }
        }
        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.all.Count; i++)
            {
                Animal animal = this.all.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }

        public void Add(Animal animal)
        {
            all.Add(animal);
        }

        public Animal GetAnimal(int index)
        {
            return all.Get(index);
        }

        public int ACount()
        {
            return this.all.Count;
        }
        /*
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.all)
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
            return this.FindOldestDog(this.all);
        }

        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        private Dog FindOldestDog(` Dogs)
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
            foreach (Dog dog in this.all)
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
        }
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

        }*/
        private Animal FindDogByID(int ID)
        {
            for(int i = 0; i < this.ACount(); i++)
            {
                if (all.Get(i).ID == ID)
                {
                    return all.Get(i);
                }
            }
            return null;
        }
        
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindDogByID(vaccination.AnimalID);
                if (animal != null)
                {
                    if (animal is Dog && vaccination > (animal as Dog).LastVaccinationDate)
                    {
                        (animal as Dog).LastVaccinationDate = vaccination.Date;
                    }
                    if (animal is Cat && vaccination > (animal as Cat).LastVaccinationDate)
                    {
                        (animal as Cat).LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }
        public void Sort(AnimalsComparator yes)
        {
            all.Sort(yes);
        }
    }
}

