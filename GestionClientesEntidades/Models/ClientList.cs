using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesEntidades.Models
{
    public class ClientList
    {
        public int ID { get; set; }
        public int? ConsultantID { get; set; }
        public string? Name { get; set; }
        public string? ConsultantType { get; set;}
        public int Pendientes { get; set; }
    }
}
