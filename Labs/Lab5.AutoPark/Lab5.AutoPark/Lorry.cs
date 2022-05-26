using System;
using System.Collections.Generic;

namespace Lab5.AutoPark
{
    /// <summary>
    /// Defines lorry, inherits transport class
    /// </summary>
    class Lorry : Transport
    {
        /// <summary>
        /// Volume that a lorry can carry
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// Defines a lorry
        /// </summary>
        /// <param name="plate">License plate</param>
        /// <param name="make">Manufacturer of the lorry</param>
        /// <param name="model">Model of the lorry</param>
        /// <param name="manufactDate">Manufacture date of the lorry</param>
        /// <param name="techInspect">Technical inspection due date</param>
        /// <param name="fuel">Fuel storage</param>
        /// <param name="consumption">Fuel consumption</param>
        /// <param name="volume">Volume that a lorry can carry</param>
        public Lorry(string plate, string make, string model, DateTime manufactDate, DateTime techInspect, double fuel, double consumption, double volume) :
                base(plate, make, model, manufactDate, techInspect, fuel, consumption)
        {
            this.Volume = volume;

        }
        /// <summary>
        /// Overrides ToString method to return a string format suitable for tables including all parameters
        /// </summary>
        /// <returns>Suitable format including all parameters</returns>
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} | {7,5} | {8,5} |",
                                    LicensePlate, Make, Model, ManufactureDate, TechInspect, Fuel, Consumption, "-", Volume);
        }
    }
}
