using System.Text;

namespace OrderProcessing.Shipment
{
    public interface ILabelFormatter
    {
        string GenerateLabelForOrder(string providerName, IAddress address);
    }

    public class LabelFormatter : ILabelFormatter
    {
        public string GenerateLabelForOrder(string providerName, IAddress address)
        {
            string label = $"Shipment provider: {providerName}\n {address.Name}\n {address.Line1}\n {address.Line2}\n {address.PostalCode}\n";
            if(address.Country != "Polska")
            {
                label += $"{address.Country}\n";
            }
            
            return label;
        }
    }
}