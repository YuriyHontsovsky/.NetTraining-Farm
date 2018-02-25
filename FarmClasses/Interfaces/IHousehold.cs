using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    public interface IHousehold
    {
        IReadOnlyList<IHousehold> Competitors { get; }
        string Name { get; }
        int GetAnimalCount(IAnimal animal);
    }
}
