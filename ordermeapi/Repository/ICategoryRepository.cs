using ordermeapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Repository
{
   public interface ICategoryRepository
    {

        IEnumerable<Category> Categories();
        Category GetCategoryById(int id);
        Category UpdateCategory(int id, Category category);
        void DeleteCategory(int id);
        void SaveCategory(Category category);
    }
}
