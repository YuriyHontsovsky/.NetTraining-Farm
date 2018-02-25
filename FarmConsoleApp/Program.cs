using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vinner = FarmClasses.FarmEgine.Play(
                (string text) => Console.WriteLine(text),
                new KeyValuePair<string, FarmClasses.Interfaces.IExcangeStrategy>("Player 1", new FarmClasses.Classes.ExcangeStrategy()),
                new KeyValuePair<string, FarmClasses.Interfaces.IExcangeStrategy>("Player 2", new FarmClasses.Classes.ExcangeStrategy()),
                new KeyValuePair<string, FarmClasses.Interfaces.IExcangeStrategy>("Player 3", new FarmClasses.Classes.ExcangeStrategy()));
            Console.ReadLine();
        }
    }
}
