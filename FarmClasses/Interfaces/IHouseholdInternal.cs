using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    interface IHouseholdInternal
    {
        void ApplyAnnimals(IAnimal animal1, IAnimal animal2);
        void ApplayExcangeAction(IExcangeAction action);
    }
}
