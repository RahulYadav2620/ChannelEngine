using ChannelEngine_Services.Interfaces;
using ChannelEngine_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChannelEngine_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        /// <summary>
        /// For in progress orders.
        /// </summary>
        /// <returns>It will return in progress orders.</returns>
        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetAllInProgressOrders();
            ViewBag.Products = result;
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var result = await _orderService.GetTopProductsSold();
            ViewBag.TopProduct = result;
            return View();
        }
        public async Task<IActionResult> UpdateStockProduct()
        {
            var result = await _orderService.UpdateStockProduct();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
