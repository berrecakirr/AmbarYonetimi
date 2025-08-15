using Microsoft.AspNetCore.Mvc;
using AmbarYonetimi.Models;
using System.Linq;

namespace AmbarYonetimi.Controllers
{
    public class RaporController : Controller
    {
        private readonly AppDbContext _context;

        public RaporController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Views/Rapor/Index.cshtml
        }

        [HttpGet]
        public IActionResult GetDepoVerileri(string depo)
        {
            if (string.IsNullOrEmpty(depo))
                return BadRequest("Depo adı geçersiz.");

            switch (depo)
            {
                case "BaslikDepo":
                    return Json(_context.BaslikDepolar.ToList());
                case "IskeletDepo":
                    return Json(_context.IskeletDepolar.ToList());
                case "KilifDepo":
                    return Json(_context.KilifDepolar.ToList());
                case "KolcakDepo":
                    return Json(_context.KolcakDepolar.ToList());
                case "SungerDepo":
                    return Json(_context.SungerDepolar.ToList());
                default:
                    return BadRequest("Geçersiz depo adı.");
            }
        }
    }
}
