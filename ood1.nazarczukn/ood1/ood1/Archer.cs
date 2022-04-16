using System;
using Enemies;

namespace Defenders
{
    class Archer : Warrior
    {
        private int arrows;

        public Archer(string name, int strength, int arrows) : base(name, strength)
        {
            this.arrows = arrows;
        }

        public override void Attack(Giant g)
        {
            for (int i = 0; i < 2; i++)
            {
                if (arrows > 0)
                {
                    Console.WriteLine($"Archer {name} attacked Giant {g.Name} with for {strength} damage.");
                    g.GetDamage(strength);
                    arrows--;
                }
                else
                {
                    Console.WriteLine("No more arrows");
                }
            }
        }

        public override void Attack(Ogre o)
        {
            Console.WriteLine($"Archer {name} attacked Ogre {o.Name} with for {strength} damage.");
            o.GetDamage(Math.Max(1, strength - o.Armor));
            arrows--;

        }

        public override void Attack(Rat r)
        {
            if (rng.NextDouble() < r.Speed / 100) return;
            Console.WriteLine($"Archer {name} attacked Rat {r.Name} with for {strength} damage.");
            r.GetDamage(strength);
            arrows--;
        }
    }
}