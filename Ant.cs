using System;
using static System.Console;

namespace InheritanceGameDemo
{
	class Ant : Character
	{
        private Item CurrentItem;
        private int ChargeDistance;

        public Ant(string name, int health, ConsoleColor color, int chargeDistance)
            : base(name, health, color, ArtAssets.Ant)
		{
          
            ChargeDistance = chargeDistance;

        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }

        public void Charge()
        {
            BackgroundColor = Color;
            Write($" {Name}");
            ResetColor();
            WriteLine($" charges swiftly forward {ChargeDistance} inches!");

            if (CurrentItem != null)
            {
                WriteLine($"They are carrying a {CurrentItem.Name}.");
            }
        }

        public void Bite()
        {
            BackgroundColor = Color;
            Write($" {Name}");
            ResetColor();
            WriteLine(" viciously chomps dow!");
        }

        public override void Fight(Character otherCharacter)
        {

            // Options:
            // - 50% hit with a bite for 4 damage.
            // - 50% miss with a bite. 

            ForegroundColor = Color;
            WriteLine($"Ant {Name} is fighting {otherCharacter.Name}!");
            ResetColor();
            int randNum = RandGenerator.Next(1, 101);
            Write($"Ant {Name} bites at {otherCharacter.Name} and ");
            if (randNum <= 50) 
            {
                WriteLine("hits for 4 damage!");
                otherCharacter.TakeDamage(4);
            }
            else 
            {
                WriteLine("misses...");
            }
            ResetColor();
        }
          
	}
}

