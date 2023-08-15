using GestionClientesEntidades.Models;

namespace GestionClientes.Models
{
    public class NewOrderModel
    {
        public string? Folio { get; set; }
        public int IdCliente { get; set; }
        public int Campaign { get; set; }
        public string State { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
