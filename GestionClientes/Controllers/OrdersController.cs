using GestionClientes.Models;
using GestionClientesEntidades.Models;
using GestionClientesNegocio;
using Microsoft.AspNetCore.Mvc;

namespace GestionClientes.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> OrdersView()
        {
            OrdersListModel orders = new() {
                Orders = await OrderBusiness.GetOrders()
            };
            return PartialView("Orders",orders);
        }

        [HttpPost]
        public async Task<ActionResult> OpenNewOrder()
        {
            OrderDetailsModel order = new()
            {
                ClientList = await ClientBusiness.GetClients(),
                OrderState = "New",
                CancelAction = "cerrarModal()",
                SaveAction = "AddNewOrder(event)"
            };
            return PartialView("_OrderDetails", order);
        }

        [HttpPost]
        public async Task<ActionResult> OpenOrderDetails(int id)
        {
            OrderDetailsModel order = new()
            {
                ClientList = await ClientBusiness.GetClients(),
                OrderState = "New",
                CancelAction = "cerrarModal()",
                SaveAction = "AddNewOrder(event)"
            };
            return PartialView("_OrderDetails", order);


            [HttpPost]
        public async Task<ActionResult> AddNewProduct()
        {
            return PartialView("_NewProductItem");
        }

        [HttpPost]
        public async Task<ActionResult> AddNewOrder([FromBody] NewOrderModel order)
        {
            var papucho = order;
            return PartialView("_NewProductItem");
        }
    }
}
