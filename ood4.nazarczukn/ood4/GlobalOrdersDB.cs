using OrderProcessing.Orders;
using System.Collections;
using System.Collections.Generic;

namespace OrderProcessing.Databases
{
    public class GlobalOrdersDB
    {
        public OrderNode Root { get; private set; }

        public GlobalOrdersDB(OrderNode root)
        {
            Root = root;
        }
    }

    public class OrderNode 
    {
        public OrderNode Parent { get; }
        public OrderNode Left { get; }
        public OrderNode Right { get; }
        public Order Order { get; }

        public OrderNode(OrderNode left, OrderNode right, Order order)
        {
            this.Left = left;
            this.Right = right;
            this.Order = order;
        }

        //public IEnumerator<OrderNode> GetEnumerator()
        //{
        //    return new BFS(this);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();

        //}
    }
}