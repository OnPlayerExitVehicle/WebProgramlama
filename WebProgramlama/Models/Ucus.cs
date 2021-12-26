using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlama.Models
{
    public class Ucus
    {
        [Key] public int UcusId { get; set; }
        [Required] public DateTime Tarih { get; set; }
        [Required][DisplayName("Kalk�� Yeri")] public int kalkisId { get; set; }
        public Destinasyon kalkis { get; set; }
        [Required][DisplayName("�ni� Yeri")] public int inisId { get; set; }
        public Destinasyon inis { get; set; }

    }
}