using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateSQLServerData.Models
{
    public class CustomerSpender
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public decimal Total { get; set; }
    }
}