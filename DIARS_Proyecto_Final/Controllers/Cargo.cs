using DIARS_Proyecto_Final.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DIARS_Proyecto_Final.Models;


namespace DIARS_Proyecto_Final.Controllers
{
    public class CargoController : Controller
    {
        private readonly AppDbContext _context;
        public CargoController(AppDbContext context) => _context = context;

        // GET: /Cargo/MostrarCargos
        public async Task<IActionResult> MostrarCargos()
        {
            var cargos = await _context.Cargos.ToListAsync();
            return View(cargos);
        }

        // GET: /Cargo/Agregar
        public IActionResult Agregar()
        {
            return View(new Cargo());
        }

        // POST: /Cargo/Agregar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Cargo model)
        {
            if (await _context.Cargos.AnyAsync(c => c.titulo_cargo == model.titulo_cargo))
                ModelState.AddModelError(nameof(model.titulo_cargo), "El título ya existe.");
            if (!ModelState.IsValid)
                return View(model);

            _context.Cargos.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MostrarCargos));
        }

        // GET: /Cargo/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null) return NotFound();
            return View(cargo);
        }

        // POST: /Cargo/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cargo model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var cargo = await _context.Cargos.FindAsync(model.cargo_id);
            if (cargo == null) return NotFound();

            cargo.titulo_cargo = model.titulo_cargo;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MostrarCargos));
        }
    }
}
