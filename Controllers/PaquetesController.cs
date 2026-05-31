using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Logistica_y_transporte.Models;

namespace Logistica_y_transporte.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly AppDbContext _context;

        public PaquetesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Paquetes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Paquetes.Include(p => p.Cliente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Paquetes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.ID_paquete == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // GET: Paquetes/Create
        public IActionResult Create()
        {
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "nombre");
            return View();
        }

        // POST: Paquetes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_paquete,id_cliente,descripcion,peso")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                paquete.ID_paquete = Guid.NewGuid();
                _context.Add(paquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "nombre", paquete.id_cliente);
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "nombre", paquete.id_cliente);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID_paquete,id_cliente,descripcion,peso")] Paquete paquete)
        {
            if (id != paquete.ID_paquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteExists(paquete.ID_paquete))
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
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "nombre", paquete.id_cliente);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.ID_paquete == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteExists(Guid id)
        {
            return _context.Paquetes.Any(e => e.ID_paquete == id);
        }
    }
}
