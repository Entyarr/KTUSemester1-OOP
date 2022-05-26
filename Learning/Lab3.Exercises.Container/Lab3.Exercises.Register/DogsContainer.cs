using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        private int Capacity;
        public DogsContainer(int capacity = 7) //parameter with default value 
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }

        public void Add(Dog dog)
        {
            //if (this.Count == this.Capacity) //container is full 
            //{
            //    EnsureCapacity(this.Capacity * 2);
            //}
            this.dogs[this.Count++] = dog;
        }

        public Dog Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dog dog)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if(this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Dog dog, int index)
        {
            this.dogs[index] = dog;
        }

        public void Insert(Dog dog, int index)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Count++;
            for(int i = Count; i > index; i--)
            {
                this.dogs[i] = this.dogs[i - 1];
            }
            this.dogs[index] = dog;
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Count-1; i++)
            {
                this.dogs[i] = this.dogs[i + 1];
            }
            this.Count--;
        }

        public void Remove(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if(this.dogs[i].Equals(dog))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        this.dogs[j] = this.dogs[j + 1];

                    }
                    i--;
                    this.Count--;
                }
            } 
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                    
                }
            }
        }

        public DogsContainer(DogsContainer container) : this() //calls another constructor 
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }





    }
}
