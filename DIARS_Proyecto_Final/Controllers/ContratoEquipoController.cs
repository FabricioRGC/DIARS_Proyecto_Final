using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIARS_Proyecto_Final.Data;
using DIARS_Proyecto_Final.Services.Interfaces;
using System;

namespace DIARS_Proyecto_Final.Controllers
{
    public class ContratoEquipoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IContratoEquipoService _service;

        public ContratoEquipoController(AppDbContext context, IContratoEquipoService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Mostrar formulario de asignación
        public async Task<IActionResult> Asignar()
        {
            var contratos = await _context.Contratos.OrderBy(c => c.Id).ToListAsync();
            var equiposActivos = await _context.Equipos
                .Where(e => e.Estado == "activo")
                .ToListAsync();

            ViewBag.Contratos = new SelectList(contratos, "Id", "Id");
            ViewBag.Equipos = new SelectList(equiposActivos, "EquipoId", "NombreEquipo");
            ViewBag.Estados = new SelectList(new[] { "activo", "devuelto", "dañado" });

            return View();
        }

        // POST: Procesar asignación
        [HttpPost]
        public async Task<IActionResult> Asignar(int contratoId, int equipoId, string estado)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Asignar));

            await _service.AsignarContratoEquipoAsync(contratoId, equipoId, estado);
            return RedirectToAction("Administrar", "Equipo");
        }


    }
}
