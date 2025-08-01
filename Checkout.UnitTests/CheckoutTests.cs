namespace Checkout.UnitTests;

public class CheckoutTests
{
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

    [Test]
    public void MixSpecialPriceAndStandardPRice()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithRulesAndSpecialPrices();

        // Act
        for (int i = 0; i < 5; i++)
        {
            checkout.Scan("A");
        }
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(230));
    }

    [Test]
    public void RandomItemsWithDiscounts()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithRulesAndSpecialPrices();

        // Act
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("B");
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(95));
    }

    [Test]
    public void RejectsInvalidProductScanned()
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithRulesAndSpecialPrices();

        // Assert
        Assert.Throws<ArgumentException>(() => checkout.Scan("XYZ"));
    }

    [Test]
    [TestCase(new[] { "A", "C", "A", "D" }, 135)]
    [TestCase(new[] { "A", "C", "A", "A", "B" }, 180)]
    [TestCase(new[] { "A", "C", "A", "A", "B", "D", "B" }, 210)]
    public void HandlesMixturesOfCheckoutItems(IEnumerable<string> SkuItems, int expectedTotalPrice)
    {
        // Arrange
        var checkout = TestHelpers.CreateCheckoutWithRulesAndSpecialPrices();

        // Act
        foreach (var sku in SkuItems)
        {
            checkout.Scan(sku);
        }
        var result = checkout.GetTotalPrice();

        // Assert
        Assert.That(result, Is.EqualTo(expectedTotalPrice));
    }
}