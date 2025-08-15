using Microsoft.AspNetCore.Mvc;
using AmbarYonetimi.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AmbarYonetimi.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var toplamMalzeme = _context.BaslikDepolar.Count() +
                                _context.SungerDepolar.Count() +
                                _context.IskeletDepolar.Count() +
                                _context.KilifDepolar.Count() +
                                _context.KolcakDepolar.Count();

            var toplamGiris = _context.BaslikDepolar.Where(x => x.HareketTipi == "Giriş").Sum(x => x.Miktar)
                               + _context.SungerDepolar.Where(x => x.HareketTipi == "Giriş").Sum(x => x.Miktar);

            var toplamCikis = _context.BaslikDepolar.Where(x => x.HareketTipi == "Çıkış").Sum(x => x.Miktar)
                               + _context.SungerDepolar.Where(x => x.HareketTipi == "Çıkış").Sum(x => x.Miktar);

            var stokDurumu = toplamGiris - toplamCikis;

            var sonIslemler = _context.BaslikDepolar
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(x => new {
                    x.Tarih,
                    x.UrunAdi,
                    x.HareketTipi,
                    x.Miktar,
                    x.IslemYapan
                }).ToList();

            ViewBag.ToplamMalzeme = toplamMalzeme;
            ViewBag.ToplamGiris = toplamGiris;
            ViewBag.ToplamCikis = toplamCikis;
            ViewBag.StokDurumu = stokDurumu;
            ViewBag.SonIslemler = sonIslemler;

            return View();
        }
        public IActionResult KullaniciListesi()
        {
            var kullanicilar = _context.Kullanicilar.ToList();
            return View(kullanicilar);
        }

        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return RedirectToAction("KullaniciListesi");
        }

        [HttpGet]
        public IActionResult KullaniciDuzenle(int id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult KullaniciDuzenle(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            _context.SaveChanges();
            return RedirectToAction("KullaniciListesi");
        }

        public IActionResult KullaniciSil(int id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            _context.Kullanicilar.Remove(kullanici);
            _context.SaveChanges();
            return RedirectToAction("KullaniciListesi");
        }
        public IActionResult Baslik()
        {
            var model = _context.BaslikDepolar.ToList();
            return View(model);
        }

        public IActionResult Sunger()
        {
            var model = _context.SungerDepolar.ToList();
            return View(model);
        }

        public IActionResult Iskelet()
        {
            var model = _context.IskeletDepolar.ToList();
            return View(model);
        }

        public IActionResult Kolcak()
        {
            var model = _context.KolcakDepolar.ToList();
            return View(model);
        }

        public IActionResult Kilif()
        {
            var model = _context.KilifDepolar.ToList();
            return View(model);
        }

        public IActionResult Raporlar()
        {
            // Tablolardan özet bilgiler al
            var toplamBaslik = _context.BaslikDepolar.Sum(x => x.Miktar);
            var toplamSunger = _context.SungerDepolar.Sum(x => x.Miktar);
            var toplamIskelet = _context.IskeletDepolar.Sum(x => x.Miktar);
            var toplamKolcak = _context.KolcakDepolar.Sum(x => x.Miktar);
            var toplamKilif = _context.KilifDepolar.Sum(x => x.Miktar);

            ViewBag.ToplamBaslik = toplamBaslik;
            ViewBag.ToplamSunger = toplamSunger;
            ViewBag.ToplamIskelet = toplamIskelet;
            ViewBag.ToplamKolcak = toplamKolcak;
            ViewBag.ToplamKilif = toplamKilif;

            ViewBag.GenelToplam = toplamBaslik + toplamSunger + toplamIskelet + toplamKolcak + toplamKilif;

            return View();
        }


            [HttpGet]
            public IActionResult GetDepoVerileri(string depo)
            {
                IQueryable<object> data = null;

                switch (depo)
                {
                    case "BaslikDepo":
                        data = _context.BaslikDepolar.Select(x => new { x.Id, x.UrunAdi, x.UrunKodu, x.RafKodu, x.HareketTipi, x.Miktar, x.IslemYapan });
                        break;
                    case "SungerDepo":
                        data = _context.SungerDepolar.Select(x => new { x.Id, x.UrunAdi, x.UrunKodu, x.RafKodu, x.HareketTipi, x.Miktar, x.IslemYapan });
                        break;
                    case "IskeletDepo":
                        data = _context.IskeletDepolar.Select(x => new { x.Id, x.UrunAdi, x.UrunKodu, x.RafKodu, x.HareketTipi, x.Miktar, x.IslemYapan });
                        break;
                    case "KolcakDepo":
                        data = _context.KolcakDepolar.Select(x => new { x.Id, x.UrunAdi, x.UrunKodu, x.RafKodu, x.HareketTipi, x.Miktar, x.IslemYapan });
                        break;
                    case "KilifDepo":
                        data = _context.KilifDepolar.Select(x => new { x.Id, x.UrunAdi, x.UrunKodu, x.RafKodu, x.HareketTipi, x.Miktar, x.IslemYapan });
                        break;
                    default:
                        return Json(new object[] { });
                }

                return Json(data.ToList());
            }

            [HttpGet]
            public IActionResult GetDepoPdf(string depo)
            {
                ViewBag.DepoAdi = depo;
                return View("pdf");
            }


        public IActionResult BaslikSil(int id)
        {
            var entity = _context.BaslikDepolar.Find(id);
            if (entity != null)
            {
                _context.BaslikDepolar.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("Baslik");
        }

        public IActionResult KolcakSil(int id)
        {
            var entity = _context.KolcakDepolar.Find(id);
            if (entity != null)
            {
                _context.KolcakDepolar.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("Kolcak");
        }

        public IActionResult SungerSil(int id)
        {
            var entity = _context.SungerDepolar.Find(id);
            if (entity != null)
            {
                _context.SungerDepolar.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("Sunger");
        }

        public IActionResult IskeletSil(int id)
        {
            var entity = _context.IskeletDepolar.Find(id);
            if (entity != null)
            {
                _context.IskeletDepolar.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("Iskelet");
        }
        public IActionResult BaslikDuzenle(int id)
        {
            var entity = _context.BaslikDepolar.Find(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // POST: Formdan gelen veriyi kaydeder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BaslikDuzenle(BaslikDepo model)
        {
            if (ModelState.IsValid)
            {
                _context.BaslikDepolar.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Baslik");
            }

            return View(model);
        }

    }
}




