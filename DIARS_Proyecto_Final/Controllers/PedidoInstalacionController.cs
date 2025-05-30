using DIARS_Proyecto_Final.Data;
using DIARS_Proyecto_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIARS_Proyecto_Final.Controllers
{
    public class PedidoInstalacionController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoInstalacionController(AppDbContext context) => _context = context;

        // GET: /PedidoInstalacion/Index
        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.PedidoInstalacion.ToListAsync();
            return View(pedidos);
        }

        // GET: /PedidoInstalacion/Create
        public IActionResult Create()
        {
            return View(new PedidoInstalacion());
        }

        // POST: /PedidoInstalacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoInstalacion model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.PedidoInstalacion.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /PedidoInstalacion/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _context.PedidoInstalacion.FindAsync(id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

        // POST: /PedidoInstalacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoInstalacion model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var pedido = await _context.PedidoInstalacion.FindAsync(model.pedido_id);
            if (pedido == null) return NotFound();

            pedido.contrato_id = model.contrato_id;
            pedido.empleado_id = model.empleado_id;
            pedido.fecha_instalacion = model.fecha_instalacion;
            pedido.estado_instalacion = model.estado_instalacion;
            pedido.observaciones = model.observaciones;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /PedidoInstalacion/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _context.PedidoInstalacion.FindAsync(id);
            if (pedido == null) return NotFound();

            _context.PedidoInstalacion.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
