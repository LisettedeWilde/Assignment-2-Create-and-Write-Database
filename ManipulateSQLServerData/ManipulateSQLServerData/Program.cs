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
            TestGetFavoriteGenre(repository);
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
        /// Prints the result from GetCustomerByName to the console
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Tim", "Goyer"));
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
