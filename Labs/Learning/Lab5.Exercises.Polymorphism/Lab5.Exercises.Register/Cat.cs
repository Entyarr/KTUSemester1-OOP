using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    public class Cat : Animal
    {
        private const int VaccinationDurationMonths = 6;
        public DateTime LastVaccinationDate { get; set; }

        public Cat(int id, string name, string breed, DateTime birthDate, Gender gender) : base(id, name, breed, birthDate, gender)
        {

        }

        public bool RequiresVaccination
        {
            get
            {
                if (this.LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) < 0;
            }
        }
        public override string ToString()
        {
            return string.Format("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-12} | {6,-13:yyyy-MM-dd} |",
                                      ID, Name, Breed, BirthDate, Gender, "-", LastVaccinationDate);
        }
    }
}