using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlama.Models
{
    public class Destinasyon
    {
        [Key] public int DestinasyonId { get; set; }
        [Required][DisplayName("�ehir Ad�")] public string SehirAdi { get; set; }
        [Required] [DisplayName("�lke Ad�")] public string UlkeAdi { get; set; }
    }
}