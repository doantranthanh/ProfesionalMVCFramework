using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public interface IValueCalculator
    {
        Decimal ValueProducts(params Product[] products);
    }
}
