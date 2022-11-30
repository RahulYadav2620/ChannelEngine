using ChannelEngine_BL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngine_Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// It will get all orders in progess.
        /// </summary>
        /// <returns>It returns OrderDetails.</returns>
        public Task<OrderDetails> GetAllInProgressOrders();

        /// <summary>
        /// It will get top 5 products sold from inprogress orders.
        /// </summary>
        /// <returns>It will return list of top 5 products sold.</returns>
        public Task<List<Product>> GetTopProductsSold();

        /// <summary>
        /// It will update product stock information
        /// </summary>
        /// <returns> True - If successfully updated. False - If some error occurred./// </returns>
        public Task<bool> UpdateStockProduct();
    }
}
