using GestionClientesEntidades.Dto;

namespace GestionClientes.Models
{
    public class NewOrderModel
    {
        public int? Id { get; set; }
        public int? Folio { get; set; }
        public int ClientId { get; set; }
        public int Campaign { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string State { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
