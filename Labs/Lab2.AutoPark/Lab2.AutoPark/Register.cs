using System;
using System.Collections.Generic;

namespace Lab2.AutoPark
{
    /// <summary>
    /// Class Register is used to hold information of car parks and do calculations regarding said car parks.
    /// </summary>
    class Register
    {
        /// <summary>
        /// Defines a private List, that will be used within this class.
        /// </summary>
        private List<Cars> AllCars;
        /// <summary>
        /// The following three paramaters (City, Address, PhoneNumber) are used to save the companys branch information.
        /// </summary>
        public string City;
        public string Address;
        public string PhoneNumber;

        /// <summary>
        /// Used to create a new list.
        /// </summary>
        public Register()
        {
            AllCars = new List<Cars>();
        }

        /// <summary>
        /// Adds cars and its information to the list.
        /// </summary>
        /// <param name="Cars"></param>
        public Register(List<Cars> Cars)
        {
            AllCars = new List<Cars>();
            foreach (Cars car in Cars)
            {
                this.AllCars.Add(car);
            }
        }


        /// <summary>
        /// Adds a single car and its information to the list.
        /// </summary>
        /// <param name="car"></param>
        public void Add(Cars car)
        {
            AllCars.Add(car);
        }

        /// <summary>
        /// Finds a car in the list AllCars at a wanted position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns a car from the list</returns>
        public Cars GetCar(int index)
        {
            return AllCars[index];
        }

        /// <summary>
        /// Finds how many elements are in the list AllCars
        /// </summary>
        /// <returns>A number of elemens in the list</returns>
        public int CarsCount()
        {
            return this.AllCars.Count;
        }

        /// <summary>
        /// Uses AllCars list to find all car makes in the car park.
        /// </summary>
        /// <param name="makes"></param>
        /// <returns>A string list of all car makes in the car park</returns>
        public List<string> Manufacturers(List<string> makes)
        {
            for(int i = 0; i < CarsCount(); i++)
            {
                string make = GetCar(i).Make;
                if (!makes.Contains(make)) // uses List method Contains()
                {
                    makes.Add(make);
                }
            }
            return makes;
        }

        /// <summary>
        /// Uses Make and AllCars paramater to compare both lists, in order to find how many cars have the same make.
        /// </summary>
        /// <param name="makes"></param>
        /// <param name="count"></param>
        /// <returns>An int array, which holds how many cars of which car make there are</returns>
        public int[] CountCars(List<string> makes, int[] count)
        {
            for (int i = 0; i < makes.Count; i++)
            {
                for (int j = 0; j < CarsCount(); j++)
                {
                    if (makes[i].Equals(AllCars[j].Make))
                    {
                        count[i]++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Finds the largest number in count array, this is equals the most cars in the car park.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Largest number in the array</returns>
        public int FindMostOccuringInt(int[] count)
        {
            int max = count[0];
            for (int i = 0; i < count.Length; i++)
            {
                if (max < count[i]) max = count[i];
            }
            return max;
        }

        /// <summary>
        /// Uses makes, count and max paramaters to find the most occuring car makes in the car park.
        /// </summary>
        /// <param name="makes"></param>
        /// <param name="count"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<string> FindMostOccuring(List<string> makes, int[] count, int max)
        {
            List<string> mostOccuring = new List<string>();

            for (int i = 0; i < makes.Count; i++)
            {
                if (count[i] == max)
                {
                    mostOccuring.Add(makes[i]);
                }
            }

            return mostOccuring;
        }

        /// <summary>
        /// Finds the newest date in the list AllCars, which equals the newest car in the car park.
        /// </summary>
        /// <param name="Newest"></param>
        /// <returns>The newest car</returns>
        public DateTime FindNewestCar(DateTime Newest)
        {
            for (int i = 0; i < CarsCount(); i++)
            {
                if (Newest < GetCar(i).ManufactureDate)
                {
                    Console.WriteLine(Newest.CompareTo(GetCar(i).ManufactureDate) < 0);
                    Newest = GetCar(i).ManufactureDate;
                    
                }
                
            }
            return Newest;
        }

        /// <summary>
        /// Uses newest parameter in order to find one or multiple cars, which were manufactured the same year and month.
        /// </summary>
        /// <param name="newest"></param>
        /// <param name="Cars"></param>
        /// <returns>A list of newest cars</returns>
        public Register CheckMultipleNewCars(DateTime newest, Register Cars)
        { 
            for(int i = 0; i < CarsCount(); i++)
            {
                if(newest == GetCar(i).ManufactureDate)
                {
                    Cars.Add(GetCar(i));
                }
            }

            return Cars;
        }

        /// <summary>
        /// Finds which cars have an expired or an expiring technical inspection date.
        /// </summary>
        /// <param name="Cars"></param>
        /// <returns>A list of cars, that have an expired or an expiring technical inspection daae</returns>
        public Register FindExpired(Register Cars)
        {
            for(int i = 0; i < CarsCount(); i++)
            {

                if (GetCar(i).Expiry > -30) ///-30 implies the technical inspection has 29 days or less left.
                {
                    
                    Cars.Add(GetCar(i));
                }
            }
            return Cars;
        }
    }
}
