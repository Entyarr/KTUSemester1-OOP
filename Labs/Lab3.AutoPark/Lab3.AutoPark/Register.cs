using System;
using System.Collections.Generic;

namespace Lab3.AutoPark
{
    /// <summary>
    /// Class Register is used to hold information of car parks and do calculations regarding said car parks.
    /// </summary>
    class Register
    {
        /// <summary>
        /// Defines a private Container
        /// </summary>
        private CarsContainer AllCars;
        /// <summary>
        /// The following three paramaters (City, Address, PhoneNumber) are used to save the companys branch information.
        /// </summary>
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Used to create a new container.
        /// </summary>
        public Register()
        {
            AllCars = new CarsContainer();
        }
        
        public Register(CarsContainer Cars)
        {
            AllCars = new CarsContainer();
            for (int i = 0; i < Cars.Count; i++)
            {
                this.AllCars.Add(Cars.Get(i));
            }
        }
        /// <summary>
        /// Adds a single car and its information to the container.
        /// </summary>
        /// <param name="car">Element to add.</param>
        public void Add(Cars car)
        {
            AllCars.Add(car);
        }
        /// <summary>
        /// Finds a car in the container AllCars at a wanted position.
        /// </summary>
        /// <param name="index">Wanted position.</param>
        /// <returns>Returns a car from the list.</returns>
        public Cars GetCar(int index)
        {
            return AllCars.Get(index);
        }
        /// <summary>
        /// Finds how many elements are in the container AllCars.
        /// </summary>
        /// <returns>A number of elemens in the container</returns>
        public int CarsCount()
        {
            return this.AllCars.Count;
        }
        /// <summary>
        /// Calls to container to sort AllCars.
        /// </summary>
        public void Sort()
        {
            this.AllCars.Sort();
        }
        /// <summary>
        /// Finds cars that appear in both data files, adds them to their own container.
        /// </summary>
        /// <param name="mistakes">Where the mistaken cars get placed.</param>
        /// <param name="otherPark">Other carpark branch.</param>
        /// <returns></returns>
        public Register FindMistakes(Register mistakes, Register otherPark)
        {
            for(int i = 0; i < otherPark.CarsCount(); i++)
            {
                if(AllCars.Contains(otherPark.GetCar(i)))
                {
                    mistakes.Add(otherPark.GetCar(i));
                }
            }

            mistakes.City = String.Format("{0} ir {1}", this.City, otherPark.City);
            return mistakes;
        }
        /// <summary>
        /// Find the average age of the car in the carpark branch.
        /// </summary>
        /// <returns>Average age of all cars</returns>
        public double AverageAge()
        {
            double sum = 0;
            for (int i = 0; i < CarsCount(); i++)
            {
                sum += GetCar(i).Age;
            }
            double avgage = sum / CarsCount();
            return avgage;
        }
        /// <summary>
        /// Finds the newest date in the container AllCars, which equals the newest car in the car park.
        /// </summary>
        /// <param name="Newest">The newest date found.</param>
        /// <returns>The newest car</returns>
        public DateTime FindNewestCar(DateTime Newest)
        {
            for (int i = 0; i < CarsCount(); i++)
            {
                if (Newest < GetCar(i))
                {
                    Newest = GetCar(i).ManufactureDate;
                }
            }
            return Newest;
        }
        /// <summary>
        /// Uses newest parameter to find one or multiple cars, which have been manufactured the same year and month.
        /// </summary>
        /// <param name="newest">The date the newest car was manufactured.</param>
        /// <param name="Cars">Container of cars.</param>
        /// <returns>Container of newest cars.</returns>
        public Register CheckMultipleNewCars(DateTime newest, Register Cars)
        {
            for (int i = 0; i < CarsCount(); i++)
            {
                if (newest == GetCar(i).ManufactureDate)
                {
                    Cars.Add(GetCar(i));
                }
            }
            return Cars;
        }
        /// <summary>
        /// Finds which cars have an expired or an expiring technical inspection date.
        /// </summary>
        /// <param name="Cars">Expired tech. inspection cars container</param>
        /// <returns>A container of cars, that have an expired or an expiring technical inspection day</returns>
        public Register FindExpired(Register Cars)
        {
            for (int i = 0; i < CarsCount(); i++)
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
