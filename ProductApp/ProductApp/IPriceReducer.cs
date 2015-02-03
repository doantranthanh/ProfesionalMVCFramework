using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    public interface IPriceReducer
    {
        void ReducePrices(decimal priceReduction);
    }
}
