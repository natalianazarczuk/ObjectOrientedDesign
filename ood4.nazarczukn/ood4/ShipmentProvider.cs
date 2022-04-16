using System.Collections.Generic;
using System.Linq;
using OrderProcessing.Orders;

namespace OrderProcessing.Shipment
{
    public interface IShipmentProvider
    {
        string Name { get; }

        void RegisterForShipment(IShippableOrder order);

        string GetLabelForOrder(IShippableOrder order);

        IEnumerable<IParcel> GetParcels();
    }

    public class LocalPost : IShipmentProvider
    {
        public List<IShippableOrder> orders = new List<IShippableOrder>();

        public string Name => "LocalPost";

        public string GetLabelForOrder(IShippableOrder order)
        {
            var x = new LabelFormatter();
            var label = x.GenerateLabelForOrder(Name, order.Recipient);
            return label;
        }

        public IEnumerable<IParcel> GetParcels()
        {
            //var parcel = new Parcel();
            //parcel.ShipmentProviderName = Name;
            //parcel.BundleHeader = orders[0].Recipient.Country;
            //parcel.Summary;
            //parcel.BundlePrice = orders.Sum()
            //var calculator  = new LinearTaxCalculator();
            //var summary = new SummaryFormatter(calculator);
            //summary.PrintHeader(parcel.BundleHeader);
            //summary.PrintOrdersSummary(orders);
            throw new System.NotImplementedException();
        }

        public void RegisterForShipment(IShippableOrder order)
        {
            orders.Add(order);
        }
    }

    public class Global : IShipmentProvider
    {
        public List<IShippableOrder> orders = new List<IShippableOrder>();

        public string Name => "Global";

        public string GetLabelForOrder(IShippableOrder order)
        {
            var x = new LabelFormatter();
            var label = x.GenerateLabelForOrder(Name, order.Recipient);
            return label;
        }

        public IEnumerable<IParcel> GetParcels()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterForShipment(IShippableOrder order)
        {
            orders.Add(order);           
        }
    }
}