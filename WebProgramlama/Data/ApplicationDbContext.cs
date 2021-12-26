using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProgramlama.Models;

namespace WebProgramlama.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Ucus> Ucuslar { get; set; }
        public DbSet<Destinasyon> Destinasyonlar { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
