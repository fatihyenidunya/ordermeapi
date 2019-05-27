using ordermeapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi.Repository
{
   public interface ICustomerRepository
    {

        IEnumerable<Customer> Customers();
        Customer GetCustomerById(int id);
        Customer UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
        void SaveCustomer(Customer customer);

    }
}
