using System;
using static System.Console;

namespace InheritanceGameDemo
{
    class Player : Character
    {
        public Player(string name, int health, ConsoleColor color)
            : base(name, health, color, ArtAssets.Player)
        {

        }

        private void ThrowDirtAt(Character otherCharacter)
        {
            WriteLine("You throw a clump of dirt ");
            int randPercent = RandGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                Write("and it hits!");
                otherCharacter.TakeDamage(2);
            }
            else 
            {
                Write("and it misses...");
            }
        }

        private void SwingAt(Character otherCharacter)
        {
            WriteLine("Taking a mighty swing...");
                 int randPercent = RandGenerator.Next(1, 101);
            if (randPercent <= 50)
            {
                Write("and it connects solidly!");
                otherCharacter.TakeDamage(4);
            }
            else 
            {
                Write("and it misses...");
            }
        }

        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;

            // WriteLine($"Player {Name} attacks {otherCharacter.Name}.");

            WriteLine($@"You are facing {otherCharacter.Name}. What would you like to do?
1) Pick up a clump of dirt and throw it (90% chance to do 2 damage).
2) Take a mighty swing with a twig (50% chance to do 4 damage).
            ");

            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                ThrowDirtAt(otherCharacter);
            }            
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                SwingAt(otherCharacter);
            }
            else 
            {
                WriteLine("That's not a valid move. Try again.");
                Fight(otherCharacter);
                return;

            }
            
            ResetColor();
        }
    }
}