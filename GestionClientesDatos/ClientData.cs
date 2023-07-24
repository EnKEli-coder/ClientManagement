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

            using (var context = new ClientManagementContext())
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

        public static async Task UpdateClient(ClientDTO clientInfo)
        {
            using (var context = new ClientManagementContext())
            {
                Client? client = await context.Clients.Where(x => x.ID == clientInfo.ID).FirstOrDefaultAsync();
                if (client != null && clientInfo.Name != null)
                {
                    client.ConsultantId = clientInfo.ConsultantID;
                    client.Name = clientInfo.Name;
                    client.ConsultantType = clientInfo.ConsultantType;
                    client.Telephone = clientInfo.Telephone;
                    client.Email = clientInfo.Email;
                    client.Address = clientInfo.Address;
                    client.Password = clientInfo.Password;
                    client.Observations = clientInfo.Observations;
                }

                await context.SaveChangesAsync();
                
            }
        }
        
        public static async Task CreateClient(ClientDTO clientInfo)
        {
            using (var context = new ClientManagementContext())
            {
                if (clientInfo.Name != null)
                {
                    Client client = new Client()
                    {
                        ConsultantId = clientInfo.ConsultantID,
                        Name = clientInfo.Name,
                        ConsultantType = clientInfo.ConsultantType,
                        Telephone = clientInfo.Telephone,
                        Email = clientInfo.Email,
                        Address = clientInfo.Address,
                        Password = clientInfo.Password,
                        Observations = clientInfo.Observations,
                    };

                    await context.AddAsync(client);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
