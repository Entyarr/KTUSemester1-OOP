using System;

namespace Lab3.AutoPark
{
    /// <summary>
    /// In this class Cars is defined.
    /// </summary>
    class Cars
    {
       /// <summary>
       /// Vehicle registration number.
       /// </summary>
        public string LicensePlate { get; set; }
        /// <summary>
        /// Which manufacturer produced the car.
        /// </summary>
        public string Make { get; set; }
        /// <summary>
        /// Model of the car.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// The date when the was manufactured, measured in years and months.
        /// </summary>
        public DateTime ManufactureDate { get; set; }
        /// <summary>
        /// The date when the vehicles technical inspection expires.
        /// </summary>
        public DateTime TechInspect { get; set; }
        /// <summary>
        /// How much fuel can the car hold.
        /// </summary>
        public double Fuel { get; set; }
        /// <summary>
        /// Fuel consumption.
        /// </summary>
        public double Consumption { get; set; }

        public Cars(string plate, string make, string model, DateTime manufactDate, DateTime techInspect, double fuel, double consumption)
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
        /// This method calculates the age of the car.
        /// </summary>
        /// <returns>Returns age of the car</returns>
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
        /// This methrod calculates how many days have gone since the technical inspection.
        /// </summary>
        /// <returns>How many days left</returns>
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
        /// Overrides ToString to make PrintCars method in InOutUtils easier to read.
        /// </summary>
        /// <returns>String of all car information in its proper form</returns>
        public override string ToString()
        {

            string line;
            line = String.Format("| {0,-10} | {1,-10} | {2,-10} | {3,15:yyyy-MM} | {4,21:yyyy-MM-dd} | {5,5} | {6,13} |",
                   this.LicensePlate, this.Make, this.Model, this.ManufactureDate, this.TechInspect, this.Fuel, this.Consumption);
            return line;
        }
        /// <summary>
        /// Creates a string of needed information of filtered out cars, checks if the expiry date is less than a month until expiration, adds addition information to the string.
        /// </summary>
        /// <returns>String of all car information in its proper form</returns>
        public string FilteredString()
        {
            string line;
            line = String.Format("{0};{1};{2};{3:yyyy-MM-dd}",
                    this.Make, this.Model, this.LicensePlate, this.TechInspect);
            if (this.Expiry >= 0)
            {
                line += ";SKUBIAI";
            }
            return line;
        }
        /// <summary>
        /// Overrides the '<' operator to be used when comparing two dates.
        /// </summary>
        /// <param name="date">Given date to compare</param>
        /// <param name="manufactured">Car, whichs manufacture date to compare</param>
        /// <returns>The older of the two</returns>
        public static bool operator >(DateTime date, Cars manufactured)
        {
            return date.CompareTo(manufactured.ManufactureDate) > 0;

        }
        /// <summary>
        /// Overrides the '<' operator to be used when comparing two dates.
        /// </summary>
        /// <param name="date">Given date to compare</param>
        /// <param name="manufactured">Car, whichs manufacture date to compare</param>
        /// <returns>The newer of the two</returns>
        public static bool operator <(DateTime date, Cars manufactured)
        {
            return date.CompareTo(manufactured.ManufactureDate) < 0;
        }
        /// <summary>
        /// Overrides Equals method, used to compare car makes of different lists
        /// </summary>
        /// <param name="other">Object to compare to</param>
        /// <returns>Boolean information, whether the car makes are equal</returns>
        public override bool Equals(object other)
        {
            return this.LicensePlate == ((Cars)other).LicensePlate;
        }
        /// <summary>
        /// Overrides GetHasCode method, used to apply hashcode to the car make.
        /// </summary>
        /// <returns>Car makes hash code</returns>
        public override int GetHashCode()
        {
            return this.LicensePlate.GetHashCode();
        }
        /// <summary>
        /// Compares two cars according to certain fields.
        /// </summary>
        /// <param name="other">Car to compare</param>
        /// <returns>Information, which element fits given comparisons</returns>
        public int CompareTo(Cars other)
        {
            int num;

            num = this.Make.CompareTo(other.Make);
            if (this.Make == other.Make)
            {
                num = this.Model.CompareTo(other.Model);
            }
            if (this.Make == other.Make && this.Model == other.Model)
            {
                num = this.LicensePlate.CompareTo(other.LicensePlate);
            }
            return num;
        }
    }
}
