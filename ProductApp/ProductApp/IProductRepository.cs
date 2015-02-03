using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
    }
}
