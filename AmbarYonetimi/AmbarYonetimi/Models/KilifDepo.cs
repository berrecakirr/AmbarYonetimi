using System.ComponentModel.DataAnnotations;

namespace AmbarYonetimi.Models
{
    public class KilifDepo
    {
        public int Id { get; set; }

        public string? UrunAdi { get; set; }

        public string? UrunKodu { get; set; }

        public string? RafKodu { get; set; }

        public string? HareketTipi { get; set; }

        public int? Miktar { get; set; }

        public string? IslemYapan { get; set; }

        public DateTime Tarih { get; set; }

    }
}

