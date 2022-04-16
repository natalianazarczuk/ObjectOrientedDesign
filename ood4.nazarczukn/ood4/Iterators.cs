using OrderProcessing.Databases;
using OrderProcessing.Orders;
using OrderProcessing.Payments;
using OrderProcessing.Shipment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderProcessing
{
    public interface Iterator
    {
        public bool HasMore();
        public Order GetNext();
    }

    class SimpleIterator : Iterator
    {
        LocalOrdersDB database;
        int current;

        public SimpleIterator(LocalOrdersDB db)
        {
            database = db;
            current = 0;
        }
        public bool HasMore()
        {
            return (current < database.Orders.Length) ? true : false;
        }

        public Order GetNext()
        {
            var o = database.Orders[current];
            current++;
            return o;
        }
    }

    class TreeIterator : Iterator
    {
        Queue<OrderNode> nodes;
        OrderNode current;

        public TreeIterator(GlobalOrdersDB db)
        {
            nodes = new Queue<OrderNode>();
            nodes.Enqueue(db.Root);
        }

        public bool HasMore()
        {
            return (nodes.Count > 0);
        }

        public Order GetNext()
        {
            current = nodes.Dequeue();

            OrderNode left = current.Left;
            if (left != null)
            {
                nodes.Enqueue(left);
            }

            OrderNode right = current.Right;
            if (right != null)
            {
                nodes.Enqueue(right);
            }

            return current.Order;
        }
    }

    class FilteringIterator : Iterator
    {
        Iterator iterator;
        private Func<Order, bool> transform;

        public FilteringIterator(Iterator i, Func<Order, bool> t)
        {
            iterator = i;
            transform = t;
        }
        public bool HasMore() => iterator.HasMore();

        public Order GetNext()
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




    //public class BFS : IEnumerator<OrderNode>
    //{
    //    Queue<OrderNode> queue;
    //    Queue<OrderNode> visited;

    //    public BFS(OrderNode root)
    //    {
    //        Current = root;
    //        queue = new Queue<OrderNode>();
    //        visited = new Queue<OrderNode>();
    //    }

    //    public OrderNode Current { get; set; }

    //    object IEnumerator.Current => Current;

    //    public void Dispose() { }

    //    public bool MoveNext()
    //    {
    //        if (!visited.Contains(Current))
    //        {
    //            queue.Enqueue(Current);
    //            visited.Enqueue(Current);
    //        }

    //        if (queue.Count == 0)
    //            return false;

    //        OrderNode node;
    //        node = queue.Dequeue();
    //        if (node != null)
    //        {
    //            OrderNode left = node.Left;
    //            while (left != null)
    //            {
    //                queue.Enqueue(left);
    //                visited.Enqueue(left);
    //                left = left.Left;
    //            }
    //            OrderNode right = node.Right;
    //            while (right != null)
    //            {
    //                queue.Enqueue(right);
    //                visited.Enqueue(right);
    //                right = right.Right;
    //            }
    //        }

    //        Current = node;
    //        return true;
    //    }

    //    public void Reset() { }
    //}


}
