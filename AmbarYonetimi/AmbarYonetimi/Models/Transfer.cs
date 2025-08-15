using System.ComponentModel.DataAnnotations;

public class TransferModel
{
    [Key] // 🔑 Bu satır EF için birincil anahtar olduğunu belirtir
    public int Id { get; set; }

    public string KaynakDepo { get; set; }
    public string HedefDepo { get; set; }
    public string UrunKodu { get; set; }
    public int Miktar { get; set; }
    public string TransferNedeni { get; set; }
    public string Oncelik { get; set; }
    public DateTime TransferTarihi { get; set; }
    public string SorumluKisi { get; set; }
}
