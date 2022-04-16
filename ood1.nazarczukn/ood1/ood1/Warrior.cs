using System;
using Enemies;

namespace Defenders
{
    class Warrior : IDefender
    {
        protected readonly string name;
        protected readonly int strength;
        protected static readonly Random rng = new Random(1597);

        public Warrior(string name, int strength)
        {
            this.name = name;
            this.strength = strength;
        }

        public virtual void Attack(Giant g)
        {
            Console.WriteLine($"Warrior {name} attacked Giant {g.Name} with for {strength} damage.");
            g.GetDamage(strength);
        }

        public virtual void Attack(Ogre o)
        {
            Console.WriteLine($"Warrior {name} attacked Ogre {o.Name} with for {strength} damage.");
            o.GetDamage(Math.Max(1, strength - o.Armor));

        }

        public virtual void Attack(Rat r)
        {
            if (rng.NextDouble() < r.Speed / 100)
            {
                Console.WriteLine($"Warrior {name} missed Rat {r.Name}");
            }
            else
            {
                Console.WriteLine($"Warrior {name} attacked Rat {r.Name} with for {strength} damage.");
                r.GetDamage(strength);
            }

        }
    }
}