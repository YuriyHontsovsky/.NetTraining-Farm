using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    public interface IExchangeRules
    {
        bool TryGetAction(IAnimal animalFrom, int animalFromCount, IAnimal animalTo, out IExcangeAction action, out string errorMessage);
    }
}
