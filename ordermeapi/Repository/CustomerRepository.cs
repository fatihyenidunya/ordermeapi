using ordermeapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Repository
{
    public class CustomerRepository :ICustomerRepository
    {
        public OrderMeDbContext _ctx;


        public CustomerRepository(OrderMeDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteCustomer(int id)
        {

            try
            {

                var customer = _ctx.Customers.Where(x => x.Id == id).FirstOrDefault();

                _ctx.Customers.Remove(customer);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _ctx.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Customer> Customers()
        {
            return _ctx.Customers.ToList();
        }

        public void SaveCustomer(Customer customer)
        {
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            Customer oldCustomer = _ctx.Customers.Where(d => d.Id == id).FirstOrDefault();

            if (oldCustomer != null)
            {

                oldCustomer.Name = customer.Name;
                oldCustomer.Address = customer.Address;
              

            }

            _ctx.SaveChanges();


            return _ctx.Customers.Where(d => d.Id == id).FirstOrDefault();

        }

    }
}
