using Checkout.Service.Interfaces;

namespace Checkout.Service.Services;

public class CheckoutProcessor : ICheckout
{
    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }

    public void Scan(string item)
    {
        throw new NotImplementedException();
    }
}
