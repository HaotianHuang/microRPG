using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;
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

            RunIntro();

            // Doing here because may want to ask user for inputs after title screen.
            CurrentPlayer.DisplayInfo();

            for (int i = 0; i < Enemies.Count; i += 1)
            {
                CurrentEnemy = Enemies[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();

                if (CurrentPlayer.IsDead)
                {
                    WriteLine("You were defeated...");
                    WaitForKey();
                    break;
                }
                else
                {
                    WriteLine($"You defeated {CurrentEnemy.Name}!");
                    WaitForKey();
                }
            }

            RunGameOver();

            // Loop! 
            // Show health bars, so player can decide attack.
            // Let the player attack the current enemy and display the results.
            // Re-show the health bars, so player can see the result.
            // Check if player or enemy is dead. 
            // Let the enemy attack the player and print out the result. 


            WaitForKey();

        }

        private void RunIntro()
        { 
            WriteLine("##### Micro RPG #####\n");

            WriteLine(FiggleFonts.Ogre.Render("MicroRPG"));

            Write("What is your name? ");
            string name = ReadLine();
            CurrentPlayer = new Player(name, 20, ConsoleColor.Green);

            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"You wake up outside and look around at a field of blades of grass towering over you...
     /  /          \
/   /   \          /   \
\   \   /          \   /  /
/   /  /     o   \  \  \  \
\  /  /  /  /|\  /  /  /  /
 \ \  \ /   / \  \ /   \ / 
            ");

            ResetColor();
            WaitForKey();

            Clear();
            WriteLine($@" You memory is hazy, but you remember flashes of a science experiment. You accidentally shrunk yourself down to the size of a quarter. You look around and see a colony of ants has taken an interest in you. Looks like you are going to have to fight your way to safety.
            
Are you ready? You've got {Enemies.Count}x opponents to face...");

            CurrentPlayer.DisplayInfo();        
            WaitForKey();
        }

        private void RunGameOver()
        {
            if (CurrentPlayer.IsDead)
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You lose!")}
Defeated in microscopic combat, your journey has come to an end. 
You couldn't make it back to your lab this time. Try again!");
            }
            else
            {
                WriteLine($@"{FiggleFonts.Epic.Render("You win!")}
Your journey is over. Exhausted, you make it back inside to your lab,
get your equipment running again and return yourself to normal size.\n");
            }

            WriteLine(@"Thanks for playing!

~ MJP, https://asciiart.website/index.php?art=animals/insects/ants
~ Unknown artist, https://asciiart.website/index.php?art=animals/insects/bees
            ");
        }

        private void IntroCurrentEnemy()
        {
            Clear();
            ForegroundColor = CurrentEnemy.Color;
            WriteLine("A new enemy approaches!");
            ResetColor();
            CurrentEnemy.DisplayInfo();
            WriteLine();
            WaitForKey();
        }

        private void BattleCurrentEnemy()
        {
            while (CurrentPlayer.IsAlive && CurrentEnemy.IsAlive)
            {    
                // Show health bars, so player can make an informed decision. 
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                // Let the player attack the current enemy and display the results.
                CurrentPlayer.Fight(CurrentEnemy);

                WriteLine();
                WaitForKey();

                // CHeck if player or enemy is dead.
                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }

                // Reshow health bars so player can see result.
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                // Let the enemy attack the player then loop
                CurrentEnemy.Fight(CurrentPlayer);


                WaitForKey();   
            }

            WriteLine("Combat is over.");
        }

        private void WaitForKey()
        {
            WriteLine("\nPress any key to continue...\n");
            ReadKey(true);
        }
    }

}
