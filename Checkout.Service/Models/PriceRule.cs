namespace Checkout.Service.Models;

public class PriceRule
{
    public string SKU { get; set; }
    public int UnitPrice { get; set; }
    public int? SpecialPrice { get; set; }
    public int? DiscountedQuantity { get; set; }

    public PriceRule(string sku, int unitPrice, int? specialPrice = null, int? discountedQuantity = null)
    {
        SKU = sku;
        UnitPrice = unitPrice;
        SpecialPrice = specialPrice;
        DiscountedQuantity = discountedQuantity;
    }
}
