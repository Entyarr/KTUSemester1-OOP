using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Butai
{
    class Apartments
    {
        private List<Apt> AllApts;

        public Apartments()
        {
            AllApts = new List<Apt>();
        }

        public Apartments(List<Apt> Apts)
        {
            AllApts = new List<Apt>();
            foreach (Apt apt in Apts)
            {
                this.AllApts.Add(apt);
            }
        }

        public void Add(Apt apt)
        {
            AllApts.Add(apt);
        }

        public bool Contains(Apt apt)
        {
            return AllApts.Contains(apt);
        }

        public int AptsCount()
        {
            return this.AllApts.Count;
        }
        public Apt GetApt(int index)
        {
            return AllApts[index];
        }

        public void FindFloors()
        {
            for (int i = 0; i < AptsCount(); i++)
            {
                double temp = this.AllApts[i].Number;
                while (temp > 27)
                {
                    temp -= 27;
                }
                AllApts[i].Floor = Convert.ToInt32(Math.Ceiling(temp / 3));
            }
        }

        public void FilterByRooms(List<Apt> Filtered, int rooms)
        {
            foreach (Apt apt in this.AllApts)
            {
                if (apt.Rooms == rooms)
                {
                    Filtered.Add(apt);
                }
            }
        }

        public void FilterByFloors(List<Apt> Filtered, int min, int max)
        {
            for(int i = 0; i < Filtered.Count; i++)
            {
                if(Filtered[i].Floor < min || Filtered[i].Floor > max)
                {
                    Filtered.RemoveAt(i);
                    i--;
                }
            }
        }

        public void FilterByPrice(List<Apt> Filtered, int price)
        {
            for (int i = 0; i < Filtered.Count; i++)
            {
                if (Filtered[i].Price > price)
                {
                    Filtered.RemoveAt(i);
                    i--;
                }
            }
        }


    }
}
