using Checkout.Service.Interfaces;
using Checkout.Service.Services;

namespace Checkout.UnitTests;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    private ICheckout CreateCheckoutWithNoRules()
    {
        return new CheckoutProcessor();
    }

    [Test]
    public void CanScanAnItem()
    {
        // Arrange
        var checkout = CreateCheckoutWithNoRules();

        // Act
        checkout.Scan("Product");

        // Assert
        Assert.Pass();
    }
}