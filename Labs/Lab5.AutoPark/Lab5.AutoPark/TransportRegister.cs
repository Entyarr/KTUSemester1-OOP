using System;
using System.Collections.Generic;

namespace Lab5.AutoPark
{
    /// <summary>
    /// Class Register is used to hold information of parks and do calculations regarding said car parks.
    /// </summary>
    class TransportRegister
    {
        /// <summary>
        /// Defines a private Container
        /// </summary>
        private TransportContainer all;
        /// <summary>
        /// The following three paramaters (City, Address, PhoneNumber) are used to save the companys branch information.
        /// </summary>
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Used to create a new container.
        /// </summary>
        public TransportRegister()
        {
            all = new TransportContainer();
        }
        
        public TransportRegister(TransportContainer transport)
        {
            all = new TransportContainer();
            for (int i = 0; i < transport.Count; i++)
            {
                this.all.Add(transport.Get(i));
            }
        }
        /// <summary>
        /// Adds a single transport and its information to the container.
        /// </summary>
        /// <param name="transport">Element to add.</param>
        public void Add(Transport transport)
        {
            all.Add(transport);
        }
        /// <summary>
        /// Finds a vehicle in the container all at a wanted position.
        /// </summary>
        /// <param name="index">Wanted position.</param>
        /// <returns>Returns a vehicle from the list.</returns>
        public Transport GetTransport(int index)
        {
            return all.Get(index);
        }
        /// <summary>
        /// Finds how many elements are in the container all.
        /// </summary>
        /// <returns>A number of elemens in the container</returns>
        public int TransportCount()
        {
            return this.all.Count;
        }
        /// <summary>
        /// Calls to container to sort AllCars.
        /// </summary>
        public void Sort()
        {
            this.all.Sort();
        }
       
        /// <summary>
        /// Finds all manufacturers and how many times they appear in the register
        /// </summary>
        /// <param name="manufacturers">vehicle manufacturers</param>
        /// <returns>List of manufacturers and their amounts</returns>
        public List<Manufacturer> FindManufacturers(List<Manufacturer> manufacturers)
        {
            for(int i = 0; i < all.Count; i++)
            {
                bool foundInList = false;
                Manufacturer make = new Manufacturer(all.Get(i).Make);
                for(int j = 0; j < manufacturers.Count; j++)
                {
                    if(manufacturers[j].Make == make.Make)
                    {
                        manufacturers[j].Amount++;
                        foundInList = true;
                    }
                }
                if (!foundInList) manufacturers.Add(make);
            }
            return manufacturers;
        }

        /// <summary>
        /// Finds largest amount in list manufacturers
        /// </summary>
        /// <param name="manufacturers">List of all manufacturers</param>
        /// <returns>Most common manufacturer</returns>
        public Manufacturer FindMostCommon(List<Manufacturer> manufacturers)
        {
            Manufacturer mostCommon = manufacturers[0];
            for (int i = 1; i < manufacturers.Count; i++)
            {
                if(manufacturers[i].Amount > mostCommon.Amount)
                {
                    mostCommon = manufacturers[i];
                }
            }
            return mostCommon;
        }


        /// <summary>
        /// Find the average age of the car in the carpark branch.
        /// </summary>
        /// <returns>Average age of all all</returns>
        public double AverageAge()
        {
            double sum = 0;
            for (int i = 0; i < TransportCount(); i++)
            {
                sum += GetTransport(i).Age;
            }
            double avgage = sum / TransportCount();
            return avgage;
        }
        /// <summary>
        /// Creates a master list, adds all elements from one park
        /// </summary>
        /// <param name="masterList">Container that contains all vehicles</param>
        /// <param name="addPark">Park to add</param>
        /// <returns>Container that contains all vehicles</returns>
        public TransportRegister CreateMasterList(TransportRegister masterList, TransportRegister addPark)
        {
            for (int i = 0; i < addPark.TransportCount(); i++)
            {
                masterList.Add(addPark.GetTransport(i));
            }
            return masterList;
        }

        /// <summary>
        /// Finds which all have an expired or an expiring technical inspection date.
        /// </summary>
        /// <param name="Cars">Expired tech. inspection all container</param>
        /// <returns>A container of all, that have an expired or an expiring technical inspection day</returns>
        public TransportRegister FindExpired()
        {
            TransportRegister expiring = new TransportRegister();
            for (int i = 0; i < this.TransportCount(); i++)
            {
                if (GetTransport(i).Expiry > -180 && GetTransport(i).Expiry < 0) ///-180 implies the technical inspection has less than 3 months left.
                {
                    expiring.Add(GetTransport(i));
                }
            }
            return expiring;
        }
    }
}
