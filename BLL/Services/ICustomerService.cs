using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;

namespace BLL.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomersData();
    }

    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomersData()
        {
            var customersData = new List<Customer>
            {
                new Customer()
                {
                    Id = 101,
                    Name = "Customer1",
                    Country = "India"
                },
                new Customer()
                {
                    Id = 102,
                    Name = "Customer2",
                    Country = "USA"
                }
            };

            return customersData;
        }
    }
}
