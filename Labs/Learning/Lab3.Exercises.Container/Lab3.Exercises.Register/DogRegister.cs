using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsRegister
    {
        private DogsContainer AllDogs;

        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }

        public DogsRegister(DogsContainer Dogs)
        {
            AllDogs = new DogsContainer();
            for(int i = 0; i < AllDogs.Count; i++)
            {
                this.AllDogs.Add(Dogs.Get(i));
            }
        }

        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }

        public Dog GetDog(int index)
        {
            return AllDogs.Get(index);
        }

        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for(int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        /*public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }*/

        /*private Dog FindOldestDog(DogsContainer Dogs)
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

        public List<string> FindBreeds(DogsContainer Dogs)
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
        }*/
        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for(int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(AllDogs.Get(i));
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
        private Dog FindDogByID(int ID)
        {
            for(int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).ID == ID)
                {
                    return AllDogs.Get(i);
                }
            }
            return null;
        }

        /// <summary>
        /// Trečias savarankiškas
        /// </summary>
        /// <param name="Vaccinations"></param>
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


        /// <summary>
        /// Antras savarankiškas
        /// </summary>
        /// <returns></returns>
        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer UnvaxxedDoggos = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).RequiresVaccination)
                {
                    UnvaxxedDoggos.Add(AllDogs.Get(i));
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

