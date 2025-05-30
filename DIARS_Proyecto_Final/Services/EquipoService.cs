using DIARS_Proyecto_Final.Data;
using DIARS_Proyecto_Final.Models;
using DIARS_Proyecto_Final.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace pruevas_diars_fabricio_0001.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly AppDbContext _context;

        public EquipoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipo>> GetAllAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<List<Equipo>> ListarAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task CrearAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
        }

        public async Task AumentarStockAsync(int equipoId, int cantidad)
        {
            var equipo = await _context.Equipos.FindAsync(equipoId);
            if (equipo != null)
            {
                equipo.CantidadStock += cantidad;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Equipo?> BuscarPorIdAsync(int id)
        {
            return await _context.Equipos.FindAsync(id);
        }

    }
}
