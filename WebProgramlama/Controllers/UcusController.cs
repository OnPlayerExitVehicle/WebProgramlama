using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlama.Data;
using WebProgramlama.Models;

namespace WebProgramlama.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UcusController : Controller
    {
        private readonly ILogger<UcusController> _logger;
        private readonly ApplicationDbContext _context;

        public UcusController(ILogger<UcusController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Ucus> ucuslar = _context.Ucuslar.Include(k => k.kalkis).Include(i => i.inis).ToList();
            return View(ucuslar);
        }

        public IActionResult UcusOlustur()
        {
            ViewData["Destinasyonlar"] = new SelectList(_context.Destinasyonlar, "DestinasyonId", "SehirAdi");
            return View();
        }
        [HttpPost]
        public IActionResult UcusOlustur([Bind("Tarih", "kalkisId", "inisId")]Ucus ucus)
        {
            _context.Add(ucus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
