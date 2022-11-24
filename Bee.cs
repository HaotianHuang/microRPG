using System;
using static System.Console;

namespace InheritanceGameDemo
{
	class Bee : Enemy
	{
        
        private bool HasPoisonSting;

        public Bee(string name, int health, ConsoleColor color, bool hasPoison)
            : base(name, health, color, ArtAssets.Bee)
		{
          
            HasPoisonSting = hasPoison;

        }

        public void Fly()
        {
            BackgroundColor = Color;
            Write($" {Name}");
            ResetColor();
            WriteLine(" takes to the air!");
        }

        public void Sting()
        {
            BackgroundColor = Color;
            Write($" {Name}");
            ResetColor();
            Write(" lunges forward with their ");
            if (HasPoisonSting) Write("poison stinger!");
            else Write("sharp stinger!");
            
        }
          
	}
}

