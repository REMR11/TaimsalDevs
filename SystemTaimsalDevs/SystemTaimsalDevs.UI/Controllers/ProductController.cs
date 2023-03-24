using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysTaimsal.UI.Models;
using SystemTaimsalDevs.BL;
using SystemTaimsalDevs.DAL;
using SystemTaimsalDevs.EL;
using SystemTaimsalDevs.UI.Data;
using SystemTaimsalDevs.UI.Models;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;
using Path = System.IO.Path;

namespace SystemTaimsalDevs.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly SystemTaimsalDevsContext _context = new SystemTaimsalDevsContext();
        ProductBL ProductBL = new ProductBL();

        public static string SaveFile(IFormFile archivo)
        {
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.name = Guid.NewGuid().ToString() + archivo.FileName;
            fileViewModel.path = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\GuardarImagen\\" + fileViewModel.name);
            using var stream = new FileStream(fileViewModel.path, FileMode.Create);
            archivo.CopyTo(stream);
            return "..\\GuardarImagen\\" + fileViewModel.name;
        }

        // GET: Product
        public async Task<IActionResult> Index(string buscar)
        {

            var product = from products in _context.Products select products;

            if (!String.IsNullOrEmpty(buscar))
            {
                product = product.Where(s => s.NameProduct!.Contains(buscar));
            }
            return View(await product.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,NameProduct,ImageProduct,DescriptionProduct,Price,Stock")] Product product, IFormFile formFile)
        {
            try
            {
                product.ImageProduct = FileViewModel.SaveFile(formFile);
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,NameProduct,ImageProduct,DescriptionProduct,Price,Stock")] Product product, IFormFile FileUpload)
        {
            if (id != product.IdProduct)
            {
                return NotFound();
            }
            product.ImageProduct = FileViewModel.SaveFile(FileUpload);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.IdProduct))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'SystemTaimsalDevsContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.IdProduct == id)).GetValueOrDefault();
        }
    }
}
