using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.AutoPark
{   
    /// <summary>
    /// Container that holds cars information.
    /// </summary>
    class CarsContainer
    {
        private Cars[] cars;
        public int Count { get; private set; }

        private int Capacity;
        /// <summary>
        /// Defines Cars container with a given capacity.
        /// </summary>
        /// <param name="capacity">Default capacity</param>
        public CarsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.cars = new Cars[capacity];
        }
        /// <summary>
        /// Checks if capacity is overflowing, if it is, creates a new container with a new capacity
        /// </summary>
        /// <param name="minimumCapacity">New minimum capacity</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Cars[] temp = new Cars[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.cars[i];
                }
                this.Capacity = minimumCapacity;
                this.cars = temp;
            }
        }
        /// <summary>
        /// Adds an element into the container, making sure the capacity can hold it.
        /// </summary>
        /// <param name="car">Element to add to container</param>
        public void Add(Cars car)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.cars[this.Count++] = car;
        }
        /// <summary>
        /// Takes an element from the container at a given position.
        /// </summary>
        /// <param name="index">Given position</param>
        /// <returns>Element from wanter position</returns>
        public Cars Get(int index)
        {
            return this.cars[index];
        }
        /// <summary>
        /// Checks if container constains a given element.
        /// </summary>
        /// <param name="car">Element to check</param>
        /// <returns>Whether that element exists in the container</returns>
        public bool Contains(Cars car)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.cars[i].Equals(car))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Replaces an element at a given position with a given element.
        /// </summary>
        /// <param name="car">Element to place</param>
        /// <param name="index">Position where to place the element.</param>
        public void Put(Cars car, int index)
        {
            this.cars[index] = car;
        }
        /// <summary>
        /// Inserts an element into the container at a given position, while not removing anything and making sure the capacity can hold it.
        /// </summary>
        /// <param name="car">Element to insert.</param>
        /// <param name="index">Position where to insert the element.</param>
        public void Insert(Cars car, int index)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = Count; i > index; i--)
            {
                this.cars[i] = this.cars[i - 1];
            }
            this.cars[index] = car;
            this.Count++;
        }
        /// <summary>
        /// Removes an element from container at a given position.
        /// </summary>
        /// <param name="index">Given position at which to remove an element.</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this.cars[i] = this.cars[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Removes elements from container that match given parameter.
        /// </summary>
        /// <param name="car">Parameter, which to remove from the container.</param>
        public void Remove(Cars car)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.cars[i].Equals(car))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        this.cars[j] = this.cars[j + 1];

                    }
                    i--;
                    this.Count--;
                }
            }
        }

        /// <summary>
        /// Selection sort
        /// </summary>
        public void Sort()
        {
            int hold; ///will hold i value to sort 
            Cars temp; ///temp space for cars
            for(int i = 0; i < this.Count - 1; i++)
            {
                hold = i;
                for(int j = i+1; j < this.Count; j++)
                {
                    if (this.cars[hold].CompareTo(this.cars[j]) > 0) hold = j;
                }
                temp = this.cars[hold];
                this.cars[hold] = this.cars[i];
                this.cars[i] = temp;
            }
        }
    }
}
