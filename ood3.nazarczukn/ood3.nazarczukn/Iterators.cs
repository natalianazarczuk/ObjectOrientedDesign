using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface Iterator
    {
        public bool HasMore();
        public VirusData GetNext();

    }


    class SimpleIterator : Iterator
    {
        SimpleDatabase database;
        SimpleGenomeDatabase genomes;
        int current;

        public SimpleIterator(SimpleDatabase db, SimpleGenomeDatabase g)
        {
            database = db;
            genomes = g;
            current = 0;
        }
        public bool HasMore()
        {
            return (current < database.Rows.Count) ? true : false;
        }

        public VirusData GetNext()
        {
            VirusData v = new VirusData(database.Rows[current].VirusName, database.Rows[current].DeathRate, database.Rows[current].InfectionRate,
             genomes.genomeDatas.FindAll(_ => _.Id == database.Rows[current].GenomeId));
            current++;

            return v;
        }
    }

    class ExcellIterator : Iterator
    {
        SimpleGenomeDatabase genomes;
        int current;
        string[] names;
        double[] death;
        double[] inf;
        Guid[] gid;

        public ExcellIterator(ExcellDatabase db, SimpleGenomeDatabase g)
        {
            names = db.Names.Split(";");
            string[] d = db.DeathRates.Split(";");
            string[] f = db.InfectionRates.Split(";");
            string[] x = db.GenomeIds.Split(";");

            for (int i = 0; i < d.Length; i++)
            {
                death[i] = double.Parse(d[i]);
                inf[i] = double.Parse(f[i]);
                gid[i] = Guid.Parse(x[i]);
            }

            genomes = g;
            current = 0;
        }

        public bool HasMore()
        {
            return (current < names.Length) ? true : false;
        }

        public VirusData GetNext()
        {
            var g = genomes.genomeDatas.FindAll(_ => _.Id == gid[current]);
            VirusData v = new VirusData(names[current], death[current], inf[current], g);
            current++;
            return v;
        }
    }

    class OvercomplicatedIterator : Iterator
    {
        SimpleGenomeDatabase genomes;
        INode root;
        Queue<INode> nodes;

        public OvercomplicatedIterator(OvercomplicatedDatabase db, SimpleGenomeDatabase g)
        {
            nodes = new Queue<INode>();
            root = db.Root;
            nodes.Enqueue(root);
            genomes = g;
        }

        public bool HasMore()
        {
            return (nodes.Count > 0) ? true : false;
        }

        public VirusData GetNext()
        {
            var current = nodes.Dequeue();
            foreach (var child in current.Children)
                nodes.Enqueue(child);

            var v = new VirusData(current.VirusName, current.DeathRate, current.InfectionRate,
                genomes.genomeDatas.FindAll(_ => _.Tags.Contains(current.GenomeTag)));
            return v;
        }
    }

    class FilteringIterator : Iterator
    {
        Iterator iterator;
        private Func<VirusData, bool> transform;

        public FilteringIterator(Iterator i, Func<VirusData, bool> t)
        {
            iterator = i;
            transform = t;
        }
        public bool HasMore() => iterator.HasMore();

        public VirusData GetNext()
        {
            var v = iterator.GetNext();
            while (iterator.HasMore())
            {
                if (transform(v))
                    return v;
                else
                    v = iterator.GetNext();
            }
            return null;
        }
    }

    class MappingIterator : Iterator
    {
        Iterator iterator;
        private Func<VirusData, VirusData> map;

        public MappingIterator(Iterator i, Func<VirusData, VirusData> m)
        {
            iterator = i;
            map = m;
        }
        public bool HasMore() => iterator.HasMore();

        public VirusData GetNext()
        {
            var v = iterator.GetNext();
            map(v);
            return v;
        }
    }

    class ConcatenatingIterator : Iterator
    {
        Iterator excell;
        Iterator overcomplicated;

        public ConcatenatingIterator(Iterator e, Iterator c)
        {
            excell = e;
            overcomplicated = c;
        }

        public bool HasMore() => excell.HasMore() || overcomplicated.HasMore();

        public VirusData GetNext()
        {
            if (excell.HasMore())
                return excell.GetNext();
            else if (overcomplicated.HasMore()) 
                return overcomplicated.GetNext();

            return null;
        }
    }
}
