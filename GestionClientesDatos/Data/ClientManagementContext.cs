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
            options.UseSqlServer("Server=sql5053.site4now.net;Database=db_a9dadc_clientsmanagement;Trusted_connection=false;User Id=db_a9dadc_clientsmanagement_admin;Password=Chocorrol2510@;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientList>(
                eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vwClientsList");
                });

            modelBuilder.Entity<OrderList>(
                eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("vwOrdersList");
                });
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientList> ClientsList { get; set; }
        public DbSet<OrderList> OrdersList { get; set;}
    }
}
