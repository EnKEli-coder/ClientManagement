using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Dto
{
    public class ClientDTO
    {
        public int? ID { get; set; }
        public int? ConsultantID{ get; set; }
        public string? Name { get; set; }
        public string? ConsultantType { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Observations { get; set;}
    }
}
