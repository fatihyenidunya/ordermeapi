using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Entities
{
    public class Product
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int ProductCategoryId { get; set; }
        public Category Category { get; set; }


    }
}
