using ManipulateSQLServerData.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateSQLServerData.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                // Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return custList;
        }

        public Customer GetCustomerByName(string fName, string lName)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE FirstName = @FirstName AND LastName = @LastName";
            try
            {
                // Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", fName);
                        cmd.Parameters.AddWithValue("@LastName", lName);
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                "VALUES(@FirstName,@LastName,@Country,@PostalCode,@Phone,@Email)";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        public Dictionary<string, int> GetNumberOfCustomersPerCountry()
        {
            Dictionary<string, int> countriesCount = new Dictionary<string, int>();
            string sql = "SELECT Country, count(Country) " +
                "FROM Customer " +
                "GROUP BY Country " +
                "ORDER BY 2 DESC";
            try
            {
                // Connect
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();

                    // Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result
                                if (countriesCount.ContainsKey(reader.GetString(0)))
                                    countriesCount[reader.GetString(0)] = reader.GetInt32(1);
                                else
                                {
                                    countriesCount.Add(reader.GetString(0), reader.GetInt32(1));
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return countriesCount;
        }
    }
}
