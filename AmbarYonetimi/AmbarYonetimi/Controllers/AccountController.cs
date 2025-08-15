using AmbarYonetimi.Models;
using AmbarYonetimi.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace AmbarYonetimi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Çıkış
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // Login sayfası GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // Login işlemi POST
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username);

                if (user != null && model.Password == user.Password) // şifre düz metin kontrolü
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("Role", user.Role);

                    TempData["SuccessMessage"] = "Giriş başarılı!";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("Id", user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    if (user.Username == "admin")
                        return RedirectToAction("Index", "Admin");
                    else if (user.Role == "Employee")
                        return RedirectToAction("Index", "Malzeme");
                    else
                        return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(model);
        }

        // API endpoint - Kullanıcı bilgilerini al
        [Authorize]
        [HttpGet]
        public IActionResult GetUserInfo()
        {
            return Json(new
            {
                username = User.Identity?.Name,
                userId = User.FindFirstValue("Id")
            });
        }

        // Register sayfası GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register işlemi POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı var mı kontrol et
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username);

                if (existingUser != null)
                {
                    TempData["ErrorMessage"] = "Bu kullanıcı adı zaten alınmış.";
                    return View(model);
                }

                // Yeni kullanıcı oluştur
                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password, // düz metin şifre - güvenlik açısından hashlenmeli
                    Role = "Employee"
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
                return RedirectToAction("Login", "Account");
            }

            TempData["ErrorMessage"] = "Kayıt başarısız. Lütfen bilgilerinizi kontrol edin.";
            return View(model);
        }
    }
}
