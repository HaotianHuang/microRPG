using System;
using static System.Console;

namespace InheritanceGameDemo
{
	class Character
	{
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandGenerator { get; protected set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Character(string name, int health, ConsoleColor color, string textArt)
		{
          
                Name = name;
                Health = health;
                MaxHealth = health;
                Color = color;
                TextArt = textArt;
                RandGenerator = new Random();

            }

        public void DisplayInfo()
        {
            BackgroundColor = Color;
            WriteLine($"--- {Name} ---");
            ResetColor();

            ForegroundColor = Color;
            WriteLine($"\n{TextArt}\n");
            WriteLine($"Health: {Health}");
            WriteLine("---");
            ResetColor();
        }
          
        // Needs to take in another parameter so you're fighting someone else
        public virtual void Fight(Character otherCharacter)
        {
            WriteLine("Enemy is fighting!");
        }

        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            if (Health <= 0)
            {
                Health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            ForegroundColor = Color;
            WriteLine($"{Name}'s Health: ");
            ResetColor();
            Write("[");
            // Draw "Health" hit points that are filled in:
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < Health; i++)
            {
                Write(" ");
            }
            // Draw the rest as not filled in:
            BackgroundColor = ConsoleColor.White;
            for (int i = Health; i < MaxHealth; i++)
            {
                Write(" ");
            }
            ResetColor();
            WriteLine($"] {Health}/{MaxHealth}");
        }


	}
}
