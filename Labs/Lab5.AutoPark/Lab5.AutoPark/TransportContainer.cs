using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.AutoPark
{   
    /// <summary>
    /// Container that holds all information.
    /// </summary>
    class TransportContainer
    {
        private Transport[] all = new Transport[16];
        public int Count { get; private set; }

        private int Capacity;
        /// <summary>
        /// Defines Transport container with a given capacity.
        /// </summary>
        /// <param name="capacity">Default capacity</param>
       /* public TransportContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.all = new Transport[capacity];
        }*/
        /// <summary>
        /// Checks if capacity is overflowing, if it is, creates a new container with a new capacity
        /// </summary>
        /// <param name="minimumCapacity">New minimum capacity</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Transport[] temp = new Transport[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.all[i];
                }
                this.Capacity = minimumCapacity;
                this.all = temp;
            }
        }
        /// <summary>
        /// Adds an element into the container, making sure the capacity can hold it.
        /// </summary>
        /// <param name="transport">Element to add to container</param>
        public void Add(Transport transport)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.all[this.Count++] = transport;
        }
        /// <summary>
        /// Takes an element from the container at a given position.
        /// </summary>
        /// <param name="index">Given position</param>
        /// <returns>Element from wanted position</returns>
        public Transport Get(int index)
        {
            return this.all[index];
        }
        /// <summary>
        /// Checks if container constains a given element.
        /// </summary>
        /// <param name="transport">Element to check</param>
        /// <returns>Whether that element exists in the container</returns>
        public bool Contains(Transport transport)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.all[i].Equals(transport))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Replaces an element at a given position with a given element.
        /// </summary>
        /// <param name="transport">Element to place</param>
        /// <param name="index">Position where to place the element.</param>
        public void Put(Transport transport, int index)
        {
            this.all[index] = transport;
        }
        /// <summary>
        /// Inserts an element into the container at a given position, while not removing anything and making sure the capacity can hold it.
        /// </summary>
        /// <param name="transport">Element to insert.</param>
        /// <param name="index">Position where to insert the element.</param>
        public void Insert(Transport transport, int index)
        {
            if (this.Count == this.Capacity) //container is full 
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = Count; i > index; i--)
            {
                this.all[i] = this.all[i - 1];
            }
            this.all[index] = transport;
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
                this.all[i] = this.all[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Removes elements from container that match given parameter.
        /// </summary>
        /// <param name="transport">Parameter, which to remove from the container.</param>
        public void Remove(Transport transport)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.all[i].Equals(transport))
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        this.all[j] = this.all[j + 1];
                    }
                    i--;
                    this.Count--;
                }
            }
        }

        /// <summary>
        /// Bubble sort
        /// </summary>
        public void Sort()
        {
            Transport temp; ///temp space for transport
            for(int i = 0; i < this.Count; i++)
            {
                for(int j = 0; j < this.Count-1; j++)
                {
                    if (this.all[j].CompareTo(this.all[j+1]) > 0)
                    {
                        temp = this.all[j + 1];
                        this.all[j + 1] = this.all[j];
                        this.all[j] = temp;
                    }
                }
                
            }
        }
    }
}
