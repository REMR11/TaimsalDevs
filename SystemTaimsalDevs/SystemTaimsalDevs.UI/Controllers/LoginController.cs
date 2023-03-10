using Microsoft.AspNetCore.Mvc;
/********************************/
using SystemTaimsalDevs.BL;
using SystemTaimsalDevs.EL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SysTaimsal.UI.Controllers
{
    public class LoginController : Controller
    {
        UserDevsBL usuarioBL = new UserDevsBL();
        RolBL rolBL = new RolBL();
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        //// GET: UsuarioController/Create
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(string? ReturnUrl = null)
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    ViewBag.Url = ReturnUrl;
        //    ViewBag.Error = "";
        //    return View();
        //}

        //// POST: UsuarioController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(UserDev pUsuario, string? pReturnUrl = null)
        //{
        //    try
        //    {
        //        var usuario = await usuarioBL.LoginAsync(pUsuario);
        //        if (usuario != null && usuario.IdUser > 0 && pUsuario.Login == usuario.Login)
        //        {
        //            usuario.IdRol = await rolBL.GetByIdAsync(new Rol { IdRol = usuario.IdRol });
        //            var claims = new[] { new Claim(ClaimTypes.Name, usuario.Login), new Claim(ClaimTypes.Role, usuario.IdRol.Nombre) };
        //            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        //        }
        //        else
        //            throw new Exception("Credenciales incorrectas");
        //        if (!string.IsNullOrWhiteSpace(pReturnUrl))
        //            return Redirect(pReturnUrl);
        //        else
        //            return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Url = pReturnUrl;
        //        ViewBag.Error = ex.Message;
        //        return View(new Usuario { Login = pUsuario.Login });
        //    }
        //}
    }
}
