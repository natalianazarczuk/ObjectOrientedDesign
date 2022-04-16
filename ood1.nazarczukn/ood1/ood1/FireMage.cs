using System;
using Enemies;

namespace Defenders
{
    class FireMage : Mage
    {
        private double killChance;
        protected static readonly Random rng = new Random(1597);

        public FireMage(string name, int mana, int manaRegen, int spellPower, double killChance) : base(name, mana, manaRegen, spellPower)
        {
            this.killChance = killChance;
        }
        public override void Attack(Giant g)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"FireMage {name} instantly kills {g.Name}");
                    g.GetDamage(g.HP);
                }
                else
                {
                    Console.WriteLine($"FireMage {name} attacked Giant {g.Name} with for {spellPower} damage.");
                    g.GetDamage(spellPower);
                }
            }
        }

        public override void Attack(Ogre o)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"FireMage {name} instantly kills {o.Name}");
                    o.GetDamage(o.HP);
                }
                else
                {
                    Console.WriteLine($"FireMage {name} attacked Ogre {o.Name} with for {spellPower} damage.");
                    o.GetDamage(Math.Max(1, spellPower - o.Armor));
                }

            }
        }

        public override void Attack(Rat r)
        {
            if (CanCastSpell())
            {
                if (rng.NextDouble() < killChance)
                {
                    Console.WriteLine($"FireMage {name} instantly kills {r.Name}");
                    r.GetDamage(r.HP);
                }
                else
                {
                    Console.WriteLine($"FireMage {name} attacked Rat {r.Name} with for {spellPower} damage.");
                    r.GetDamage(spellPower);
                }

            }
        }
    }
}