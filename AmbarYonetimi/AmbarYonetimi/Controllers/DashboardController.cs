using Microsoft.AspNetCore.Mvc;
using AmbarYonetimi.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


[Authorize(Roles = "Employee")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        ViewBag.BaslikStok = _context.BaslikDepolar.Sum(x => x.Miktar);
        ViewBag.SungerStok = _context.SungerDepolar.Sum(x => x.Miktar);
        ViewBag.KolcakStok = _context.KolcakDepolar.Sum(x => x.Miktar);
        ViewBag.KilifStok = _context.KilifDepolar.Sum(x => x.Miktar);
        ViewBag.IskeletStok = _context.IskeletDepolar.Sum(x => x.Miktar);


        return View();
  }

}


