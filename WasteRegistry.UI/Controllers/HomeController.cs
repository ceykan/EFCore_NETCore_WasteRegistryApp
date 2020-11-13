using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WasteRegistry.UI.Business.Interfaces;
using WasteRegistry.UI.Models;

namespace WasteRegistry.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IServiceProvider _provider;

        public HomeController(ILogger<HomeController> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var scope = _provider.CreateScope();
            var resultDeneme = await _provider.GetService<IWasteRegistryUIService>().GetAllList();
            return Content(resultDeneme, "application/json");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            using var scope = _provider.CreateScope();
            var resultDeneme = await _provider.GetService<IWasteRegistryUIService>().Delete(id);
            return Json(resultDeneme.ToString()) ;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            using var scope = _provider.CreateScope();
            var resultDeneme = await _provider.GetService<IWasteRegistryUIService>().GetById(id);
            var deneme = JsonConvert.DeserializeObject<WasteRegistryViewModel>(resultDeneme);
            return PartialView("~/Views/Shared/WasteRegistryModal.cshtml", deneme);
        }

        [HttpPost]
        public async Task<JsonResult> Add(WasteRegistryViewModel model)
        {
            using var scope = _provider.CreateScope();
            var resultDeneme = await _provider.GetService<IWasteRegistryUIService>().Add(model);
            return Json(resultDeneme.ToString());
        }
        [HttpPost]
        public async Task<JsonResult> Update(WasteRegistryViewModel model)
        {
            using var scope = _provider.CreateScope();
            var resultDeneme = await _provider.GetService<IWasteRegistryUIService>().Update(model);
            return Json(resultDeneme.ToString());
        }
               

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
