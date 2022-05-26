using System;

namespace Lab1.AutoPark
{
    /// <summary>
    /// In this class Cars is defined.
    /// </summary>
    class Cars
    {
        public string LicensePlate { get; set; } // vehicle registration number
        public string Make { get; set; } 
        public string Model { get; set; }
        public DateTime ManufactureDate { get; set; } // the date when the car was manifactures, measured in years and months
        public DateTime TechInspect { get; set; } // the date when the technical inspection of the car expires
        public double Fuel { get; set; }
        public double Consumption { get; set; } // fuel consumption

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
        /// <returns></returns>
        public int CalculateAge()
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
}
