using GestionClientes.Models;
using GestionClientesDatos;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using Microsoft.Identity.Client;
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

        public static async Task AddNewOrder(NewOrderModel order)
        {
            await OrderData.AddNewOrder(order);
        }

        public static async Task<OrderDTO> GetOrderDetails(int id)
        { 
            OrderDTO orderDetails = new();
            orderDetails.ClientList = await ClientData.GetClientListAsync();
            orderDetails.Order = await OrderData.GetOrderById(id);
            orderDetails.Products = await OrderData.GetProductsByOrder(id);

            var orderList = await OrderData.GetOrderListById(id);

            orderDetails.ClientName = orderList.ClientName;
            orderDetails.ClientId = orderList.ClientID;
            
            return orderDetails;
        }

        public static async Task UpdateOrder(NewOrderModel order)
        {
           await OrderData.UpdateOrder(order);
        }
    }
}
