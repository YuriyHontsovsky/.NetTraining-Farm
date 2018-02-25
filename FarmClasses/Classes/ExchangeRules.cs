using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Classes
{
    class ExchangeRules : IExchangeRules
    {

        public bool TryGetAction(IAnimal animalFrom, int animalFromCount, IAnimal animalTo, out IExcangeAction action, out string errorMessage)
        {
            action = null;
            errorMessage = "";

            if ((animalFrom.IsWild) || (animalTo.IsWild))
            {
                errorMessage = "animals can not be wild";
                return false;
            }

            int actionToCount = (animalFrom.BasePoints * animalFromCount / animalTo.BasePoints) == 0 ? 0 : 1;
            int actionFromCount = actionToCount * animalTo.BasePoints / animalFrom.BasePoints;

            if (actionToCount > 0)//!!YH
            {
                action = new ExcangeAction(animalFrom, actionFromCount, animalTo, actionToCount);
                return true;
            }
            else
            {
                errorMessage = "from count can not be transformated into to";
                return false;
            }

        }

        public bool Validate(IExcangeAction action)
        {
            return ((action != null) && TryGetAction(action.AnimalFrom, action.AnimalFromCount, action.AnimalTo, out IExcangeAction newAction, out string errorMessage) && (action.AnimalToCount == newAction.AnimalToCount));
        }
    }
}
