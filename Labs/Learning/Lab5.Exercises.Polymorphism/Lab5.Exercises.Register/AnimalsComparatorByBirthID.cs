using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByBirthID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int num = 0;
            num = a.BirthDate.CompareTo(b.BirthDate);
            if (a.BirthDate == b.BirthDate)
            {
                num = a.ID.CompareTo(b.ID);
            }
            return num;
        }
    }
}
