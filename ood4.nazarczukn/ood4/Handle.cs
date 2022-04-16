using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Orders
{

    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract string Handle(Order o);
    }


    //Every PayPal payment has a 30% probability to fail (Random set with seed 1234)
    public class Paypal : Handler
    {
        public override string Handle(Order o)
        {
            int rnd = new Random().Next(0, 10);            

            foreach (var p in o.SelectedPayments)
            {
                if (p.PaymentType == Payments.PaymentMethod.PayPal)
                {
                    if (rnd != 0)
                    {
                        o.Status = OrderStatus.PaymentProcessing;
                        o.FinalizedPayments.Add(p);
                        Console.WriteLine( $"Order {o.OrderId} paid {p.Amount} via PayPal.");

                        if (o.AmountToBePaid <= o.PaidAmount)
                        {
                            o.Status = OrderStatus.ReadyForShipment;
                            return $"Order {o.OrderId} is ready for shipment.\n";
                        }
                    }
                    else
                        Console.WriteLine($"Order {o.OrderId} payment PayPal has failed.");
                }
            }

            if (successor != null)
            {
                successor.Handle(o);
            }
                return null;
        }
    }

    //every third invoice fails
    public class Invoice : Handler
    {
        public override string Handle(Order o)
        {
            int rnd = new Random().Next(0, 3);

            foreach (var p in o.SelectedPayments)
            {
                if (p.PaymentType == Payments.PaymentMethod.Invoice)
                {
                    if (rnd == 0)
                    {
                        o.Status = OrderStatus.PaymentProcessing;
                        o.FinalizedPayments.Add(p);
                        Console.WriteLine($"Order {o.OrderId} paid {p.Amount} via Invoice.");

                        if (o.AmountToBePaid <= o.PaidAmount)
                        {
                            o.Status = OrderStatus.ReadyForShipment;
                            return $"Order {o.OrderId} is ready for shipment.\n";
                        }
                    }
                    else
                        Console.WriteLine($"Order {o.OrderId} payment Invoice has failed.");
                }
            }

            if (successor != null)
            {
                successor.Handle(o);
            }
                return null;
        }
    }


    public class CreditCard : Handler
    {
        public override string Handle(Order o)
        { 

            foreach (var p in o.SelectedPayments)
            {
                if (p.PaymentType == Payments.PaymentMethod.CreditCard)
                {
                    o.Status = OrderStatus.PaymentProcessing;
                    o.FinalizedPayments.Add(p);
                    Console.WriteLine($"Order {o.OrderId} paid {p.Amount} via CreditCard.");
                
                    if (o.AmountToBePaid <= o.PaidAmount)
                    {
                        o.Status = OrderStatus.ReadyForShipment;
                        return $"Order {o.OrderId} is ready for shipment.\n";
                    }
                }
            }

            if (successor != null)
            {
                successor.Handle(o);
            }
         
                return null;
        }
    }

}
