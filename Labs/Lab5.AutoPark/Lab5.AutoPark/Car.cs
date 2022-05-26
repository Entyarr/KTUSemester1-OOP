using System;

namespace Lab5.AutoPark
{
    /// <summary>
    /// Defines car, inherits Transport class
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Defines a car
        /// </summary>
        /// <param name="plate">License plate</param>
        /// <param name="make">Manufacturer of the car</param>
        /// <param name="model">Model of the car</param>
        /// <param name="manufactDate">Date when the car was manufactured</param>
        /// <param name="techInspect">Technical inspection due date</param>
        /// <param name="fuel">Fuel storage</param>
        /// <param name="consumption">Fuel consumption</param>
        public Car(string plate, string make, string model, DateTime manufactDate, DateTime techInspect, double fuel, double consumption) :
                base(plate, make, model, manufactDate, techInspect, fuel, consumption)
        {

        }
        /// <summary>
        /// Overrides ToString method to return all cars parameters in a suitable format
        /// </summary>
        /// <returns>String format including all parameters</returns>
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} | {7,5} | {8,5} |",
                                    LicensePlate, Make, Model, ManufactureDate, TechInspect, Fuel, Consumption, "-", "-");
        }
    }
}
