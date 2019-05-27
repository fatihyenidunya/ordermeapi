using ordermeapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        public OrderMeDbContext _ctx;


        public CategoryRepository(OrderMeDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteCategory(int id)
        {

            try
            {

                var category = _ctx.Categories.Where(x => x.ID == id).FirstOrDefault();

                _ctx.Categories.Remove(category);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category GetCategoryById(int id)
        {
            return _ctx.Categories.Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<Category> Categories()
        {
            return _ctx.Categories.ToList();
        }

        public void SaveCategory(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
        }

        public Category UpdateCategory(int id, Category category)
        {
            Category oldCategory = _ctx.Categories.Where(d => d.ID == id).FirstOrDefault();

            if (oldCategory != null)
            {

                oldCategory.Name = category.Name;
               

            }

            _ctx.SaveChanges();


            return _ctx.Categories.Where(d => d.ID == id).FirstOrDefault();

        }

    }
}
