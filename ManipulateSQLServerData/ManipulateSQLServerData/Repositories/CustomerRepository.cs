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
        //2. Read a specific customer from the database (by Id).
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer Where CustomerId = @CustomerId";
            try
            {   
                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);

                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Handle result
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
        // 4. Return a page of customers by name.
        public List<Customer> GetPageOfCustomers(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();
            // string sql = "SELECT * FROM Customer AS Page SKIP (@Offset) LIMIT(@limit)";
            string sql = "SELECT * FROM Customer";
            try
            {
                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        cmd.Parameters.AddWithValue("@limit", limit);

                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
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
        // 6. Update an existing customer.
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer " +
                         "SET FirstName=@FirstName,LastName=@LastName,Company=@Company,Address=@Address,City=@City,State=@State" +
                         ",Country=@Country,PostalCode=@PostalCode,Phone=@Phone,Fax=@Fax,Email=@Email,SupportRepId=@SupportRepId";
            try
            {
                //connection
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    //make a command
                    conn.Open();

                    //reader
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //handle result
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Company", customer.Company);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@City", customer.City);
                        cmd.Parameters.AddWithValue("@State", customer.State);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Fax", customer.Fax);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@SupportRepId", customer.SupportRepId);
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
        // 8. Customers who are the highests spenders (total in invoice table is the largest), ordered descending.                                                       
        public List<CustomerSpender> TopSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();
            string sql = "SELECT CUSTOMER.CustomerId, CUSTOMER.LastName, INVOICE.Total FROM INVOICE" +
                         "   INNER JOIN CUSTOMER ON INVOICE.CustomerId = CUSTOMER.CustomerId" +
                         "   ORDER BY INVOICE.Total DESC";
            try
            {
                //connection
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.CustomerId = reader.GetInt32(0);
                                customerSpender.LastName = reader.GetString(1);
                                customerSpender.Total = reader.GetDecimal(2);
                                spenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
    }
}
