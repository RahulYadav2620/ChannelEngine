using ChannelEngine_BL.Model;
using ChannelEngine_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine_Services.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {

        }
        public Task<OrderDetails> GetAllInProgressOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetTopProductsSold()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStockProduct(string MerchantProductNo, int stock)
        {
            throw new NotImplementedException();
        }
    }
}
