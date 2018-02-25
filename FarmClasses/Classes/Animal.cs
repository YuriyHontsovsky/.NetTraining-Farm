using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses
{
    public class Animal : IAnimal
    {
        private static Dictionary<AnimalKind, int> BasePointDictionary = new Dictionary<AnimalKind, int>() {
            { AnimalKind.Rabbit,    1 },
            { AnimalKind.Sheep,     6 },
            { AnimalKind.Pig,       12 },
            { AnimalKind.Cow,       36 },
            { AnimalKind.Horse,     72 },
            { AnimalKind.SmallDog,  6 },
            { AnimalKind.BigDog,    36 }
        };
        private static Dictionary<AnimalKind, IAnimal> repository = new Dictionary<AnimalKind, IAnimal>();
        private AnimalKind kind;

        public static IAnimal GetAnimal(AnimalKind kind) {

            if (!repository.TryGetValue(kind, out IAnimal result))
            {
                result = new Animal(kind);
                repository.Add(kind, result);
            }
            return result;
        }

        private Animal()
        {

        }
        private Animal(AnimalKind kind)
        {
            this.kind = kind;
        }

        public AnimalKind Kind => kind;
        public string Name => Kind.ToString();
        public bool IsWild => (Kind == AnimalKind.Wolf) || (Kind == AnimalKind.Fox);
        public int BasePoints => IsWild ? 0 : BasePointDictionary[Kind]; 
    }
}
