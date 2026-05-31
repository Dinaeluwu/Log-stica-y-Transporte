using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Logistica_y_transporte.Models;

namespace Logistica_y_transporte.Controllers
{
    public class EnviosController : Controller
    {
        private readonly AppDbContext _context;

        public EnviosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Envios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Envios
                .Include(e => e.Paquete)
                .Include(e => e.Ruta);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Envios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Paquete)
                .Include(e => e.Ruta)
                .FirstOrDefaultAsync(m => m.id_envio == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // GET: Envios/Create
        public async Task<IActionResult> Create()
        {
            await PopulateViewDataAsync();
            return View();
        }

        // POST: Envios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_envio,id_paquete,id_ruta,fecha_envio,estado")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                envio.id_envio = Guid.NewGuid();
                _context.Add(envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateViewDataAsync(envio.id_paquete, envio.id_ruta);
            return View(envio);
        }

        // GET: Envios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios.FindAsync(id);
            if (envio == null)
            {
                return NotFound();
            }
            await PopulateViewDataAsync(envio.id_paquete, envio.id_ruta);
            return View(envio);
        }

        // POST: Envios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id_envio,id_paquete,id_ruta,fecha_envio,estado")] Envio envio)
        {
            if (id != envio.id_envio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioExists(envio.id_envio))
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
            await PopulateViewDataAsync(envio.id_paquete, envio.id_ruta);
            return View(envio);
        }

        // GET: Envios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var envio = await _context.Envios
                .Include(e => e.Paquete)
                .Include(e => e.Ruta)
                .FirstOrDefaultAsync(m => m.id_envio == id);
            if (envio == null)
            {
                return NotFound();
            }

            return View(envio);
        }

        // POST: Envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioExists(Guid id)
        {
            return _context.Envios.Any(e => e.id_envio == id);
        }

        private async Task PopulateViewDataAsync(Guid? id_paquete = null, int? id_ruta = null)
        {
            var paquetes = await _context.Paquetes.ToListAsync();
            ViewData["id_paquete"] = new SelectList(
                paquetes.Select(p => new { p.ID_paquete, Label = p.descripcion ?? p.ID_paquete.ToString() }),
                "ID_paquete",
                "Label",
                id_paquete);

            ViewData["id_ruta"] = new SelectList(_context.Rutas, "id_ruta", "zona", id_ruta);
        }
    }
}
