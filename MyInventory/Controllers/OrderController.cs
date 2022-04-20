using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLine.Models;
using LifeLine.Data;
using System.IO;
using Microsoft.AspNetCore.Http;





namespace LifeLine.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Receipt()
        {
            var order = _context.PurchaseOrders.ToList();
            return View();
        }
    }
}
