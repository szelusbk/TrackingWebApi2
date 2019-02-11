using System.Collections.Generic;
using TrackingWebApi.Models.Db;

namespace TrackingWebApi.Services.Interfaces
{
    public interface IOrdersService
    {
        List<Orders> GetOrdersList(); 
    }
}
