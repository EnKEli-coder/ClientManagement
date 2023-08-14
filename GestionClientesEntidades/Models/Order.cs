using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int? OrderNumber { get; set; }
        public int? ClientID { get; set; }
        public int Campaign { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; } 
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Client Client { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
