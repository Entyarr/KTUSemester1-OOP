using System;
using System.Collections.Generic;

namespace Lab5.AutoPark
{
    /// <summary>
    /// Defines a bus, inherits Transport class
    /// </summary>
    class Bus : Transport
    {
        /// <summary>
        /// Creates seats parameter
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// Defines a bus
        /// </summary>
        /// <param name="plate">License plate</param>
        /// <param name="make">Manufacturer of the bus</param>
        /// <param name="model">Model of the bus</param>
        /// <param name="manufactDate">Date when the bus was manufactured</param>
        /// <param name="techInspect">Technical inspection due date</param>
        /// <param name="fuel">Fuel storage</param>
        /// <param name="consumption">Fuel consumption</param>
        /// <param name="seats">Seat count in the bus</param>
        public Bus(string plate, string make, string model, DateTime manufactDate, DateTime techInspect, double fuel, double consumption, int seats) :
                base(plate, make, model, manufactDate, techInspect, fuel, consumption)
        {
            this.Seats = seats;

        }
        /// <summary>
        /// Overrides ToString to create a text of all bus' parameters 
        /// </summary>
        /// <returns>All bus parameters in a string format suitable for a table</returns>
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} | {7,5} | {8,5} |",
                                    LicensePlate, Make, Model, ManufactureDate, TechInspect, Fuel, Consumption, Seats, "-");
        }
    }
}
