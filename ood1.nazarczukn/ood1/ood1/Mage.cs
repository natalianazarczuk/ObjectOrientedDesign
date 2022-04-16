using System;
using Enemies;

namespace Defenders
{
    class Mage : IDefender
    {
        protected readonly string name;
        protected int mana;
        protected readonly int manaRegen;
        protected readonly int spellPower;

        public Mage(string name, int mana, int manaRegen, int spellPower)
        {
            this.name = name;
            this.mana = mana;
            this.manaRegen = manaRegen;
            this.spellPower = spellPower;
        }

        protected bool CanCastSpell()
        {
            if (mana >= spellPower)
            {
                mana -= spellPower;
                return true;
            }

            Console.WriteLine($"Mage {name} is recharging mana");
            RechargeMana();
            return false;
        }

        private void RechargeMana()
        {
            mana += manaRegen;
        }

        public virtual void Attack(Giant g)
        {
            if (CanCastSpell())
            {
                Console.WriteLine($"Mage {name} attacked Giant {g.Name} with for {spellPower} damage.");
                g.GetDamage(spellPower);
            }
        }

        public virtual void Attack(Ogre o)
        {
            if (CanCastSpell())
            {
                Console.WriteLine($"Mage {name} attacked Ogre {o.Name} with for {spellPower} damage.");
                o.GetDamage(Math.Max(1, spellPower - o.Armor));
            }
        }

        public virtual void Attack(Rat r)
        {
            if (CanCastSpell())
            {
                Console.WriteLine($"Mage {name} attacked Rat {r.Name} with for {spellPower} damage.");
                r.GetDamage(spellPower);
            }
        }
    }
}