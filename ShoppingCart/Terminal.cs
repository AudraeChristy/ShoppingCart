using ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Terminal : ITerminal
    {
        private Dictionary<string, Product> _products;
        private Dictionary<string, int> _cart;

        public Terminal()
        {
            _products = new Dictionary<string, Product>();
            _cart = new Dictionary<string, int>();
        }

        public void SetPricing(string productCode, decimal unitPrice, decimal volumePrice = 0, int volumeQuantity = 0)
        {
            _products[productCode] = new Product(productCode, unitPrice, volumePrice, volumeQuantity);
        }

        public void Scan(string item)
        {
            if (_products.ContainsKey(item))
            {
                if (_cart.ContainsKey(item))
                    _cart[item]++;
                else
                    _cart[item] = 1;
            }
            else
            {
                throw new ArgumentException("Invalid product code.");
            }
        }

        public decimal Total()
        {
            decimal total = 0;

            foreach (var entry in _cart)
            {
                var product = _products[entry.Key];
                int quantity = entry.Value;

                if (product.VolumeQuantity > 0 && quantity >= product.VolumeQuantity)
                {
                    int volumeSets = quantity / product.VolumeQuantity;
                    int remainder = quantity % product.VolumeQuantity;

                    total += volumeSets * product.VolumePrice + remainder * product.UnitPrice;
                }
                else
                {
                    total += quantity * product.UnitPrice;
                }
            }

            return total;
        }
    }

}
