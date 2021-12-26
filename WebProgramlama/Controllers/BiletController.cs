using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Ini;
using WebProgramlama.Data;
using WebProgramlama.Models;

namespace WebProgramlama.Controllers
{
    public class BiletController : Controller
    {
        private readonly ILogger<BiletController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Kullanici> _userManager;

        public BiletController(ILogger<BiletController> logger, ApplicationDbContext context, UserManager<Kullanici> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Bilet> biletler = _context.Biletler.Include(k => k.ucus.kalkis).Include(i => i.ucus.inis).Include(x => x.kullanici).ToList();
            return View(biletler);
        }
        [Authorize]
        public IActionResult BiletListele()
        {
            Kullanici u = _userManager.FindByNameAsync(User.Identity.Name).Result;
            List<Bilet> biletler = _context.Biletler.Include(k => k.ucus.kalkis)
                .Include(k => k.ucus.inis).Where(k => k.kullanici.Id == u.Id).ToList();
            return View(biletler);
        }
        [Authorize]
        public IActionResult BiletAl()
        {
            var join = _context.Ucuslar.Join
            (_context.Destinasyonlar, u => u.kalkisId, d => d.DestinasyonId,
                (u, k) => new {u, k}).Join
            (_context.Destinasyonlar, ucus => ucus.u.inisId, d => d.DestinasyonId, (t, d) => new
            {
                UcusId = t.u.UcusId,
                UcusIsmi = t.k.SehirAdi + " ->" + d.SehirAdi
            });


            ViewData["Ucuslar"] = new SelectList(join, "UcusId", "UcusIsmi");
            return View();
        }

        [HttpPost][Authorize]
        public IActionResult BiletAl([Bind("UcusId")]Bilet bilet)
        {
            bilet.AlimTarihi = DateTime.Now;
            bilet.kullanici = _userManager.FindByNameAsync(User.Identity.Name).Result;
            _context.Add(bilet);
            _context.SaveChanges();
            return RedirectToAction("BiletListele");
        }
    }

    class Tuple
    {
        private Bilet bilet;
        private Ucus ucus;
    }
}
