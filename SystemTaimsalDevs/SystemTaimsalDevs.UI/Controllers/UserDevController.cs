using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//--------------------------------------------------//
using SystemTaimsalDevs.BL;
using SystemTaimsalDevs.DAL;
using SystemTaimsalDevs.EL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;



namespace SystemTaimsalDevs.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UserDevController : Controller
    {
        private readonly SystemTaimsalDevsContext _context = new SystemTaimsalDevsContext();
        UserDevsBL usuarioBL = new UserDevsBL();
        RolBL rolBL = new RolBL();

        // GET: UserDev
        public async Task<IActionResult> Index()
        {
            var systemTaimsalDevsContext = _context.UserDevs.Include(u => u.IdRolNavigation);
            return View(await systemTaimsalDevsContext.ToListAsync());
        }

        // GET: UserDev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userDev == null)
            {
                return NotFound();
            }

            return View(userDev);
        }

        // GET: UserDev/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol");
            return View();
        }

        // POST: UserDev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdRol,NameUser,LastNameUser,Login,Password,StatusUser,RegistrationUser,ConfirmPassword_aux")] UserDev userDev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // GET: UserDev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs.FindAsync(id);
            if (userDev == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // POST: UserDev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdRol,NameUser,LastNameUser,Login,Password,StatusUser,RegistrationUser,ConfirmPassword_aux")] UserDev userDev)
        {
            if (id != userDev.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDevExists(userDev.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        // GET:
        [AllowAnonymous]
        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Url = ReturnUrl;
            ViewBag.Error = "";
            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDev pUserDev, string pReturnUrl = null)
        {
            try
            {
                var usuario = await usuarioBL.LoginAsync(pUserDev);
                if (usuario != null && usuario.IdUser > 0 && pUserDev.Login == usuario.Login)
                {
                    usuario.IdRolNavigation = await rolBL.GetByIdAsync(new Rol { IdRol = usuario.IdUser });
                    var claims = new[] { new Claim(ClaimTypes.Name, usuario.Login), new Claim(ClaimTypes.Role, usuario.IdRolNavigation.NameRol) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                }
                else
                    throw new Exception("Credenciales incorrectas");
                if (!string.IsNullOrWhiteSpace(pReturnUrl))
                    return Redirect(pReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Url = pReturnUrl;
                ViewBag.Error = ex.Message;
                return View(new UserDev { Login = pUserDev.Login });
            }
        }
        // GET: UserDev/Register
        public IActionResult Register()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol");
            return View();
        }

        // POST: UserDev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("IdUser,IdRol,NameUser,LastNameUser,Login,Password,StatusUser,RegistrationUser,ConfirmPassword_aux")] UserDev userDev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDev);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "NameRol", userDev.IdRol);
            return View(userDev);
        }

        //GET
        public async Task<IActionResult> ChangePassword()
        {
            var usuarios = await usuarioBL.BuscarAsync(new UserDev { Login = User.Identity.Name, Top_Aux = 1 });
            var usuarioActual = usuarios.FirstOrDefault();
            ViewBag.Error = "";
            return View(usuarioActual);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserDev pUserDev, string pPasswordAnt)
        {
            try
            {
                int result = await usuarioBL.ChangePasswordAsync(pUserDev, pPasswordAnt);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "UserDev");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                var usuarios = await usuarioBL.BuscarAsync(new UserDev { Login = User.Identity.Name, Top_Aux = 1 });
                var usuarioActual = usuarios.FirstOrDefault();
                return View(usuarioActual);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> CerrarSesion(string ReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "UserDev");
        }

        // GET: UserDev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDevs == null)
            {
                return NotFound();
            }

            var userDev = await _context.UserDevs
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userDev == null)
            {
                return NotFound();
            }

            return View(userDev);
        }

        // POST: UserDev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDevs == null)
            {
                return Problem("Entity set 'SystemTaimsalDevsContext.UserDevs'  is null.");
            }
            var userDev = await _context.UserDevs.FindAsync(id);
            if (userDev != null)
            {
                _context.UserDevs.Remove(userDev);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDevExists(int id)
        {
          return (_context.UserDevs?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }
    }
}
