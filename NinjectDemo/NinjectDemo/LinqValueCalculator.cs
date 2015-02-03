using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
       
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public Decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p=>p.Price));
        }
    }
}
