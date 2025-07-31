using Checkout.Service.Interfaces;
using Checkout.Service.Services;

namespace Checkout.UnitTests;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    private ICheckout CreateCheckoutWithDefaultRules()
    {
        return new CheckoutProcessor();
    }

    [Test]
    public void CanScanAnItem()
    {
        // Arrange
        var checkout = CreateCheckoutWithDefaultRules();

        // Act
        checkout.Scan("Product");

        // Assert
        Assert.Pass();
    }
}