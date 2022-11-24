using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InheritanceGameDemo
{
    class Game
    {

        private Ant FireAuntie;
        private Ant Hades;
        private Bee BuzzBee;
        private Item LeafNinjaStar;

        public Game()
        {
            FireAuntie = new Ant("Fire Auntie", 100, ConsoleColor.Red, 3);
            
            Hades = new Ant("Hades", 200, ConsoleColor.Magenta, 6);
            LeafNinjaStar = new Item("Leaf Ninja Star", 10);
            Hades.PickUpItem(LeafNinjaStar);

            BuzzBee = new Bee("BuzzBee", 75, ConsoleColor.DarkYellow, true);

        }

        public void Run()
        {
            WriteLine("##### Micro RPG #####\n");

            FireAuntie.DisplayInfo();
            WriteLine("");
            FireAuntie.Charge();
            FireAuntie.Bite();
            WriteLine("");

            Hades.DisplayInfo();
            WriteLine("");
            Hades.Charge();
            Hades.Bite();
            WriteLine("");

            BuzzBee.DisplayInfo();
            WriteLine();
            BuzzBee.Fly();
            BuzzBee.Sting();
            WriteLine("");
            WaitForKey();
        }

        private void WaitForKey()
        {
            WriteLine("Press any key to continue...\n");
            ReadKey(true);
        }
    }

}
