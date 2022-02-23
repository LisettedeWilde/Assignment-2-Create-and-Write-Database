using ManipulateSQLServerData.Models;
using ManipulateSQLServerData.Repositories;
using System;
using System.Collections.Generic;

namespace ManipulateSQLServerData
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
        }

        /// <summary>
        /// Prints the resulting list from GetAllCustomers to the console, which for all customers contains their: id, first name, last name, country, postal code, phone number and email 
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        /// <summary>
        /// Prints the result from GetCustomer to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(1));
        }

        /// <summary>
        /// Prints the result from GetCustomerByName to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Tim", "Goyer"));
        }

        /// <summary>
        /// Prints the result from GetPageOfCustomers to the console, which is a section from the customer table
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectPage(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetPageOfCustomers(5, 10));
        }

        /// <summary>
        /// Checks whether the customer gets added correctly to the database with the method AddNewCustomer, writes a message to the console whether the addition was successful
        /// </summary>
        /// <param name="repository"></param>
        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "Harry",
                LastName = "Potter",
                Country = "Britain",
                PostalCode = "5208",
                Phone = "06 12345678",
                Email = "wizard@apple.com"
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("Successfully added customer to database");
            }
            else
            {
                Console.WriteLine("Failed to add customer to database");
            }
        }

        /// <summary>
        /// Checks whether the customer gets updated correctly in the database with the method UpdateCustomer, writes a message to the console whether the update was successful
        /// </summary>
        /// <param name="repository"></param>
        static void TestUpdate(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "Harry",
                LastName = "Potter",
                Country = "Britain",
                PostalCode = "5208",
                Phone = "06 12345678",
                Email = "wizard@apple.com"
            };
            if (repository.UpdateCustomer(3, test))
            {
                Console.WriteLine("Successfully updated customer in database");
            }
            else
            {
                Console.WriteLine("Failed to updated customer in database");
            }
        }

        /// <summary>
        /// Prints the result from GetNumberOfCustomersPerCountry to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestGetCountriesCount(ICustomerRepository repository)
        {
            Dictionary<string, int> result = repository.GetNumberOfCustomersPerCountry();

            foreach (KeyValuePair<string, int> country in result)
            {
                Console.WriteLine($"{country.Key} {country.Value}");
            }
        }

        /// <summary>
        /// Prints the result of TopSpenders to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestGetHighestSpenders(ICustomerRepository repository)
        {
            List<CustomerSpender> spenders = repository.TopSpenders();

            foreach (CustomerSpender spender in spenders)
            {
                Console.WriteLine($"{spender.CustomerId} {spender.LastName} {spender.Total}");
            }
        }

        /// <summary>
        /// Prints the result of GetFavoriteGenre to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestGetFavoriteGenre(ICustomerRepository repository)
        {
            Console.WriteLine(repository.GetFavoriteGenre(12));
        }

        /// <summary>
        /// Loops through an IEnumerable of Customers and prints them to the console
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        /// <summary>
        /// Prints a Customer object to the console
        /// </summary>
        /// <param name="customer"></param>
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
        }
    }
}
