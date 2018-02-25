using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses
{
    public class Dice
    {
        private List<AnimalKind> aninimals = new List<AnimalKind>();
        static private Random rnd = new Random();

        public List<AnimalKind> Aninimals { get => aninimals; set => aninimals = value; }
        public static Random Rnd { get => rnd; }

        public Dice(Dictionary<AnimalKind, int> aninimalsProbs)
        {
            int probCount;
            foreach (var propb in aninimalsProbs)
            {
                probCount = propb.Value;
                while (probCount-- > 0)
                {
                    Aninimals.Add(propb.Key);
                }
            }
        }

        public IAnimal GetRandomAnimal() => Animal.GetAnimal(Aninimals[Rnd.Next(Aninimals.Count)]);
    }
}
