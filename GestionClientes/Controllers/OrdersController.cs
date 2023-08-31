using GestionClientes.Models;
using GestionClientesEntidades.Dto;
using GestionClientesEntidades.Models;
using GestionClientesNegocio;
using Microsoft.AspNetCore.Mvc;

namespace GestionClientes.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> OrdersView()
        {
            OrdersListModel orders = new() {
                Orders = await OrderBusiness.GetOrders()
            };
            return PartialView("Orders",orders);
        }

        public async Task<ActionResult> GetOrdersList([FromBody] SearchParam texto)
        {

            List<OrderList> orders = await OrderBusiness.GetOrders(texto.Busqueda);

            return PartialView("_OrderList", orders);
        }

        [HttpPost]
        public async Task<ActionResult> OpenNewOrder()
        {
            OrderDetailsModel order = new()
            {
                ClientList = await ClientBusiness.GetClients(),
                OrderState = "New",
                CancelAction = "cerrarModal()",
                SaveAction = "AddNewOrder(event)"
            };
            return PartialView("_OrderDetails", order);
        }

        [HttpPost]
        public async Task<ActionResult> OpenOrderDetails([FromBody] OrderInfoParams o)
        {
            OrderDTO orderDetails = await OrderBusiness.GetOrderDetails(o.OrderId);

            OrderDetailsModel order = new()
            {
                ClientList = orderDetails.ClientList,
                ClientId = orderDetails.ClientId,
                ClientName = orderDetails.ClientName,
                Order = orderDetails.Order,
                Products = orderDetails.Products,
                OrderState = orderDetails.Order.State,
                CancelAction = "cerrarModal()",
                SaveAction = "updateOrder(event, "+orderDetails.Order.ID+")"
            };
            return PartialView("_OrderDetails", order);
        }

            [HttpPost]
        public async Task<ActionResult> AddNewProduct()
        {
            return PartialView("_NewProductItem");
        }

        [HttpPost]
        public async Task<ActionResult> AddNewOrder([FromBody] NewOrderModel order)
        {
            await OrderBusiness.AddNewOrder(order);
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateOrder([FromBody] NewOrderModel order)
        {
            await OrderBusiness.UpdateOrder(order);
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<ActionResult> OpenNewClientOrder([FromBody] ClientInfoParams client)
        {
            OrderDetailsModel order = new()
            {
                ClientList = await ClientBusiness.GetClients(),
                ClientId = client.ClientId,
                OrderState = "New",
                CancelAction = "cerrarModal()",
                SaveAction = "AddNewOrder(event)"
            };
            return PartialView("_OrderDetails", order);
        }

        [HttpPost] 

        public async Task<ActionResult> DeleteOrder([FromBody] OrderInfoParams order)
        {
            await OrderBusiness.DeleteOrder(order.OrderId);
            return new EmptyResult();
        }
    }
}
