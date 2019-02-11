using System.Collections.Generic;
using System.Linq;
using TrackingWebApi.Models;
using TrackingWebApi.Models.Db;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IGpsContext context;

        public OrdersService(IGpsContext context)
        {
            this.context = context;
        }

        public List<Orders> GetOrdersList()
        {
            var orders = context.Orders.ToList();
            return orders;
        }
    }
}
