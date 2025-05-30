using DIARS_Proyecto_Final.Data;
using DIARS_Proyecto_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DIARS_Proyecto_Final.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDbContext _context;

        public EmpleadoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MostrarEmpleados()
        {
            var empleados = await _context.Empleados
                .Include(e => e.Cargo)
                .AsNoTracking()
                .ToListAsync();

            return View(empleados);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            CargarCargosViewBag();
            var model = new Empleado
            {
                estado = "activo", // Valor por defecto
                fecha_inicio = DateTime.Today // Fecha actual por defecto
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarEmpleado(Empleado empleado, int mesesDuracion)
        {
            try
            {
                // Validación básica de DNI único
                if (await _context.Empleados.AnyAsync(e => e.dni == empleado.dni))
                {
                    TempData["ErrorMessage"] = "Este DNI ya está registrado";
                    CargarCargosViewBag();
                    return View("Agregar", empleado);
                }

                // Asignación de valores por defecto 
                empleado.estado = "activo";
                empleado.fecha_fin = empleado.fecha_inicio?.AddMonths(mesesDuracion);

                // Guardar directamente
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Empleado agregado correctamente";
                return RedirectToAction(nameof(MostrarEmpleados));
            }
            catch (Exception ex)
            {
                // Manejo simple de errores
                TempData["ErrorMessage"] = $"Error al guardar: {ex.Message}";
                CargarCargosViewBag();
                return View("Agregar", empleado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            CargarCargosViewBag();
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEmpleado(int id, Empleado empleado)
        {
            try
            {

                // Encontrar y actualizar directamente como en Inhabilitar
                var empleadoExistente = await _context.Empleados.FindAsync(id);
                if (empleadoExistente == null)
                {
                    return NotFound();
                }

                // Actualización directa de campos
                empleadoExistente.cargo_id = empleado.cargo_id;
                empleadoExistente.nombres = empleado.nombres;
                empleadoExistente.dni = empleado.dni;
                empleadoExistente.telefono = empleado.telefono;
                empleadoExistente.correo = empleado.correo;
                empleadoExistente.estado = empleado.estado;
                empleadoExistente.fecha_inicio = empleado.fecha_inicio;
                empleadoExistente.fecha_fin = empleado.fecha_fin;



                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Empleado actualizado correctamente";
                return RedirectToAction(nameof(MostrarEmpleados));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al actualizar: {ex.Message}";
                CargarCargosViewBag();
                return View("Editar", empleado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> InhabilitarEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.estado = "inhabilitado";
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Empleado inhabilitado correctamente";
            return RedirectToAction(nameof(MostrarEmpleados));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.empleado_id == id);
        }

        private void CargarCargosViewBag()
        {
            ViewBag.Cargos = new SelectList(_context.Cargos.AsNoTracking().ToList(), "cargo_id", "titulo_cargo");
        }
    }
}