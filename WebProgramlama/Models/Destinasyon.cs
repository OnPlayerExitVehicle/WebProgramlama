using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlama.Models
{
    public class Destinasyon
    {
        [Key] public int DestinasyonId { get; set; }
        [Required][DisplayName("Þehir Adý")] public string SehirAdi { get; set; }
        [Required] [DisplayName("Ülke Adý")] public string UlkeAdi { get; set; }
    }
}