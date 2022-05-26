using System.Collections.Generic;
using System.Linq;

namespace Lab1.AutoPark
{
    /// <summary>
    /// This is the class where every single calculation is done.
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Uses Cars paramater to find all car makes in the car park.
        /// </summary>
        /// <param name="Cars"></param>
        /// <returns></returns>
        public static List<string> Manufacturers(List<Cars> Cars)
        {
            List<string> makes = new List<string>();
            foreach (Cars car in Cars)
            {
                string make = car.Make;
                if (!makes.Contains(make)) // uses List method Contains()
                {
                    makes.Add(make);
                }
            }
        return makes;
        }

        /// <summary>
        /// Uses Make and Cars paramater to compare both lists, in order to find how many cars have the same make.
        /// </summary>
        /// <param name="makes"></param>
        /// <param name="Cars"></param>
        /// <returns></returns>
        public static int[] CountCars(List<string> makes, List<Cars> Cars)
        {
            int[] count = new int[makes.Count]; // this paramater will be used to find how many of each car make there is

            for(int i = 0; i < makes.Count; i++)
            {
                for(int j = 0; j < Cars.Count; j++)
                {
                    if(makes[i] == Cars[j].Make)
                    {
                        count[i]++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Uses make and count paramaters to find the most occuring car make in the car park.
        /// </summary>
        /// <param name="makes"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<string> FindMostOccuring(List<string> makes, int[] count)
        {
            List<string> mostOccuring = new List<string>();
            
            for(int i = 0; i < makes.Count; i++)
            {
                if(count[i] == count.Max())
                {
                    mostOccuring.Add(makes[i]);
                }
            }

            return mostOccuring;
        }

        /// <summary>
        /// Uses Cars paramater and compares every single item in the list to find out which cars make is Volvo.
        /// </summary>
        /// <param name="Cars"></param>
        /// <param name="volvo"></param>
        /// <returns></returns>
        public static List<Cars> FilterVolvo(List<Cars> Cars, string volvo)
        {
            List<Cars> Filtered = new List<Cars>();
            foreach(Cars car in Cars)
            {
                if (car.Make.Equals(volvo)) // uses string method Equals()
                {
                    Filtered.Add(car);
                }
            }
            return Filtered;
        }

        /// <summary>
        /// Uses Cars paramater to find all cars that are older than 10 years.
        /// </summary>
        /// <param name="Cars"></param>
        /// <returns></returns>
        public static List<Cars> FindOldies(List<Cars> Cars)
        {
            List<Cars> Oldies = new List<Cars>();
            foreach(Cars oldie in Cars)
            {
                if(oldie.CalculateAge() > 10)
                {
                    Oldies.Add(oldie);
                }
            }
            return Oldies;
        }

    }
}
