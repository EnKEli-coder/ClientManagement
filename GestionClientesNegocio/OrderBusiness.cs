using GestionClientesDatos;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientesNegocio
{
    public static class OrderBusiness
    {
        public static async Task<List<OrderList>> GetOrders()
        {
            return await OrderData.GetOrders();
        }

        public static async Task<List<Order>> GetClientOrders(int clientId)
        {
            return await OrderData.GetOrdersById(clientId);
        }
    }
}
