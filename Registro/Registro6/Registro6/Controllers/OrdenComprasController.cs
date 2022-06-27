using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registro6.Data;
using Registro6.Models;

namespace Registro6.Controllers
{
    public class OrdenComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenComprasController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: OrdenCompras
        public async Task<IActionResult> Index()
        {
              return View(await _context.OrdenCompraImp.ToListAsync());
        }
        // GET: OrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenCompraImp == null)
            {
                return NotFound();
            }
            var ordenCompraImp = await _context.OrdenCompraImp
                .FirstOrDefaultAsync(m => m.IdOrdenCompraImp == id);
            if (ordenCompraImp == null)
            {
                return NotFound();
            }

            return View(ordenCompraImp);
        }
        // GET: /Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: OrdenCompras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenCompraImp,TipoOCompra,NroOCompra,Fecha,TipoCambio,Estado,CodInterno,CodCotizacion,Proveedor,Contacto,Area,TipoCompra,CondicionPago")] OrdenCompraImp ordenCompraImp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompraImp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenCompraImp);
        }
        // GET:/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenCompraImp == null)
            {
                return NotFound();
            }
            var ordenCompraImp = await _context.OrdenCompraImp.FindAsync(id);
            if (ordenCompraImp == null)
            {
                return NotFound();
            }
            return View(ordenCompraImp);
        }
        // POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenCompraImp,TipoOCompra,NroOCompra,Fecha,TipoCambio,Estado,CodInterno,CodCotizacion,Proveedor,Contacto,Area,TipoCompra,CondicionPago")] OrdenCompraImp ordenCompraImp)
        {
            if (id != ordenCompraImp.IdOrdenCompraImp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompraImp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraImpExists(ordenCompraImp.IdOrdenCompraImp))
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
            return View(ordenCompraImp);
        }

        // GET: OrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenCompraImp == null)
            {
                return NotFound();
            }

            var ordenCompraImp = await _context.OrdenCompraImp
                .FirstOrDefaultAsync(m => m.IdOrdenCompraImp == id);
            if (ordenCompraImp == null)
            {
                return NotFound();
            }

            return View(ordenCompraImp);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenCompraImp == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrdenCompraImp'  is null.");
            }
            var ordenCompraImp = await _context.OrdenCompraImp.FindAsync(id);
            if (ordenCompraImp != null)
            {
                _context.OrdenCompraImp.Remove(ordenCompraImp);
            } 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool OrdenCompraImpExists(int id)
        {
          return _context.OrdenCompraImp.Any(e => e.IdOrdenCompraImp == id);
        }
    }
}
