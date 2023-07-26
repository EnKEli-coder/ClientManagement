using GestionClientesEntidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Dto
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int? OrderNumber { get; set; }
        public int? ClientID { get; set; }
        public int Campaign { get; set; }
        public decimal Total { get; set; }
        public string? State { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Product>? Products { get; set; }
    }
}
