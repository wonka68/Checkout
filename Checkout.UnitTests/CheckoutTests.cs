using Checkout.Service.Interfaces;
using Checkout.Service.Models;
using Checkout.Service.Services;

namespace Checkout.UnitTests;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    private ICheckout CreateCheckoutWithOneRule()
    {
        var testRules = new List<PriceRule>
        {
            new PriceRule ("Product", 100)
        };
        return new CheckoutProcessor(testRules);
    }

    [Test]
    public void CanScanAnItemWithoutException()
    {
        // Arrange
        var checkout = CreateCheckoutWithOneRule();

        // Act
        checkout.Scan("Product");

        // Assert
        Assert.Pass();
    }

    [Test]
    public void CanScanAnItemAndReturnCorrectPrice()
    {
        // Arrange
        var checkout = CreateCheckoutWithOneRule();

        // Act
        checkout.Scan("Product");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }
}