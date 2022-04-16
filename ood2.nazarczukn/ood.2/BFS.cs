using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BFS : IEnumerator<DummyNode>
    {
        private Queue<DummyNode> queue;
        private Queue<DummyNode> visited;

        public BFS(DummyNode node)
        {
            Current = node;
            queue = new Queue<DummyNode>();
            visited = new Queue<DummyNode>();
        }

        public DummyNode Current { get; set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (!visited.Contains(Current))
            {
                queue.Enqueue(Current);
                visited.Enqueue(Current);
            }

            if (queue.Count == 0)
                return false;

            DummyNode node;
            node = queue.Dequeue();
            if (node != null)
            {
                DummyNode first = node.FirstChild;
                while (first != null)
                {
                    queue.Enqueue(first);
                    visited.Enqueue(first);
                    first = first.Next;
                }
            }

            Current = node;
            return true;
        }

        public void Reset()
        {
            Current = null;
        }
    }
}
