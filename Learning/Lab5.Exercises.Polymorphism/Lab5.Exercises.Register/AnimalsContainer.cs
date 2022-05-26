using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        private int Capacity;
        public AnimalsContainer()
        {
            this.animals = new Animal[16]; //default capacity
        }
        public AnimalsContainer(int capacity = 4)
        {
            this.Capacity = capacity;
            this.animals = new Animal[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                 EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }


        public void Put(Animal animal, int index)
        {
            this.animals[index] = animal;
        }

        public void Insert(Animal animal, int index)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Count++;
            for (int i = Count; i > index; i--)
            {
                this.animals[i] = this.animals[i - 1];
            }
            this.animals[index] = animal;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this.animals[i] = this.animals[i + 1];
            }
            this.Count--;
        }

        public void Remove(Animal animal)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        this.animals[j] = this.animals[j + 1];

                    }
                    i--;
                    this.Count--;
                }
            }
        }

        

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
