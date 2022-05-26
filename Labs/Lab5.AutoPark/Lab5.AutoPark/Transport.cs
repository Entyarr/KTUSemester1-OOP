using System;

namespace Lab5.AutoPark
{
    public abstract class Transport
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime TechInspect { get; set; }
        public double Fuel { get; set; }
        public double Consumption { get; set; }

        /// <summary>
        /// Defines a transport
        /// </summary>
        /// <param name="plate">License plate</param>
        /// <param name="make">Manufacturer</param>
        /// <param name="model">Model</param>
        /// <param name="manufactDate">Manufacturing date</param>
        /// <param name="techInspect">Technical inspection due date</param>
        /// <param name="fuel">Fuel storage</param>
        /// <param name="consumption">Fuel consumption</param>
        public Transport(string plate, string make, string model, DateTime manufactDate, DateTime techInspect, double fuel, double consumption)
        {
            this.LicensePlate = plate;
            this.Make = make;
            this.Model = model;
            this.ManufactureDate = manufactDate;
            this.TechInspect = techInspect;
            this.Fuel = fuel;
            this.Consumption = consumption;
        }
        /// <summary>
        /// Finds out how old the vehicle is
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.ManufactureDate.Year;
                if (this.ManufactureDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        /// <summary>
        /// Finds how many days left until its technical inspection due date
        /// </summary>
        public int Expiry
        {
            get
            {
                DateTime today = DateTime.Today;
                TimeSpan difference = today - this.TechInspect;
                int daysLeft = difference.Days;
                return daysLeft;
            }
        }
        /// <summary>
        /// A specific string format with certain parameters suitable for tables
        /// </summary>
        /// <returns>Formatted string with transport parameters</returns>
        public string FilteredString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-10} | {3,21:yyyy-MM-dd} |",
                    this.Make, this.Model, this.LicensePlate, this.TechInspect);
        }
        /// <summary>
        /// Compares the manufacture dates
        /// </summary>
        /// <param name="date">Date to compare to</param>
        /// <param name="manufactured">Date comparing</param>
        /// <returns>Results</returns>
        public static bool operator >(DateTime date, Transport manufactured)
        {
            return date.CompareTo(manufactured.ManufactureDate) > 0;
        }
        /// <summary>
        /// Compares the manufacture dates
        /// </summary>
        /// <param name="date">Date to compare to</param>
        /// <param name="manufactured">Date comparing</param>
        /// <returns>Results</returns>
        public static bool operator <(DateTime date, Transport manufactured)
        {
            return date.CompareTo(manufactured.ManufactureDate) < 0;
        }
        /// <summary>
        /// Overrides equals method to compare two license plates
        /// </summary>
        /// <param name="other">other transport</param>
        /// <returns>Whether the two transports are equal</returns>
        public override bool Equals(object other)
        {
            return this.LicensePlate == ((Transport)other).LicensePlate;
        }
        /// <summary>
        /// Gets hashcode of a specific license plate
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return this.LicensePlate.GetHashCode();
        }
        /// <summary>
        /// Overrides CompareTo metod to compare the make and model of two cars
        /// </summary>
        /// <param name="other">transport to compare to</param>
        /// <returns>Number that is similar to boolean information</returns>
        public int CompareTo(Transport other)
        {
            int num;

            num = this.Make.CompareTo(other.Make);
            if (this.Make == other.Make)
            {
                num = this.Model.CompareTo(other.Model);
            }
            return num;
        }
    }
}
