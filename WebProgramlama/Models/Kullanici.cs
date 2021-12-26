using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebProgramlama.Models
{
    public class Kullanici: IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
