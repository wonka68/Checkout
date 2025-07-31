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
            new PriceRule ("A", 50),
            new PriceRule ("B", 30)
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
        checkout.Scan("A");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(50));
    }

    [Test]
    public void CanScanTwoItemsAndReturnCorrectPrice()
    {
        // Arrange
        var checkout = CreateCheckoutWithOneRule();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }
}