using ChannelEngine_BL.Interfaces;
using ChannelEngine_BL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngine_BL.Repository
{
    public class ChannelEngineRepository : IChannelEngineRepository
    {
        /// <inheritdoc />
        public async Task<OrderDetails> GetAllInProgressOrders()
        {
            var result = new OrderDetails();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-CE-KEY", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");
                    using (var response = await httpClient.GetAsync("https://api-dev.channelengine.net/api/v2/orders?statuses=IN_PROGRESS"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<OrderDetails>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <inheritdoc />
        public Task<List<Product>> GetTopProductsSold()
        {
            var products = new List<Product>();
            try
            {
                var inProgressOrders = GetAllInProgressOrders();

                var productList = new List<Product>();

                foreach (var orderLine in inProgressOrders.Result.Content)
                {
                    var product = orderLine.Lines.Select(p => new Product
                    {
                        GTIN = p.Gtin,
                        Description = p.Description,
                        Qty = p.Quantity,
                        MerchantProductNo = p.MerchantProductNo
                    });

                    productList.AddRange(product);
                }

                var productByDescription = productList.OrderBy(x => x.Qty).GroupBy(x => x.Description).Take(5);
                
                foreach (var productsGroup in productByDescription)
                {
                    int quantity = 0;
                    var product = new Product();
                    foreach (var productGroup in productsGroup)
                    {
                        quantity += productGroup.Qty;
                        product.GTIN = productGroup.GTIN;
                        product.Description = productGroup.Description;
                    }
                    product.Qty = quantity;

                    products.Add(product);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }  

            return Task.FromResult(products); 
        }

        /// <inheritdoc />
        public Task<bool> UpdateStockProduct(string merchantProductNo, int stock)
        {
            bool output = false;
            try
            {
                var body = "[\r\n{\r\n    \"op\": \"replace\",\r\n    \"path\": \"Stock\",\r\n    \"value\": \"25\"\r\n}\r\n]";

                var content = new StringContent(
                                body,
                                System.Text.Encoding.UTF8,
                                "application/json"
                                );
                string returnValue = "";

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-CE-KEY", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");
                using (var content1 = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpResponseMessage result = httpClient.PatchAsync("https://api-dev.channelengine.net/api/v2/products/001201-S", content).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        output = true;
                        returnValue = result.Content.ReadAsStringAsync().Result;
                    }

                    throw new Exception($"Failed to Patch product : ({result.StatusCode}): {returnValue}");
                }

            }
            catch(Exception ex)
            {

            }
            return Task.FromResult<bool>(output);
        }

    }
}