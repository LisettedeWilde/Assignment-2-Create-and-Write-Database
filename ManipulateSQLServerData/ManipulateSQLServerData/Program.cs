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
            TestInsert(repository);
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerByName("Tim", "Goyer"));
        }

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

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
        }
    }
}
