using FarmClasses.Classes;
using FarmClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FarmClasses
{
    public class FarmEgine
    {
        static List<Household> players = new List<Household>();

        internal static List<Household> Players { get => players; }

        static ExchangeRules exchangeRules = new ExchangeRules();

        static private Dice dice1 = new Dice(
            new Dictionary<AnimalKind, int>
            {
                [AnimalKind.Rabbit] = 6,
                [AnimalKind.Sheep] = 3,
                [AnimalKind.Pig] = 2,
                [AnimalKind.Cow] = 1,
                [AnimalKind.Fox] = 1
            });
        static private Dice dice2 = new Dice(
            new Dictionary<AnimalKind, int>
            {
                [AnimalKind.Rabbit] = 6,
                [AnimalKind.Sheep] = 3,
                [AnimalKind.Pig] = 2,
                [AnimalKind.Horse] = 1/*,
                [AnimalKind.Wolf] = 1*/
            });


        public delegate void LogHandler(string text);
        static public event LogHandler Log;
        static private void LogInternal(string text) => Log?.Invoke(text);

        public static IHousehold Play(LogHandler logHandler, params KeyValuePair<string, IExcangeStrategy>[] aPlayers)
        {
            Log += logHandler;
            LogInternal("sarted");
            Players.Clear();
            foreach (var player in aPlayers)
            {
                Players.Add(new Household() { Name = player.Key, Strategy = player.Value });
            }
            LogInternal(string.Format("sarted {0}", Players.Count));

            while (true)
            {
                foreach(var player in Players)
                {
                    LogInternal(string.Empty);
                    DoTurn(player);
                    Console.ReadKey();
                    //Thread.Sleep(1000);
                    if (IsWon(player))
                    {
                        return player;
                    }

                    var action = player.Strategy.Excange(player, exchangeRules);
                    if (exchangeRules.Validate(action))
                    {
                        player.ApplayExcangeAction(action);
                    }

                    if (IsWon(player))
                    {
                        return player;
                    }

                }
            }
        }

        private static bool IsWon(Household player)
        {
            foreach (AnimalKind animalKinnd in Enum.GetValues(typeof(AnimalKind)))
            {
                var animal = Animal.GetAnimal(animalKinnd);
                if ((!animal.IsWild) && (player.GetAnimalCount(animal) == 0))
                {
                    return false;
                }
            }

            return true;
        }

        static void DoTurn(Household player)
        {
            LogInternal(string.Format("Turn {0}", player.Name));
            var animal1 = dice1.GetRandomAnimal();
            var animal2 = dice2.GetRandomAnimal();
            LogInternal(string.Format("{0} {1}", animal1.Name, animal2.Name));
            player.ApplyAnnimals(animal1, animal2);

            foreach(AnimalKind animalKinnd in Enum.GetValues(typeof(AnimalKind)))
            {
                var animal = Animal.GetAnimal(animalKinnd);
                if (!animal.IsWild)
                    LogInternal(string.Format("{0} {1}", player.GetAnimalCount(animal), animal.Name));
            }
        }
    }
}
