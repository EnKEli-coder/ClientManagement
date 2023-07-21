using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Models
{
    public class Client
    {
        public int ID { get; set; }
        public int? ConsultantId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(20)]
        public string? ConsultantType { get; set; }
        [StringLength(20)]
        public string? Telephone { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(1000)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [StringLength(1000)]
        public string? Observations { get; set;}

        public ICollection<Order> Orders { get; set;}
    }
}
