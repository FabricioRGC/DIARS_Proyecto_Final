using DIARS_Proyecto_Final.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DIARS_Proyecto_Final.Data;
using DIARS_Proyecto_Final.Models;

namespace pruevas_diars_fabricio_0001.Repositories
{
    // Repositories/EquipoRepository.cs
    public class EquipoRepository : IEquipoRepository
    {
        private readonly AppDbContext _context;
        public EquipoRepository(AppDbContext context) => _context = context;

        public async Task<List<Equipo>> GetAllAsync() => await _context.Equipos.ToListAsync();

        public async Task<Equipo> GetByIdAsync(int id) => await _context.Equipos.FindAsync(id);

        public async Task AddAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipo equipo)
        {
            _context.Equipos.Update(equipo);
            await _context.SaveChangesAsync();
        }

        public async Task IncreaseStockAsync(int equipoId, int cantidad)
        {
            var equipo = await _context.Equipos.FindAsync(equipoId);
            if (equipo != null)
            {
                equipo.CantidadStock += cantidad;
                await _context.SaveChangesAsync();
            }
        }
    }

}
