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
    }
}
