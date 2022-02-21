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
        //2.
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer Where CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");
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
        // 4.
        public List<Customer> GetPageOfCustomers(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();
            // string sql = "SELECT * FROM Customer AS Page SKIP (@Offset) LIMIT(@limit)";
            string sql = "SELECT * FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = (!reader.IsDBNull(1) ? reader.GetString(1) : "");
                                customer.LastName = (!reader.IsDBNull(2) ? reader.GetString(2) : "");
                                customer.Country = (!reader.IsDBNull(3) ? reader.GetString(3) : "");
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");

                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers.Skip(offset).Take(limit).ToList();
        }
    }
}
