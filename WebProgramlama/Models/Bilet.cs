using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlama.Models
{
    public class Bilet
    {
        [Key] [DisplayName("Bilet ID")] public int BiletId { get; set; }
        [Required] [DisplayName("Al�m Tarihi")] public DateTime AlimTarihi { get; set; }
        [Required] [DisplayName("U�u�")] public int UcusId { get; set; }
        public Ucus ucus { get; set; }
        public Kullanici kullanici { get; set; }
    }
}