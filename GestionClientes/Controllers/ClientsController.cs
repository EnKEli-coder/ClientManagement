using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionClientesEntidades.Dto;
using GestionClientesNegocio;
using GestionClientes.Models;

namespace GestionClientes.Controllers
{
    public class ClientsController : Controller
    {
        // GET: ClientsController
        public async Task<ActionResult> Clients()
        {
            ClientsListModel clientsList = new ClientsListModel
            {
                Clients = await ClientBusiness.GetClients()
            };

            return View(clientsList);
        }

        public async Task<ActionResult> ClientsView()
        {
            ClientsListModel clientsList = new ClientsListModel
            {
                Clients = await ClientBusiness.GetClients()
            };
            return PartialView("Clients", clientsList);
        }

        public async Task<ActionResult> ClientInfo(int clientId)
        {
            Client clientInfo = await ClientBusiness.GetClientInfo(clientId);
            return PartialView("_ClientInfoModal");
        }
    }
}
