using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.MongoDb
{
   
    public class OrderService
    {

        private readonly IMongoCollection<Order> _orders;

        public OrderService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("OrderMongoDb"));
            var database = client.GetDatabase("OrderMongoDb");
            _orders = database.GetCollection<Order>("Orders");
        }

        public List<Order> Get()
        {
            return _orders.Find(order => order.isShipped == false).ToList();
        }

        public List<Order> Get(string customerId)
        {
            return _orders.Find(order => order.isShipped == false & order.CustomerId == customerId).ToList();
        }

        public Order GetOrder(string id)
        {
            return _orders.Find<Order>(order => order.OrderId == id).FirstOrDefault();
        }


        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        public void Update(string id, Order newOrder)
        {
            _orders.ReplaceOne(order => order.OrderId == id, newOrder);
        }

    }
}
