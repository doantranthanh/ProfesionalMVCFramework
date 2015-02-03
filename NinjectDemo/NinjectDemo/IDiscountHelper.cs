using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public interface IDiscountHelper
    {
        Decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        private decimal discountRate;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountRate = discountParam;
        }
        public Decimal ApplyDiscount(decimal totalPram)
        {
            return (totalPram - (discountRate / 100m * totalPram));
        }
    }
}
