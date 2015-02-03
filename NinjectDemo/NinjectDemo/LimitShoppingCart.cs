using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public class LimitShoppingCart : ShoppingCart
    {
        
        public LimitShoppingCart(IValueCalculator calcParam) : base(calcParam) { }

        public override decimal CalculateStockValue()
        {
            var filteredProducts = products.Where(e => e.Price < ItemLimit);

            return calculator.ValueProducts(filteredProducts.ToArray());
        }

        public decimal ItemLimit { get; set; }
    }
}
