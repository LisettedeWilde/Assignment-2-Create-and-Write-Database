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
        /// <summary>
        /// Reads all the customers in the database
        /// </summary>
        /// <returns>A list of Customers with their id, first name, last name, country, postal code, phone number and email</returns>
        public List<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        /// <summary>
        /// Reads a specific customer by name
        /// </summary>
        /// <param name="fName">first name</param>
        /// <param name="lName">last name</param>
        /// <returns>A customer with their id, first name, last name, country, postal ccode, phone number and email</returns>
        public Customer GetCustomerByName(string fName, string lName);
        public List<Customer> GetPageOfCustomers(int limit, int offset);
        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="customer">Customer variable to be added to the database</param>
        /// <returns>A boolean value based on if the addition of the customer to the database was successfull</returns>
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Gets the number of customers in each country
        /// </summary>
        /// <returns>Returns a dictionary with the country as key value and the number of entries in that country as the value</returns>
        public Dictionary<string, int> GetNumberOfCustomersPerCountry();
        public List<CustomerSpender> TopSpenders();

        /// <summary>
        /// Returns the most popular genre for a given customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The first and last name of the customer and their favorite genre</returns>
        public string GetFavoriteGenre(int id);
    }
}
