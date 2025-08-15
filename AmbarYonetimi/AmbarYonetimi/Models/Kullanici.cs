using System.ComponentModel.DataAnnotations;

namespace AmbarYonetimi.Models
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Sifre { get; set; }

        [Required]
        public string Rol { get; set; } // "Admin" veya "User"
    }
}

