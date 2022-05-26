using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sportas
{
    class Register
    {
       /* private Container all;

        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Used to create a new container.
        /// </summary>
        public Register()
        {
            all = new Container();
        }

        public Register(Container players)
        {
            all = new Container();
            for (int i = 0; i < players.Count; i++)
            {
                this.all.Add(players.Get(i));
            }
        }

        public void Add(Player player)
        {
            all.Add(player);
        }
        
        public Player GetPlayer(int index)
        {
            return all.Get(index);
        }
        
        public int CarsCount()
        {
            return this.all.Count;
        }
       
        public void Sort()
        {
            this.all.Sort();
        }
       
        public Register FindMistakes(Register mistakes, Register otherPark)
        {
            for (int i = 0; i < otherPark.CarsCount(); i++)
            {
                if (all.Contains(otherPark.GetCar(i)))
                {
                    mistakes.Add(otherPark.GetCar(i));
                }
            }

            mistakes.City = String.Format("{0} ir {1}", this.City, otherPark.City);
            return mistakes;
        }

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
        }*/
    }
}
