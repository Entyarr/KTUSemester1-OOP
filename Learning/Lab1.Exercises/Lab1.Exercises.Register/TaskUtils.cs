using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Register
{
    static class TaskUtils
    {
        public static int CountByGender(List<Dog> Dogs, Gender gender)
        {
            int count = 0;
            foreach (Dog dog in Dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public static Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0]; // means least value
            for (int i = 1; i < Dogs.Count; i++)     
            {         
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0) 
                {             
                    oldest = Dogs[i];         
                }     
            }     
            return oldest; 
        }

        public static List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>(); foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed; 
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {            
                    Breeds.Add(breed);        
                }     
            }     
            return Breeds; 
        }

        public static List<Dog> FilterByBreed(List<Dog> Dogs, string breed)
        {
            List<Dog> Filtered = new List<Dog>(); foreach (Dog dog in Dogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {             
                    Filtered.Add(dog);  
                }  
            }    
            return Filtered; 
        }
    }
}
