using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProgramlama.Data;
using WebProgramlama.Models;

namespace WebProgramlama.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DestinasyonController : Controller
    {
        private readonly ILogger<DestinasyonController> _logger;
        private readonly ApplicationDbContext _context;

        public DestinasyonController(ILogger<DestinasyonController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            
            List<Destinasyon> list = _context.Destinasyonlar.ToList();
            return View(list);
        }

        public IActionResult DestinasyonOlustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DestinasyonOlustur([Bind("SehirAdi", "UlkeAdi")]Destinasyon destinasyon)
        {
            _context.Add(destinasyon);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
