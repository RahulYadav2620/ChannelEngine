using System;
using System.Threading.Tasks;

namespace ChannelEngine_ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            var channelEngineRepository = new ChannelEngine_BL.Repository.OrderRepository();

            #region GetAllInProgressOrders

            var inProgressOrders = await channelEngineRepository.GetAllInProgressOrders();
            Console.WriteLine("\t\t\t In progress orders.\n\n");
            foreach (var products in inProgressOrders.Content)
            {
                Console.WriteLine($"{products.ChannelId}," +
                    $"{products.ChannelName}, {products.ChannelOrderNo}, {products.CreatedAt}, " +
                    $"{products.Id} {products.MerchantOrderNo}");

            }

            #endregion

            #region Update Stock Product

            Console.WriteLine("\n\n\t\t\t Update stock product.\n\n");
            var merchantProductNo = "001201-S";
            int stock = 25;
            
            var respone = await channelEngineRepository.UpdateStockProduct(merchantProductNo, stock); 

            Console.WriteLine($"Is update stock product is successfull ? {respone}");
            #endregion

            #region Get Top Products Sold
            var productList = await channelEngineRepository.GetTopProductsSold();

            Console.WriteLine("\n\n\t\t\t List of the top 5 products sold.\n\n");
            foreach(var product in productList)
            {
                Console.WriteLine($"Product Name: {product.Description}, GTIN: {product.GTIN}, Total Quantity Sold: {product.Qty}");
            }
            
            #endregion

            Console.Read();
        }
    }
}
