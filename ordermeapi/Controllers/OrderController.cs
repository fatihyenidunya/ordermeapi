using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ordermeapi.MongoDb;

namespace ordermeapi.Controllers
{

    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet(Name ="Get")]
        public ActionResult<List<Order>> Get()
        {
            return _orderService.Get();
        }

        [HttpGet]
        public ActionResult<List<Order>> GetCustomerOrder(string customerId)
        {
            return _orderService.Get(customerId);
        }



        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }



        [HttpPost]
        public IActionResult Post(Order order)
        {
            _orderService.Create(order);

            return CreatedAtRoute("GetBook", new { id = order.OrderId.ToString() }, order);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Order orderIn)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            _orderService.Update(id, orderIn);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var order = _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            //_orderService.Remove(order.OrderId);

            return NoContent();
        }
    }
}