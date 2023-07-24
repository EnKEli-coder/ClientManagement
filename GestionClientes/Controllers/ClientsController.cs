using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionClientesEntidades.Dto;
using GestionClientesNegocio;
using GestionClientes.Models;
using GestionClientesEntidades.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace GestionClientes.Controllers
{
    public class ClientsController : Controller
    {
        // GET: ClientsController
        public async Task<ActionResult> Clients()
        {
            ClientsListModel clientsList = new()
            {
                Clients = await ClientBusiness.GetClients()
            };

            return View(clientsList);
        }

        public async Task<ActionResult> ClientsView()
        {
            ClientsListModel clientsList = new()
            {
                Clients = await ClientBusiness.GetClients()
            };
            return PartialView("Clients", clientsList);
        }
        [HttpPost]
        public async Task<ActionResult> ClientInfo([FromBody] ClientInfoParams param)
        {
            Client clientInfo = await ClientBusiness.GetClientInfo(param.ClientId);
            return PartialView("_ClientInfoModal", clientInfo);
        }

        [HttpPost]
        public async Task<ActionResult> ClientDetails([FromBody] ClientInfoParams param)
        {
            Client clientInfo = await ClientBusiness.GetClientInfo(param.ClientId);
            return PartialView("_ClientDetail", clientInfo);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateClient([FromBody] ClientDTO clientInfo)
        {
            await ClientBusiness.UpdateClient(clientInfo);
            return Ok();
        }

        [HttpPost]
        public ActionResult OpenNewClient()
        {
            return PartialView("_NewClientModal");
        }
    }
}
