using GestionClientesEntidades.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesDatos.Data
{
    public class DbInitializer
    {
        public static void Initialize(ClientManagementContext context)
        {
            if (context.Clients.Any())
            {
                return;
            }

            Client[] clients = new Client[]
            {
                new Client { ConsultantId=34560,Name="Omar Enrique Romero Gomez",ConsultantType = "Asesor",Telephone="981407144",Email="omar_erg@hotmail.com", Address="Calle Almendros Mza 4 Lote 39 Fracc Los laureles Campeche, Campeche", Password = "Contrasenia2340", Observations = "El yerno mas wapo"},
                new Client { ConsultantId = 34561, Name = "Amiel Ylang Miranda Martinez",ConsultantType = "Cliente", Telephone = "9812345667", Email = "amiel_ymm@hotmail.com", Address = "Calle Sal si puedes lote 36 Colonia Matamorros", Password = "Contrasenia2341", Observations = "La princesa mas piciosa" },
                new Client { ConsultantId = 34562, Name = "Juan Gabriel Altozano Chuc",ConsultantType = "Asesor", Telephone = "981407145", Email = "juan_gac@hotmail.com", Address = "Calle Almendros Mza 4 Lote 39 Fracc Los laureles Campeche, Campeche", Password = "Contrasenia99", Observations = "Ella ya me olvido" },
                new Client { ConsultantId = 34563, Name = "Maria Isabel Martinez Herrera",ConsultantType = "Asesor", Telephone = "981407146", Email = "maria_imh@hotmail.com", Address = "Calle Almendros Mza 4 Lote 39 Fracc Los laureles Campeche, Campeche", Password = "Contrasenia86", Observations = "Todo se derrumbo dentro de mi" }
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();

            Order[] orders = new Order[]
            {
                new Order{OrderNumber = 286, ClientID = 1, Campaign = 12, Total = 520.50m, State = "Pendiente"},
                new Order{OrderNumber = 285, ClientID = 1, Campaign = 11, Total = 520.50m, State = "Pendiente"},
                new Order{OrderNumber = 284, ClientID = 2, Campaign = 10, Total = 520.50m, State = "Pendiente"},
                new Order{OrderNumber = 283, ClientID = 4, Campaign = 10, Total = 520.50m, State = "Pendiente"},
                new Order{OrderNumber = 282, ClientID = 3, Campaign = 10, Total = 520.50m, State = "Pendiente"},
                new Order{OrderNumber = 281, ClientID = 4, Campaign = 10, Total = 520.50m, State = "Pendiente"},
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();

            Product[] products = new Product[]
            {
                new Product{OrderID = 1, ProductKey = "D98761", ProductDescription = "Crema corporal 250ml", Quantity = 1, ProductPrice = 250.00m},
                new Product{OrderID = 1, ProductKey = "98762", ProductDescription = "Shampoo acondicionador 250ml", Quantity = 1, ProductPrice = 270.50m},
                new Product{OrderID = 2, ProductKey = "98763", ProductDescription = "Bloqueador facial 200ml", Quantity = 1, ProductPrice = 520.50m},
                new Product{OrderID = 3, ProductKey = "98763", ProductDescription = "Bloqueador facial 200ml", Quantity = 1, ProductPrice = 520.50m},
                new Product{OrderID = 4, ProductKey = "98763", ProductDescription = "Bloqueador facial 200ml", Quantity = 1, ProductPrice = 520.50m},
                new Product{OrderID = 5, ProductKey = "98763", ProductDescription = "Bloqueador facial 200ml", Quantity = 1, ProductPrice = 520.50m},
                new Product{OrderID = 6, ProductKey = "98763", ProductDescription = "Bloqueador facial 200ml", Quantity = 1, ProductPrice = 520.50m},
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
