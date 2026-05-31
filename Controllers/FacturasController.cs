using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Logistica_y_transporte.Models;

namespace Logistica_y_transporte.Controllers
{
    public class FacturasController : Controller
    {
        private readonly AppDbContext _context;

        public FacturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Envio);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Envio)
                .FirstOrDefaultAsync(m => m.id_factura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public async Task<IActionResult> Create()
        {
            await PopulateViewDataAsync();
            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_factura,id_cliente,id_envio,monto,fechas")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                factura.id_factura = Guid.NewGuid();
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateViewDataAsync(factura.id_cliente, factura.id_envio);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            await PopulateViewDataAsync(factura.id_cliente, factura.id_envio);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id_factura,id_cliente,id_envio,monto,fechas")] Factura factura)
        {
            if (id != factura.id_factura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.id_factura))
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
            await PopulateViewDataAsync(factura.id_cliente, factura.id_envio);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.Envio)
                .FirstOrDefaultAsync(m => m.id_factura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(Guid id)
        {
            return _context.Facturas.Any(e => e.id_factura == id);
        }

        private async Task PopulateViewDataAsync(Guid? id_cliente = null, Guid? id_envio = null)
        {
            ViewData["id_cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "nombre", id_cliente);
            var envios = await _context.Envios.ToListAsync();
            ViewData["id_envio"] = new SelectList(
                envios.Select(e => new { e.id_envio, Label = $"{e.fecha_envio:d} - {e.estado}" }),
                "id_envio",
                "Label",
                id_envio);
        }
    }
}
