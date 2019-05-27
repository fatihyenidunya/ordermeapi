using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ordermeapi.Entities;
using ordermeapi.Model;

namespace ordermeapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        public OrderMeDbContext _ctx;


        public ProductRepository(OrderMeDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteProduct(int id)
        {

            try
            {

                var product = _ctx.Products.Where(x => x.ID == id).FirstOrDefault();

                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products.Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<ProductModel> ProductMobileResult()
        {

            IEnumerable<ProductModel> products = null;

            products = from p in _ctx.Products
                       join c in _ctx.Categories on p.CategoryId equals c.ID
                       select new ProductModel
                       {
                           ID=p.ID,
                           Category=c.Name,
                           Description=p.Description,
                           Price=p.Price,
                           Title=p.Title
                           
                       };



            return products;

        }

        public IEnumerable<Product> Products()
        {
            return _ctx.Products.ToList();
        }

        public void SaveProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
        }

        public Product UpdateProduct(int id, Product product)
        {
            Product oldProduct = _ctx.Products.Where(d => d.ID == id).FirstOrDefault();

            if (oldProduct != null)
            {

                oldProduct.Title = product.Title;
                oldProduct.Price = product.Price;
                oldProduct.Description = product.Description;
                oldProduct.ProductCategoryId = product.ProductCategoryId;
                oldProduct.CategoryId = product.CategoryId;
               
            }

            _ctx.SaveChanges();


            return _ctx.Products.Where(d => d.ID == id).FirstOrDefault();

        }
    }
}
