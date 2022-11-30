using ChannelEngine_BL.Interfaces;
using ChannelEngine_BL.Model;
using ChannelEngine_Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngine_Services.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _channelEngineRepository;
        public OrderService(IOrderRepository channelEngineRepository)
        {
            _channelEngineRepository = channelEngineRepository;
        }

        /// <inheritdoc />
        public async Task<OrderDetails> GetAllInProgressOrders()
        {
            return await _channelEngineRepository.GetAllInProgressOrders();
        }

        /// <inheritdoc />
        public async Task<List<Product>> GetTopProductsSold()
        {
            return await _channelEngineRepository.GetTopProductsSold();
        }

        /// <inheritdoc />
        public async Task<bool> UpdateStockProduct(string merchantProductNo, int stock)
        {
            return await _channelEngineRepository.UpdateStockProduct(merchantProductNo, stock);
        }
    }
}
