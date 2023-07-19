using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionClientes.Controllers
{
    public class ClientsController : Controller
    {
        // GET: ClientsController
        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult ClientsView()
        {
            return PartialView("Clients");
        }
    }
}
