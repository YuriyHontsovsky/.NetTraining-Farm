using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses
{
    internal class Household : IHousehold, IHouseholdInternal
    {IExcangeStrategy strategy;
        private Dictionary<AnimalKind, int> animals = new Dictionary<AnimalKind, int>();
        private void SetAnimalCount(AnimalKind kind, int count)
        {
            animals.Remove(kind);
            if (count > 0)
            {
                animals.Add(kind, count);
            }
        }
        private void AddAnimals(AnimalKind kind, int count)
        {
            int existingCount;
            if (kind == AnimalKind.Wolf)
            {
                if (animals.TryGetValue(AnimalKind.BigDog, out existingCount))
                {
                    SetAnimalCount(AnimalKind.BigDog, existingCount - 1);
                }
                else
                {
                    //SetAnimalCount(AnimalKind.Rabbit, 0);
                    SetAnimalCount(AnimalKind.Sheep, 0);
                    SetAnimalCount(AnimalKind.Pig, 0);
                    SetAnimalCount(AnimalKind.Cow, 0);
                    SetAnimalCount(AnimalKind.SmallDog, 0);
                }
            }
            else
            if (kind == AnimalKind.Fox)
            {
                if (animals.TryGetValue(AnimalKind.SmallDog, out existingCount))
                {
                    SetAnimalCount(AnimalKind.SmallDog, existingCount - 1);
                }
                else
                {
                    SetAnimalCount(AnimalKind.Rabbit, 0);
                }
            }
            else
            {
                animals.TryGetValue(kind, out existingCount);
                SetAnimalCount(kind, existingCount + (existingCount + count) / 2);
            }
        }
        private void ValidateAction(IExcangeAction action)
        {
           int animalCount = GetAnimalCount(action.AnimalFrom);
           if (animalCount < action.AnimalFromCount)
           {
                throw new Exception(string.Format("Action can not be performed. Count of {1} is less then {2}", action.AnimalFrom.Name, animalCount));
            }
        }

        internal IExcangeStrategy Strategy { get => strategy; set => strategy = value; }

        public string Name { get => name; set => name = value; }
        public List<IHousehold> CompetitorsInternal { get => competitors; set => competitors = value; }
        public IReadOnlyList<IHousehold> Competitors => CompetitorsInternal;

        #region IHousehold
        List<IHousehold> competitors = new List<IHousehold>();
        string name;
        public int GetAnimalCount(IAnimal animal)
        {
            animals.TryGetValue(animal.Kind, out int count);
            return count;
        }
        #endregion

        #region IHouseholdInternal
        public void ApplyAnnimals(IAnimal animal1, IAnimal animal2)
        {
            if (animal1.Kind == animal2.Kind)
            {
                AddAnimals(animal1.Kind, 2);
            }
            else
            {
                AddAnimals(animal1.Kind, 1);
                AddAnimals(animal2.Kind, 1);
            }
        }
        public void ApplayExcangeAction(IExcangeAction action)
        {
            ValidateAction(action);
            SetAnimalCount(action.AnimalFrom.Kind, GetAnimalCount(action.AnimalFrom) - action.AnimalFromCount);
            SetAnimalCount(action.AnimalTo.Kind, GetAnimalCount(action.AnimalTo) + action.AnimalToCount);
        }
        #endregion
    }
}
