
using AmbarYonetimi.Models;
using System.ComponentModel.DataAnnotations;

namespace AmbarYonetimi.ViewModels
{
    public class DepolarViewModel
    {           
            public string? UrunAdi { get; set; }       // Başlık, Kılıf, vs.
            public string? UrunKodu { get; set; }
            public string? RafKodu { get; set; }
            public string? HareketTipi { get; set; }   // Giriş / Çıkış
            public int? Miktar { get; set; }
            public string? IslemYapan { get; set; }
     

    }
}


