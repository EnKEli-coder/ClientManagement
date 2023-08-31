using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Models
{
    public class OrderList
    {
        public int ID { get; set; }
        public int? OrderNumber { get; set; }
        public int? ClientID { get; set; }
        public int Campaign { get; set; }
        public decimal Total { get; set; }
        public string? State { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public string? ClientName { get; set; }
    }
}
