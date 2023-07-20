using GestionClientesEntidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesDatos
{
    public static class ClientData
    {
        private static List<Client> clients = new List<Client>()
        {
            new Client() {
                Id = 1,
                ConsultantId = 340,
                Name = "Omar Enrique Romero Gomez",
                Telephone = "9811407144",
                Email = "omar_erg@hotmail.com",
                ConsultantType = "Asesor",
                Adress = "Calle Almendros Mza 4 Lote 39 Fracc Laureles Campeche, Campeche",
                Password = "Password123",
                Observations = "El yerno mas wapo."
            },
            new Client() {
                Id = 2,
                ConsultantId = 2206,
                Name = "Amiel Ylang Miranda Martinez",
                Telephone = "9811234545",
                Email = "mimiel_ymm@hotmail.com",
                ConsultantType = "Cliente",
                Adress = "Calle Almendros Mza 4 Lote 39 Fracc Laureles Campeche, Campeche",
                Password = "Password321",
                Observations = "La princesa mas linda."
            }
        };

        public static async Task<List<Client>> GetClientsAsync()
        {
            return this.clients;
        }
    }
}
