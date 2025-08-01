namespace Checkout.UnitTests;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CanScanAnItemWithoutException()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithOneRule();

        // Act
        checkout.Scan("A");

        // Assert
        Assert.Pass();
    }

    [Test]
    public void CanScanAnItemAndReturnCorrectPrice()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithOneRule();

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
        var checkout = TestHelpers.CreateCheckoutWithTwoRules();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }

    [Test]
    public void CanScanThreeItemsTriggersSpecialPrice()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithRulesAndSpecialPrices();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(130));
    }
}