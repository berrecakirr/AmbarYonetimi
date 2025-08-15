using AmbarYonetimi.Models;
using AmbarYonetimi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class DepoController : Controller
{
    private readonly AppDbContext _context;

    public DepoController(AppDbContext context)
    {
        _context = context;
    }

    // -------------------- CREATE --------------------
    // GET: Depo/Create
    public IActionResult Create()
    {
        return View(new DepolarViewModel());
    }

    // POST: Depo/Create
    [HttpPost]
    public IActionResult Create(DepolarViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var hatalar = ModelState.Values.SelectMany(v => v.Errors).ToList();
            TempData["Hata"] = string.Join("<br/>", hatalar.Select(h => h.ErrorMessage));
            return View(model);
        }

        int miktarDegeri = (int)(model.HareketTipi == "Çıkış" ? -model.Miktar : model.Miktar);

        switch (model.UrunAdi)
        {
            case "Baslik":
                _context.BaslikDepolar.Add(new BaslikDepo
                {
                    UrunAdi = model.UrunAdi,
                    UrunKodu = model.UrunKodu,
                    RafKodu = model.RafKodu,
                    IslemYapan = model.IslemYapan,
                    HareketTipi = model.HareketTipi,
                    Miktar = miktarDegeri,
                    Tarih = DateTime.Now,
                });
                break;

            case "Iskelet":
                _context.IskeletDepolar.Add(new IskeletDepo
                {
                    UrunAdi = model.UrunAdi,
                    UrunKodu = model.UrunKodu,
                    RafKodu = model.RafKodu,
                    IslemYapan = model.IslemYapan,
                    HareketTipi = model.HareketTipi,
                    Miktar = miktarDegeri,
                    Tarih = DateTime.Now,
                });
                break;

            case "Kilif":
                _context.KilifDepolar.Add(new KilifDepo
                {
                    UrunAdi = model.UrunAdi,
                    UrunKodu = model.UrunKodu,
                    RafKodu = model.RafKodu,
                    IslemYapan = model.IslemYapan,
                    HareketTipi = model.HareketTipi,
                    Miktar = miktarDegeri,
                    Tarih = DateTime.Now,
                });
                break;

            case "Kolcak":
                _context.KolcakDepolar.Add(new KolcakDepo
                {
                    UrunAdi = model.UrunAdi,
                    UrunKodu = model.UrunKodu,
                    RafKodu = model.RafKodu,
                    IslemYapan = model.IslemYapan,
                    HareketTipi = model.HareketTipi,
                    Miktar = miktarDegeri,
                    Tarih = DateTime.Now,
                });
                break;

            case "Sunger":
                _context.SungerDepolar.Add(new SungerDepo
                {
                    UrunAdi = model.UrunAdi,
                    UrunKodu = model.UrunKodu,
                    RafKodu = model.RafKodu,
                    IslemYapan = model.IslemYapan,
                    HareketTipi = model.HareketTipi,
                    Miktar = miktarDegeri,
                    Tarih = DateTime.Now,
                });
                break;
        }

        _context.SaveChanges();
        return RedirectToAction("Index", "Dashboard");
    }

    // -------------------- EDIT --------------------
    // GET: Depo/Edit
    [HttpGet]
    public IActionResult Edit(int id, string tablo)
    {
        object model = null;
        string viewName = "";

        switch (tablo)
        {
            case "Iskelet":
                model = _context.IskeletDepolar.Find(id);
                viewName = "EditIskelet";
                break;
            case "Baslik":
                model = _context.BaslikDepolar.Find(id);
                viewName = "EditBaslik";
                break;
            case "Kilif":
                model = _context.KilifDepolar.Find(id);
                viewName = "EditKilif";
                break;
            case "Kolcak":
                model = _context.KolcakDepolar.Find(id);
                viewName = "EditKolcak";
                break;
            case "Sunger":
                model = _context.SungerDepolar.Find(id);
                viewName = "EditSunger";
                break;
        }

        if (model == null) return NotFound();

        return View(viewName, model);
    }

    // POST: Depo/Edit
    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> EditPost(int id, string tablo)
    {
        switch (tablo)
        {
            case "Iskelet":
                var iskelet = _context.IskeletDepolar.Find(id);
                if (iskelet == null) return NotFound();
                await TryUpdateModelAsync(iskelet);
                break;

            case "Baslik":
                var baslik = _context.BaslikDepolar.Find(id);
                if (baslik == null) return NotFound();
                await TryUpdateModelAsync(baslik);
                break;

            case "Kilif":
                var kilif = _context.KilifDepolar.Find(id);
                if (kilif == null) return NotFound();
                await TryUpdateModelAsync(kilif);
                break;

            case "Kolcak":
                var kolcak = _context.KolcakDepolar.Find(id);
                if (kolcak == null) return NotFound();
                await TryUpdateModelAsync(kolcak);
                break;

            case "Sunger":
                var sunger = _context.SungerDepolar.Find(id);
                if (sunger == null) return NotFound();
                await TryUpdateModelAsync(sunger);
                break;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction($"{tablo}Depo");
    }

    // -------------------- DELETE --------------------
    [HttpPost]
    public async Task<IActionResult> Delete(int id, string tablo)
    {
        switch (tablo)
        {
            case "Iskelet":
                var iskelet = await _context.IskeletDepolar.FindAsync(id);
                if (iskelet != null) _context.IskeletDepolar.Remove(iskelet);
                break;
            case "Baslik":
                var baslik = await _context.BaslikDepolar.FindAsync(id);
                if (baslik != null) _context.BaslikDepolar.Remove(baslik);
                break;
            case "Kilif":
                var kilif = await _context.KilifDepolar.FindAsync(id);
                if (kilif != null) _context.KilifDepolar.Remove(kilif);
                break;
            case "Kolcak":
                var kolcak = await _context.KolcakDepolar.FindAsync(id);
                if (kolcak != null) _context.KolcakDepolar.Remove(kolcak);
                break;
            case "Sunger":
                var sunger = await _context.SungerDepolar.FindAsync(id);
                if (sunger != null) _context.SungerDepolar.Remove(sunger);
                break;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction($"{tablo}Depo"); // bulunduğun liste sayfasına geri dön
    }

    // -------------------- LİSTELEME --------------------
    public async Task<IActionResult> BaslikDepo()
    {
        return View(await _context.BaslikDepolar.ToListAsync());
    }

    public async Task<IActionResult> KilifDepo()
    {
        return View(await _context.KilifDepolar.ToListAsync());
    }

    public async Task<IActionResult> IskeletDepo()
    {
        return View(await _context.IskeletDepolar.ToListAsync());
    }

    public async Task<IActionResult> KolcakDepo()
    {
        return View(await _context.KolcakDepolar.ToListAsync());
    }

    public async Task<IActionResult> SungerDepo()
    {
        return View(await _context.SungerDepolar.ToListAsync());
    }
}
