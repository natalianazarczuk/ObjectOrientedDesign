using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DFS : IEnumerator<DummyNode>
    {
        private HashSet<DummyNode> visited;
        private Stack<DummyNode> stack;

        public DFS(DummyNode node)
        {
            Current = node;
            visited = new HashSet<DummyNode>();
            stack = new Stack<DummyNode>();
        }

        public DummyNode Current { get; set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (!visited.Contains(Current))
            {
                stack.Push(Current);
                visited.Add(Current);
            }

            if (stack.Count == 0)
                return false;

            DummyNode node;
            node = stack.Pop();
            if (node != null)
            {
                DummyNode first = node.FirstChild;
                while (first != null)
                {
                    stack.Push(first);
                    visited.Add(first);
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
