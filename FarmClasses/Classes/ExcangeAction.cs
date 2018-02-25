using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Classes
{
    class ExcangeAction : IExcangeAction
    {
        private IAnimal animalFrom;
        private int animalFromCount;
        private IAnimal animalTo;
        private int animalToCount;

        public IAnimal AnimalFrom => animalFrom;

        public int AnimalFromCount => animalFromCount;

        public IAnimal AnimalTo => animalTo;

        public int AnimalToCount => animalToCount;

        public ExcangeAction(IAnimal animalFrom, int animalFromCount, IAnimal animalTo, int animalToCount)
        {
            this.animalFrom = animalFrom;
            this.animalFromCount = animalFromCount;
            this.animalTo = animalTo;
            this.animalToCount = animalToCount;
    }

}
}
