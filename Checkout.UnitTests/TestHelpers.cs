using Checkout.Service.Interfaces;
using Checkout.Service.Models;
using Checkout.Service.Services;

namespace Checkout.UnitTests;

public static class TestHelpers
{
    public static ICheckout CreateCheckoutWithOneRule()
    {
        var testRules = new List<PriceRule>
        {
            new PriceRule ("A", 50)
        };
        return new CheckoutProcessor(testRules);
    }

    public static ICheckout CreateCheckoutWithTwoRules()
    {
        var testRules = new List<PriceRule>
        {
            new PriceRule ("A", 50),
            new PriceRule ("B", 30)
        };
        return new CheckoutProcessor(testRules);
    }

    public static ICheckout CreateCheckoutWithRulesAndSpecialPrices()
    {
        var testRules = new List<PriceRule>
        {
            new PriceRule("A", 50, 3, 130),
            new PriceRule("B", 30, 2, 45),
            new PriceRule("C", 20),
            new PriceRule("D", 15)
        };
        return new CheckoutProcessor(testRules);
    }
}
