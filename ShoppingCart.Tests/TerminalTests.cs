using NUnit.Framework;
using ShoppingCart;
using ShoppingCart.Interfaces;

[TestFixture]
public class TerminalTests
{
    private ITerminal _terminal;

    [SetUp]
    public void Setup()
    {
        _terminal = new Terminal();

        // Set up the pricing for products
        _terminal.SetPricing("A", 2.00m, 7.00m, 4);
        _terminal.SetPricing("B", 12.00m);
        _terminal.SetPricing("C", 1.25m, 6.00m, 6);
        _terminal.SetPricing("D", 0.15m);
    }

    [Test]
    public void Test_Total_For_ABCDABAA()
    {
        // Scan items
        string[] items = { "A", "B", "C", "D", "A", "B", "A", "A" };
        foreach (var item in items)
        {
            _terminal.Scan(item);
        }

        // Assert the total
        decimal total = _terminal.Total();
        Assert.That(total, Is.EqualTo(32.40m));
    }

    [Test]
    public void Test_Total_For_CCCCCCC()
    {
        // Scan items
        string[] items = { "C", "C", "C", "C", "C", "C", "C" };
        foreach (var item in items)
        {
            _terminal.Scan(item);
        }

        // Assert the total
        decimal total = _terminal.Total();
        Assert.That(total, Is.EqualTo(7.25m));
    }

    [Test]
    public void Test_Total_For_ABCD()
    {
        // Scan items
        string[] items = { "A", "B", "C", "D" };
        foreach (var item in items)
        {
            _terminal.Scan(item);
        }

        // Assert the total
        decimal total = _terminal.Total();
        Assert.That(total, Is.EqualTo(15.40m));
    }

    [Test]
    public void Test_Total_For_ExactVolumeDiscount()
    {
        // Scan items
        // 4 "A"s will trigger the volume discount
        string[] items = { "A", "A", "A", "A" };
        foreach (var item in items)
        {
            _terminal.Scan(item);
        }

        // Assert the total
        decimal total = _terminal.Total();
        // 4 for $7.00
        Assert.That(total, Is.EqualTo(7.00m));
    }

    [Test]
    public void Test_Total_For_VolumeDiscountPlusExtras()
    {
        // Scan items
        // 5 "A"s
        string[] items = { "A", "A", "A", "A", "A" };
        foreach (var item in items)
        {
            _terminal.Scan(item);
        }

        // Assert the total
        decimal total = _terminal.Total();
        // 4 for $7.00 + 1 for $2.00
        Assert.That(total, Is.EqualTo(9.00m));
    }
}
