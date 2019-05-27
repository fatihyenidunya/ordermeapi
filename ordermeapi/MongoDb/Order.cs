using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.MongoDb
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [BsonElement("CustomerId")]
        public string CustomerId { get; set; }

        [BsonElement("Customer")]
        public string Customer { get; set; }


        [BsonElement("Product")]
        public string Product { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

     

        [BsonElement("Number")]
        public int Number { get; set; }


        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("OrderDate")]
        public string OrderDate { get; set; }


        [BsonElement("TimeStamp")]
        public string TimeStamp { get; set; }


        [BsonElement("isShipped")]
        public Boolean isShipped { get; set; } = false;

    }
}
