using ChannelEngine_BL.Interfaces;
using ChannelEngine_BL.Model;
using ChannelEngine_Services.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ChannelEngine_BL_UnitTestCase
{
    public class OrderServiceTest
    {
        [Fact]
        public void GetAllInProgressOrders_EmptyResult()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.GetAllInProgressOrders()).Returns(Task.FromResult(null as OrderDetails));
            var response = orderService.GetAllInProgressOrders();

            Assert.Null(response.Result);
        }

        [Fact]
        public void GetAllInProgressOrders_ReturnsInprogressOrder()
        {
            var order = new OrderDetails()
            {
                Content = new List<Content>()
                {
                    new Content()
                    {
                        Id = 12,
                        ChannelName = "test",
                        ChannelId = 11,
                        GlobalChannelName = "test",
                        GlobalChannelId = 1544,
                        ChannelOrderSupport = "OrderLines",
                        ChannelOrderNo = "Test-1234",
                        MerchantOrderNo = "Test-Merchant",
                        Status = "IN_PROGRESS",
                        IsBusinessOrder = false,
                        MerchantComment = null,
                        Phone="",
                        Email = "",
                        CurrencyCode = "",
                        Lines = new List<Lines>()
                        {
                            new Lines()
                            {
                                Status = "In_progress",
                                Description = "test description",
                                UnitVat = 24,
                                LineVat = 234,
                                OriginalFeeFixed = 0,
                                VatRate = 21
                            }
                        }
                    }
                },

                Success = true,
                Count = 1,
                TotalCount = 1,
                ItemsPerPage = 20,
                StatusCode = 200,
            };
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.GetAllInProgressOrders()).Returns(Task.FromResult(order));
            var response = orderService.GetAllInProgressOrders();

            Assert.True(response.Result.Success);
            Assert.Equal(response.Result.Count, order.Count);
            Assert.Equal(response.Result.ItemsPerPage, order.ItemsPerPage);
            Assert.Equal(response.Result.StatusCode, order.StatusCode);
            Assert.Collection(response.Result.Content, item => item.ChannelName.Equals("test"));
        }

        [Fact]
        public void GetTopProductsSold_EmptyResult()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.GetTopProductsSold()).Returns(Task.FromResult(null as List<Product>));
            var response = orderService.GetTopProductsSold();

            Assert.Null(response.Result);
        }

        [Fact]
        public void GetTopProductsSold_Success()
        {
            var product = new List<Product>()
            {
                new Product()
                {
                    Description = "test",
                    GTIN = "1233",
                    MerchantProductNo = "test product 1",
                    Qty = 2
                },
                new Product()
                {
                    Description = "test",
                    GTIN = "1233",
                    MerchantProductNo = "test product 2",
                    Qty = 1
                }
            };
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.GetTopProductsSold()).Returns(Task.FromResult(product));
            var response = orderService.GetTopProductsSold();

            Assert.Equal(response.Result.Count, product.Count);
            Assert.Equal(response.Result.Select(x => x.Description), product.Select(x => x.Description));
            Assert.Equal(response.Result.Select(x => x.GTIN), product.Select(x => x.GTIN));
            Assert.Equal(response.Result.Select(x => x.Qty), product.Select(x => x.Qty));
        }

        [Fact]
        public void UpdateStockProduct_EmptyResult()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.UpdateStockProduct()).Returns(Task.FromResult(false));
            var response = orderService.UpdateStockProduct();

            Assert.False(response.Result);
        }

        [Fact]
        public void UpdateStockProduct_Result()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            mockOrderRepository.Setup(x => x.UpdateStockProduct()).Returns(Task.FromResult(true));
            var response = orderService.UpdateStockProduct();

            Assert.True(response.Result);
        }
    }
}
