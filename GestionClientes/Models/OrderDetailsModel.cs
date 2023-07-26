using GestionClientesEntidades.Models;

namespace GestionClientes.Models
{
    public class OrderDetailsModel
    {
        public List<ClientList>? ClientList { get; set; } = null;
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public OrderList? Order { get; set; }
        public List<Product>? Products { get; set; }
        public string? SaveAction { get; set; }
        public string? CancelAction { get; set; }
        public string? OrderState { get; set; }
    }
}
