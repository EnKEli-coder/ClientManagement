using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductKey { get; set; }
        public int OrderID { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

        public Order Order { get; set; }
    }
}
