using Checkout.Service.Interfaces;
using Checkout.Service.Models;

namespace Checkout.Service.Services;

public class CheckoutProcessor : ICheckout
{
    private readonly Dictionary<string, int> _scannedItems = new();
    private readonly Dictionary<string, PriceRule> _priceRules = new();

    public CheckoutProcessor(IEnumerable<PriceRule> priceRules)
    {
        _priceRules = priceRules.ToDictionary(rule => rule.SKU, rule => rule);
    }

    public int GetTotalPrice()
    {
        int total = 0;

        foreach (var product in _scannedItems)
        {
            string sku = product.Key;
            int quantity = product.Value;
            var rule = _priceRules[sku];

            total += quantity * rule.UnitPrice;
        }

        return total;
    }

    public void Scan(string item)
    {
        if (_scannedItems.ContainsKey(item))
            _scannedItems[item]++;
        else
            _scannedItems[item] = 1;
    }
}
