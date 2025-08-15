using Microsoft.AspNetCore.Mvc;
using AmbarYonetimi.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace AmbarYonetimi.Controllers
{
    [Authorize(Roles = "Employee")]
    public class MalzemeController : Controller
    {
        private readonly AppDbContext _context;

        public MalzemeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // ------------------ DASHBOARD SAYFALARI --------------------
        public IActionResult Baslik()
        {
            var depoListesi = _context.BaslikDepolar.ToList();
            ViewBag.MevcutStok = HesaplaMevcutStok();
            ViewBag.BugunGiris = BugunGirisBaslik();
            ViewBag.BugunCikis = BugunCikisBaslik();
            DashboardBaslik();
            return View(depoListesi);
        }
        public IActionResult Sunger()
        {
            var sungerListesi = _context.SungerDepolar.ToList();
            ViewBag.MevcutStok = HesaplaMevcutStokSunger();
            ViewBag.BugunGiris = BugunGirisSunger();
            ViewBag.BugunCikis = BugunCikisSunger();
            DashboardSunger();
            return View(sungerListesi);
        }
        public IActionResult Kolcak()
        {
            var kolcakListesi = _context.KolcakDepolar.ToList();
            ViewBag.MevcutStok = HesaplaMevcutStokKolcak();
            ViewBag.BugunGiris = BugunGirisKolcak();
            ViewBag.BugunCikis = BugunCikisKolcak();
            DashboardKolcak();
            return View(kolcakListesi);
        }
        public IActionResult Kilif()
        {
            var kilifListesi = _context.KilifDepolar.ToList();
            ViewBag.MevcutStok = HesaplaMevcutStokKilif();
            ViewBag.BugunGiris = BugunGirisKilif();
            ViewBag.BugunCikis = BugunCikisKilif();
            DashboardKilif();
            return View(kilifListesi);
        }
        public IActionResult Iskelet()
        {
            var iskeletListesi = _context.IskeletDepolar.ToList();
            ViewBag.MevcutStok = HesaplaMevcutStokIskelet();
            ViewBag.BugunGiris = BugunGirisIskelet();
            ViewBag.BugunCikis = BugunCikisIskelet();
            DashboardIskelet();
            return View(iskeletListesi);
        }
        private int HesaplaMevcutStok()
        {
            var girisToplam = _context.BaslikDepolar
                .Where(x => x.HareketTipi == "Giris" || x.HareketTipi == "Giriş")
                .Sum(x => (int?)x.Miktar) ?? 0;

            var cikisToplam = _context.BaslikDepolar
                .Where(x => x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış")
                .Sum(x => (int?)x.Miktar) ?? 0;

            return girisToplam - cikisToplam;
        }
        private int HesaplaMevcutStokSunger()
        {
            var girisToplam = _context.SungerDepolar
                .Where(x => x.HareketTipi == "Giris" || x.HareketTipi == "Giriş")
                .Sum(x => (int?)x.Miktar) ?? 0;

            var cikisToplam = _context.SungerDepolar
                .Where(x => x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış")
                .Sum(x => (int?)x.Miktar) ?? 0;

            return girisToplam - cikisToplam;
        }
        private int HesaplaMevcutStokKolcak()
        {
            var girisToplam = _context.KolcakDepolar
                .Where(x => x.HareketTipi == "Giris" || x.HareketTipi == "Giriş")
                .Sum(x => (int?)x.Miktar) ?? 0;

            var cikisToplam = _context.KolcakDepolar
                .Where(x => x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış")
                .Sum(x => (int?)x.Miktar) ?? 0;

            return girisToplam - cikisToplam;
        }
        private int HesaplaMevcutStokKilif()
        {
            var girisToplam = _context.KilifDepolar
                .Where(x => x.HareketTipi == "Giris" || x.HareketTipi == "Giriş")
                .Sum(x => (int?)x.Miktar) ?? 0;

            var cikisToplam = _context.KilifDepolar
                .Where(x => x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış")
                .Sum(x => (int?)x.Miktar) ?? 0;

            return girisToplam - cikisToplam;
        }
        private int HesaplaMevcutStokIskelet()
        {
            var girisToplam = _context.IskeletDepolar
                .Where(x => x.HareketTipi == "Giris" || x.HareketTipi == "Giriş")
                .Sum(x => (int?)x.Miktar) ?? 0;

            var cikisToplam = _context.IskeletDepolar
                .Where(x => x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış")
                .Sum(x => (int?)x.Miktar) ?? 0;

            return girisToplam - cikisToplam;
        }
        private int BugunGirisIskelet()
        {
            var bugun = DateTime.Today;
            return _context.IskeletDepolar
                .Where(x => (x.HareketTipi == "Giris" || x.HareketTipi == "Giriş") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunCikisIskelet()
        {
            var bugun = DateTime.Today;
            return _context.IskeletDepolar
                .Where(x => (x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunGirisSunger()
        {
            var bugun = DateTime.Today;
            return _context.SungerDepolar
                .Where(x => (x.HareketTipi == "Giris" || x.HareketTipi == "Giriş") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunCikisSunger()
        {
            var bugun = DateTime.Today;
            return _context.SungerDepolar
                .Where(x => (x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunGirisKolcak()
        {
            var bugun = DateTime.Today;
            return _context.KolcakDepolar
                .Where(x => (x.HareketTipi == "Giris" || x.HareketTipi == "Giriş") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunCikisKolcak()
        {
            var bugun = DateTime.Today;
            return _context.KolcakDepolar
                .Where(x => (x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunGirisKilif()
        {
            var bugun = DateTime.Today;
            return _context.KilifDepolar
                .Where(x => (x.HareketTipi == "Giris" || x.HareketTipi == "Giriş") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunCikisKilif()
        {
            var bugun = DateTime.Today;
            return _context.KilifDepolar
                .Where(x => (x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunGirisBaslik()
        {
            var bugun = DateTime.Today;
            return _context.BaslikDepolar
                .Where(x => (x.HareketTipi == "Giris" || x.HareketTipi == "Giriş") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private int BugunCikisBaslik()
        {
            var bugun = DateTime.Today;
            return _context.BaslikDepolar
                .Where(x => (x.HareketTipi == "Cikis" || x.HareketTipi == "Çıkış") && x.Tarih.Date == bugun)
                .Sum(x => (int?)x.Miktar) ?? 0;
        }
        private void DashboardBaslik()
        {
            // Son 7 günün tarihleri
            var bugun = DateTime.Today;
            var son7Gun = Enumerable.Range(0, 7)
                .Select(i => bugun.AddDays(-i))
                .OrderBy(t => t)
                .ToList();

            var girisVerileri = new List<int>();
            var cikisVerileri = new List<int>();
            var tarihEtiketleri = new List<string>();

            foreach (var tarih in son7Gun)
            {
                int giris = _context.BaslikDepolar
                    .Where(x => x.HareketTipi == "Giris" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                int cikis = _context.BaslikDepolar
                    .Where(x => x.HareketTipi == "Cikis" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                girisVerileri.Add(giris);
                cikisVerileri.Add(cikis);
                tarihEtiketleri.Add(tarih.ToString("dd.MM"));
            }

            ViewBag.TarihEtiketleri = tarihEtiketleri;
            ViewBag.GirisVerileri = girisVerileri;
            ViewBag.CikisVerileri = cikisVerileri;

        }
        private void DashboardKilif()
        {
            // Son 7 günün tarihleri
            var bugun = DateTime.Today;
            var son7Gun = Enumerable.Range(0, 7)
                .Select(i => bugun.AddDays(-i))
                .OrderBy(t => t)
                .ToList();

            var girisVerileri = new List<int>();
            var cikisVerileri = new List<int>();
            var tarihEtiketleri = new List<string>();

            foreach (var tarih in son7Gun)
            {
                int giris = _context.KilifDepolar
                    .Where(x => x.HareketTipi == "Giris" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                int cikis = _context.KilifDepolar
                    .Where(x => x.HareketTipi == "Cikis" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                girisVerileri.Add(giris);
                cikisVerileri.Add(cikis);
                tarihEtiketleri.Add(tarih.ToString("dd.MM"));
            }

            ViewBag.TarihEtiketleri = tarihEtiketleri;
            ViewBag.GirisVerileri = girisVerileri;
            ViewBag.CikisVerileri = cikisVerileri;

        }

        private void DashboardKolcak()
        {
            // Son 7 günün tarihleri
            var bugun = DateTime.Today;
            var son7Gun = Enumerable.Range(0, 7)
                .Select(i => bugun.AddDays(-i))
                .OrderBy(t => t)
                .ToList();

            var girisVerileri = new List<int>();
            var cikisVerileri = new List<int>();
            var tarihEtiketleri = new List<string>();

            foreach (var tarih in son7Gun)
            {
                int giris = _context.KolcakDepolar
                    .Where(x => x.HareketTipi == "Giris" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                int cikis = _context.KolcakDepolar
                    .Where(x => x.HareketTipi == "Cikis" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                girisVerileri.Add(giris);
                cikisVerileri.Add(cikis);
                tarihEtiketleri.Add(tarih.ToString("dd.MM"));
            }

            ViewBag.TarihEtiketleri = tarihEtiketleri;
            ViewBag.GirisVerileri = girisVerileri;
            ViewBag.CikisVerileri = cikisVerileri;

        }

        private void DashboardSunger()
        {
            // Son 7 günün tarihleri
            var bugun = DateTime.Today;
            var son7Gun = Enumerable.Range(0, 7)
                .Select(i => bugun.AddDays(-i))
                .OrderBy(t => t)
                .ToList();

            var girisVerileri = new List<int>();
            var cikisVerileri = new List<int>();
            var tarihEtiketleri = new List<string>();

            foreach (var tarih in son7Gun)
            {
                int giris = _context.SungerDepolar
                    .Where(x => x.HareketTipi == "Giris" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                int cikis = _context.SungerDepolar
                    .Where(x => x.HareketTipi == "Cikis" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                girisVerileri.Add(giris);
                cikisVerileri.Add(cikis);
                tarihEtiketleri.Add(tarih.ToString("dd.MM"));
            }

            ViewBag.TarihEtiketleri = tarihEtiketleri;
            ViewBag.GirisVerileri = girisVerileri;
            ViewBag.CikisVerileri = cikisVerileri;

        }


        private void DashboardIskelet()
        {
            // Son 7 günün tarihleri
            var bugun = DateTime.Today;
            var son7Gun = Enumerable.Range(0, 7)
                .Select(i => bugun.AddDays(-i))
                .OrderBy(t => t)
                .ToList();

            var girisVerileri = new List<int>();
            var cikisVerileri = new List<int>();
            var tarihEtiketleri = new List<string>();

            foreach (var tarih in son7Gun)
            {
                int giris = _context.IskeletDepolar
                    .Where(x => x.HareketTipi == "Giris" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                int cikis = _context.IskeletDepolar
                    .Where(x => x.HareketTipi == "Cikis" && x.Tarih.Date == tarih)
                    .Sum(x => (int?)x.Miktar) ?? 0;

                girisVerileri.Add(giris);
                cikisVerileri.Add(cikis);
                tarihEtiketleri.Add(tarih.ToString("dd.MM"));
            }

            ViewBag.TarihEtiketleri = tarihEtiketleri;
            ViewBag.GirisVerileri = girisVerileri;
            ViewBag.CikisVerileri = cikisVerileri;

        }



    }
}
