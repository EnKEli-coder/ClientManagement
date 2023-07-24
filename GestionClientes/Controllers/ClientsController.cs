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
        public async Task<ActionResult> ClientModalDetails([FromBody] ClientInfoParams param)
        {
            Client client = await ClientBusiness.GetClientInfo(param.ClientId);
            
            ClientInfoModel clientInfo = new()
            {
                Client = client
            };

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
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult OpenNewClient()
        {
            return PartialView("_NewClientModal");
        }

        [HttpPost]
        public async Task<ActionResult> SaveNewClient([FromBody] ClientDTO clientInfo)
        {
            await ClientBusiness.SaveNewClient(clientInfo);
            return new EmptyResult();
        }
        [HttpPost]
        public async Task<ActionResult> ClientModalOrders([FromBody] ClientInfoParams param)
        {
            ClientOrdersModel clientOrders = new()
            {
                ClientId = param.ClientId,
                ClientName = param.ClientName,
                Orders = await OrderBusiness.GetClientOrders(param.ClientId)
            };

            ClientInfoModel clientInfo = new()
            {
                ClientOrders = clientOrders
            };

            return PartialView("_ClientInfoModal", clientInfo);
        }
    }
}
