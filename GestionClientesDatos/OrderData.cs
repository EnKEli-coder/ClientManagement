using GestionClientes.Models;
using GestionClientesDatos.Data;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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

        public static async Task<Order> GetOrderById(int id)
        {
            Order order = new();

            using (var context = new ClientManagementContext())
            {
                order = await context.Orders.Where(x => x.ID == id).FirstOrDefaultAsync();
            }

            return order;
        }

        public static async Task<OrderList> GetOrderListById(int id)
        {
            OrderList order = new();

            using (var context = new ClientManagementContext())
            {
                order = await context.OrdersList.Where(x => x.ID == id).FirstOrDefaultAsync();
            }

            return order;
        }

        public static async Task AddNewOrder(NewOrderModel order)
        {
            using (var context = new ClientManagementContext())
            {
                Order newOrder = new()
                {
                    OrderNumber = order.Folio,
                    ClientID = order.ClientId,
                    Campaign = order.Campaign,
                    Subtotal = order.Subtotal,
                    Discount = order.Discount,
                    Total = order.Total,
                    State = order.State,
                };

                var transaction = context.Database.BeginTransaction();

                context.Orders.Add(newOrder);
                context.SaveChanges();

                int orderId = newOrder.ID;

                foreach (var product in order.Products)
                {
                    context.Products.Add(new Product
                    {
                        ProductKey = product.Key,
                        OrderID = orderId,
                        ProductDescription = product.Description,
                        Quantity = product.Quantity,
                        ProductPrice = product.Price,
                    });
                }
                context.SaveChanges();
                transaction.Commit();
            }
        }

        public static async Task<List<Product>> GetProductsByOrder(int id)
        {
            using (var context = new ClientManagementContext())
            {
                return await context.Products.Where(x => x.OrderID == id).ToListAsync();
            }
        }

        public static async Task UpdateOrder(NewOrderModel order)
        {
            using(var context = new ClientManagementContext())
            {
                var transaction = context.Database.BeginTransaction();

                Order orden = await context.Orders.Where(x => x.ID == order.Id).FirstOrDefaultAsync();
                orden.OrderNumber = order.Folio; 
                orden.ClientID = order.ClientId;
                orden.Campaign = order.Campaign;
                orden.Subtotal = order.Subtotal;
                order.Discount = order.Discount;
                orden.Total = order.Total;
                orden.State = order.State;
                context.SaveChanges();

                var oldProducts = await context.Products.Where(x => x.OrderID == order.Id).ToListAsync();
                foreach(var item in oldProducts)
                {
                    context.Products.Remove(item);
                }
                context.SaveChanges();

                foreach (var product in order.Products)
                {
                    context.Products.Add(new Product
                    {
                        ProductKey = product.Key,
                        OrderID = orden.ID,
                        ProductDescription = product.Description,
                        Quantity = product.Quantity,
                        ProductPrice = product.Price,
                    });
                }
                context.SaveChanges();
                transaction.Commit();
            }
        }
    }
}
