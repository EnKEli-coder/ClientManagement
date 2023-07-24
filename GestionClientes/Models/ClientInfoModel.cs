using GestionClientesEntidades.Models;

namespace GestionClientes.Models
{
    public class ClientInfoModel
    {
        public Client? Client { get; set; } = null;
        public ClientOrdersModel? ClientOrders { get; set; } = null;
    }
}
