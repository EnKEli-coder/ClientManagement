using GestionClientesEntidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GestionClientesDatos;
using GestionClientesEntidades.Models;

namespace GestionClientesNegocio
{
    public static class ClientBusiness
    {

        public static async Task<List<ClientList>> GetClients(string busqueda = "")
        {
            return await ClientData.GetClientListAsync(busqueda);
        }

        public static async Task<Client> GetClientInfo(int clientId)
        {
            return await ClientData.GetClientById(clientId);
        }

        public static async Task UpdateClient(ClientDTO clientInfo)
        {
            await ClientData.UpdateClient(clientInfo);
        }
        public static async Task SaveNewClient(ClientDTO clientInfo)
        {
            await ClientData.CreateClient(clientInfo);
        }
    }
}
