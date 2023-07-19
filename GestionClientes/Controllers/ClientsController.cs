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

        public async Task<ActionResult> ClientsView()
        {
            return PartialView("Clients");
        }

        public async Task<ActionResult> ClientInfo()
        {
            return PartialView("_ClientInfoModal");
        }
    }
}
