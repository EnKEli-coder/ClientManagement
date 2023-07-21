using GestionClientesDatos.Data;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesDatos
{
    public static class ClientData
    {
        public static async Task<List<ClientList>> GetClientListAsync()
        {
            List<ClientList> clients = new();

            using (var context =  new ClientManagementContext())
            {
                clients = await context.ClientsList.ToListAsync();
            }

            return clients;
        }

        public static async Task<Client> GetClientById(int clientId)
        {
            try
            {
                Client? client = new();

                using (var context = new ClientManagementContext())
                {
                    client = await context.Clients.Where(client => client.ID == clientId).FirstOrDefaultAsync();
                }

                return client ?? throw new Exception("No existe este cliente.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }
    }
}
