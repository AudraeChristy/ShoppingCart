namespace ShoppingCart.Interfaces
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();
        void SetPricing(string productCode, decimal unitPrice, decimal volumePrice = 0, int volumeQuantity = 0);
    }
}