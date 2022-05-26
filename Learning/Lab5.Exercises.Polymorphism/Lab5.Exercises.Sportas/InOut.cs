using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5.Exercises.Sportas
{
    class InOut
    {
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> players = new List<Player>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                string team = values[1];
                string lastName = values[2];
                string firstName = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                

               /* switch (type)
                {
                    case "BB":
                        bool aggressive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggressive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                }*/
            }

            return players;
        }
    }
}
