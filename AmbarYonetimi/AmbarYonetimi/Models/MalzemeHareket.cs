using System;
using System.ComponentModel.DataAnnotations;

namespace AmbarYonetimi.Models
{
    public class MalzemeHareket
    {
        public int Id { get; set; }

        public int MalzemeId { get; set; }

        public Malzeme Malzeme { get; set; }

        public string HareketTipi { get; set; } // "Giriş" / "Çıkış"

        public int Miktar { get; set; }

        public string Aciklama { get; set; }
    }
}
