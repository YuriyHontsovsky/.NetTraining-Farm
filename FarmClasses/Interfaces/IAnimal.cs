using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    public enum AnimalKind { Rabbit, Sheep, Pig, Cow, Horse, SmallDog, BigDog, Fox, Wolf };
//    public enum AnimalKind { Rabbit = 1, Sheep = 6, Pig = 12, Cow = 36, Horse = 72, SmallDog = 6, BigDog = 36, Fox, Wolf };

    public interface IAnimal
    {
        AnimalKind Kind { get; }
        int BasePoints { get; }
        string Name { get; }
        bool IsWild { get; }
    }
}
