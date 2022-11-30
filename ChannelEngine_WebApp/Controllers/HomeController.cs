using ChannelEngine_BL.Interfaces;
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
        private readonly IChannelEngineRepository _channelEngineRepository;

        public HomeController(ILogger<HomeController> logger, IChannelEngineRepository channelEngineRepository)
        {
            _logger = logger;
            _channelEngineRepository = channelEngineRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _channelEngineRepository.GetAllInProgressOrders();
            ViewBag.Products = result;
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var result = await _channelEngineRepository.GetTopProductsSold();
            ViewBag.TopProduct = result;
            return View();
        }
        public async Task<IActionResult> UpdateStockProduct()
        {
            var result = await _channelEngineRepository.UpdateStockProduct("",25);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
