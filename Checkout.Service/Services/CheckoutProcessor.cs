using Checkout.Service.Interfaces;

namespace Checkout.Service.Services;

public class CheckoutProcessor : ICheckout
{
    private readonly List<string> _scannedItems;

    public CheckoutProcessor()
    {
        _scannedItems = new List<string>();
    }

    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }

    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }
}
