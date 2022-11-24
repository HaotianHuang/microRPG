using System;
using static System.Console;

namespace InheritanceGameDemo
{
	class Ant : Enemy
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
          
	}
}

