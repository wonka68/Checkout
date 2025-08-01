namespace Checkout.Service.Models;

public class PriceRule
{
    public string SKU { get; set; }
    public int UnitPrice { get; set; }
    public int? SpecialPrice { get; set; }
    public int? DiscountedQuantity { get; set; }

    public PriceRule(string sku, int unitPrice, int? discountedQuantity = null, int? specialPrice = null)
    {
        SKU = sku;
        UnitPrice = unitPrice;
        DiscountedQuantity = discountedQuantity;
        SpecialPrice = specialPrice;
    }
}
