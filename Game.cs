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

        private Player CurrentPlayer;
        private Character CurrentEnemy;
        private List<Character> Enemies;

        public Game()
        {
            Ant fireAuntie = new Ant("Fire Auntie", 5, ConsoleColor.Red, 3);
            
            Ant hades = new Ant("Hades", 10, ConsoleColor.Magenta, 6);
            Item leafNinjaStar = new Item("Leaf Ninja Star", 10);
            hades.PickUpItem(leafNinjaStar);

            Bee buzzBee = new Bee("BuzzBee", 15, ConsoleColor.DarkYellow, true);

            // Polymorphism 
            Enemies = new List<Character>() { fireAuntie, hades, buzzBee};

        }

        public void Run()
        {
            WriteLine("##### Micro RPG #####\n");

            // Doing here because may want to ask user for inputs after title screen.
            CurrentPlayer = new Player("Lucas", 20, ConsoleColor.Green);
            CurrentPlayer.DisplayInfo();

            CurrentEnemy = Enemies[0];

            while (true)
            {    
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentPlayer.Fight(CurrentEnemy);

                WriteLine();
                WaitForKey();

                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentEnemy.Fight(CurrentPlayer);


                WaitForKey();   
            }

            // CurrentPlayer.DisplayHealthBar();
            // CurrentEnemy.DisplayHealthBar();

            // CurrentEnemy.Fight(CurrentPlayer);

            // CurrentPlayer.DisplayHealthBar();
            // CurrentEnemy.DisplayHealthBar();

            // Loop! 
            // Show health bars, so player can decide attack.
            // Let the player attack the current enemy and display the results.
            // Re-show the health bars, so player can see the result.
            // Check if player or enemy is dead. 
            // Let the enemy attack the player and print out the result. 


            WaitForKey();

        }

        private void WaitForKey()
        {
            WriteLine("\nPress any key to continue...\n");
            ReadKey(true);
        }
    }

}
