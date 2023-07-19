using Microsoft.AspNetCore.Mvc;

namespace GestionClientes.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult OrdersView()
        {
            return PartialView("Orders");
        }
    }
}
