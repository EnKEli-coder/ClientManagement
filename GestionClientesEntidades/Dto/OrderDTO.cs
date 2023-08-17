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
        public List<ClientList>? ClientList { get; set; } = null;
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public Order? Order { get; set; }
        public List<Product>? Products { get; set; }
    }
}
