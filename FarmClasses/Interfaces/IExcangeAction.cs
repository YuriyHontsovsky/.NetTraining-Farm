using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    public interface IExcangeAction
    {
        IAnimal AnimalFrom { get; }
        int AnimalFromCount { get; }
        IAnimal AnimalTo { get; }
        int AnimalToCount { get; }
    }
}
