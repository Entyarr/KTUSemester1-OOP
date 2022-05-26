using System;

namespace Lab5.AutoPark
{
    /// <summary>
    /// Defines a manufacturer
    /// </summary>
    class Manufacturer
    {
        /// <summary>
        /// Manufacturer of the transport
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// How many vehicles the manufacturer has
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Defines the initial manufacturer name and its amount
        /// </summary>
        /// <param name="make"></param>
        public Manufacturer(string make)
        {
            this.Make = make;
            this.Amount = 1;
        }
    }
}
