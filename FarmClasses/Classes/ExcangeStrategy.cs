using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Classes
{
    public class ExcangeStrategy : IExcangeStrategy
    {
        public IExcangeAction Excange(IHousehold MyHousehold, IExchangeRules ExchangeRules)
        {
            foreach (AnimalKind animalKinndFrom in Enum.GetValues(typeof(AnimalKind)))
            {
                bool started = false;
                foreach (AnimalKind animalKinndTo in Enum.GetValues(typeof(AnimalKind)))
                {
                    if (started)
                    {
                        var animalFrom = Animal.GetAnimal(animalKinndFrom);
                        var animalTo = Animal.GetAnimal(animalKinndTo);

                        if ((animalFrom.IsWild) || (animalTo.IsWild))
                        {
                            continue;
                        }
                        if (
                            (MyHousehold.GetAnimalCount(animalFrom) > 0) 
                            && 
                            (((MyHousehold.GetAnimalCount(animalTo) == 0) || ((animalTo.Kind != AnimalKind.SmallDog) && (animalTo.Kind != AnimalKind.BigDog))))
                            &&
                            (ExchangeRules.TryGetAction(animalFrom, MyHousehold.GetAnimalCount(animalFrom), animalTo, out IExcangeAction result, out string errorMessage))
                            &&
                            ((MyHousehold.GetAnimalCount(animalFrom) - result.AnimalFromCount) > 0)
                        )
                            return result;
                    }
                    started = (started || (animalKinndFrom == animalKinndTo));
                }
            }
            return null;
        }
    }
}
