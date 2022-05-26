using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByNameID : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int num = 0;
            num = a.Name.CompareTo(b.Name);
            if(a.Name == b.Name)
            {
                num = a.ID.CompareTo(b.ID);
            }
            return num;
        }
    }
}
