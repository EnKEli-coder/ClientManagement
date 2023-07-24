using GestionClientesDatos.Data;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesDatos
{
    public static class OrderData
    {
        public static async Task<List<OrderList>> GetOrders()
        {
            List<OrderList> orders = new();

            using(var context = new ClientManagementContext())
            {
                orders = await context.OrdersList.ToListAsync();
            }

            return orders;
        }

        public static async Task<List<Order>> GetOrdersById(int clientId)
        {
            List<Order> orders = new();

            using (var context = new ClientManagementContext())
            {
                orders = await context.Orders.Where(x => x.ClientID == clientId).ToListAsync();
            }

            return orders;
        }
    }
}
