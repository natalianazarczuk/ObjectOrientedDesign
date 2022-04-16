using System;
using System.Collections.Generic;
using Defenders;

namespace Enemies
{
    abstract class Enemy
    {
        public string Name { get; }
        public bool Alive { get; private set; }
        public int HP { get; private set; }

        protected Enemy(string name, int hp)
        {
            Name = name;
            HP = hp;
            Alive = true;
        }

        protected void GetDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Console.WriteLine($"{Name} is dead...");
                Alive = false;
            }
        }

        public abstract void Accept(IDefender defender);
    }

    //class Enemies
    //{
    //    private List<Enemy> enemies = new List<Enemy>();

    //    public void Attach(Enemy enemy)
    //    {
    //        enemies.Add(enemy);
    //    }

    //    public void Detach(Enemy enemy)
    //    {
    //        enemies.Remove(enemy);
    //    }

    //    public void Accept(IDefender defender)
    //    {
    //        foreach (Enemy e in enemies)
    //        {
    //            e.Accept(defender);
    //        }
    //        Console.WriteLine();
    //    }
    //}
}