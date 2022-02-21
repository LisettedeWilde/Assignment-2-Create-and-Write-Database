using ManipulateSQLServerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateSQLServerData.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(string id);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);
        public List<Customer> GetPageOfCustomers(int limit, int offset);
        public List<CustomerCountry> GetCustomerCountries();
        public List<CustomerSpender> TopSpenders();
        public CustomerGenre TopPopularGenre(int id);
    }
}
