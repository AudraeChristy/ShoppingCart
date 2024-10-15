using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Product
    {
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VolumePrice { get; set; }
        public int VolumeQuantity { get; set; }

        public Product(string code, decimal unitPrice, decimal volumePrice = 0, int volumeQuantity = 0)
        {
            Code = code;
            UnitPrice = unitPrice;
            VolumePrice = volumePrice;
            VolumeQuantity = volumeQuantity;
        }
    }
}
