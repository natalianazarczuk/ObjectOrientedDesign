using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }

        //cat: the process of selecting is done 300 times, the cat dies with a chance of DeathRate
        public void vaccinate(Cat c)
        {
            for (int i = 0; i < 300; i++)
            {
                var rnd = randomElement.Next(1, 101);
                if (rnd > DeathRate)
                {
                    int x = randomElement.Next(0, Immunity.Length);
                    c.Immunity.Append(Immunity[x]);
                }
                else
                {
                    c.Alive = false;
                    Console.WriteLine($"Vaccinator3000 killed cat {c.ID}.");
                    return;
                }
            }
            Console.WriteLine($"Cat {c.ID} vaccinated. ");
        }

        //dog: the process of selecting is done 3000 times, the dog dies with a DeathRate
        public void vaccinate(Dog d)
        {
            for (int i = 0; i < 3000; i++)
            {
                var rnd = randomElement.Next(1, 101);
                if (rnd > DeathRate)
                {
                    int x = randomElement.Next(0, Immunity.Length);
                    d.Immunity.Append(Immunity[x]);
                }
                else
                {
                    d.Alive = false;
                    Console.WriteLine($"Vaccinator3000 killed dog {d.ID}.");
                    return;
                }
            }
            Console.WriteLine($"Dog {d.ID} vaccinated. ");
        }

        //pig: the process of selecting is done 15 times, the pig dies with a chance of 3*DeathRate
        public void vaccinate(Pig p)
        {
            for (int i = 0; i < 15; i++)
            {
                var rnd = randomElement.Next(1, 101);
                if (rnd > 3 * DeathRate)
                {
                    int x = randomElement.Next(0, Immunity.Length);
                    p.Immunity.Append(Immunity[x]);
                }
                else
                {
                    p.Alive = false;
                    Console.WriteLine($"Vaccinator3000 killed pig {p.ID}.");
                    return;
                }
            }
            Console.WriteLine($"Pig {p.ID} vaccinated. ");
        }
    }
}
