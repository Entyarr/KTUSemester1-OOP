using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Butai
{
    class Apt //Apt shortened from apartament
    {
        public int Number { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }
        public int Price { get; set; }
        public int PhoneNumber { get; set; }
        public int Floor { get; set; }

        public Apt(int number, double area, int rooms, int price, int phonenumber)
        {
            this.Number = number;
            this.Area = area;
            this.Rooms = rooms;
            this.Price = price;
            this.PhoneNumber = phonenumber;
        }
    }
}
