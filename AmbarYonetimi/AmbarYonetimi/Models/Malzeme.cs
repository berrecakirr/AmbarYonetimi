using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmbarYonetimi.Models
{
    public class Malzeme
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }
            
        public int StokMiktari { get; set; }
     
        public ICollection<MalzemeHareket> Hareketler { get; set; }
        public int KritikSeviye { get; internal set; }
        public string Durum { get; internal set; }
    }
}

