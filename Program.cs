namespace Quetes_Classe
{
    using System;

    class Character
    {
        public string Name { get; }
        public int Points { get; private set; }
        public int Attacks { get; }
        public int Defense { get; }

        public Character(string name, int hp, int attack, int defense)
        {
            Name = name;
            Points = hp;
            Attacks = attack;
            Defense = defense;
        }

        public bool IsAlive()
        {
            return Points > 0;
        }

        public void Attack(Character target)
        {
            if (target.IsAlive())
            {
                int damage = Math.Max(0, Attacks - target.Defense);
                target.Points -= damage;
                Console.WriteLine($"{Name} attaque {target.Name} et retranche {damage} le point points.");
                if (!target.IsAlive())
                {
                    Console.WriteLine($"{target.Name} Perdu");
                }
            }
            else
            {
                Console.WriteLine($"{target.Name} a perdu");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Character player1 = new Character("Joueur 1", 100, 20, 10);
            Character player2 = new Character("Joueur 2", 120, 15, 15);

            
            while (player1.IsAlive() && player2.IsAlive())
            {
                player1.Attack(player2);
                if (player2.IsAlive())
                {
                    player2.Attack(player1);
                }
            }

          
            if (player1.IsAlive())
            {
                Console.WriteLine($"{player1.Name} a gagné!");
            }
            else
            {
                Console.WriteLine($"{player2.Name} a gagné!");
            }
        }
    }

}
