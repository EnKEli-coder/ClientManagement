using GestionClientesEntidades.Models;

namespace GestionClientes.Models
{
    public class ClientOrdersModel
    {

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
