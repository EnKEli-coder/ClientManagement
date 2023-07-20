using GestionClientesEntidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GestionClientesDatos;

namespace GestionClientesNegocio
{
    public static class ClientBusiness
    {

        public static async Task<List<Client>> GetClients()
        {
            return await ClientData.GetClientsAsync();
        }

        public static async Task<Client> GetClients(int clientId)
        {
            return await ClientData.GetClientByIdsAsync(clientId);
        }
    }
}
