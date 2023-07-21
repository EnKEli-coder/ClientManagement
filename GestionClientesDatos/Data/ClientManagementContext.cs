using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesDatos.Data
{
    public class ClientManagementContext:DbContext
    {
        public ClientManagementContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=ClientsManagement;TrustServerCertificate=True;Integrated Security=False;User Id=ORomero;Password=Chocorrol2510@;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientList>(
                eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vwClientsList");
                });
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientList> ClientsList { get; set; }
    }
}
