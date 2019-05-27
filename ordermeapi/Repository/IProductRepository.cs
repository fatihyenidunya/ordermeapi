using ordermeapi.Entities;
using ordermeapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products();
        IEnumerable<ProductModel> ProductMobileResult();
        Product GetProductById(int id);
        Product UpdateProduct(int id, Product product);       
        void DeleteProduct(int id);
        void SaveProduct(Product product);
    }
}
