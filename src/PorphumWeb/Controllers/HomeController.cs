﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumSales.Logic.Storage;
using PorphumWeb.Logic.Storage;
using PorphumWeb.Models;
using System.Diagnostics;

namespace PorphumWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebContext _webContext;
        private readonly ReferenceBookContext _refBookContext;

        public HomeController(ILogger<HomeController> logger, WebContext webContext, ReferenceBookContext referenceBookContext)
        {
            _logger = logger;
            _webContext = webContext;
            _refBookContext = referenceBookContext;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append("SalesContext-Connection", "postgres");
            
            var users = _webContext.Users.Include(x => x.Roles).ToList();
            var products = _refBookContext.Products.Include(x => x.Info).Include(x => x.Group).ToList();  
            var clients = _refBookContext.Clients.Include(x => x.Info).ToList();
            var cons = _webContext.Connections.ToList();

            return View();
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