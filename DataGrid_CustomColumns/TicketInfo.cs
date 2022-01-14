using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_CustomColumns
{
    public enum OrderStatus { None, New, Processing, Shipped, Received };

    //Defines the customer object
    public class TicketInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Email { get; set; }
        public bool IsMember { get; set; }

        public OrderStatus Status { get; set; }
    }
}
