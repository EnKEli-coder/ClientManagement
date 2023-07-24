using GestionClientes.Models;
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
    }
}
