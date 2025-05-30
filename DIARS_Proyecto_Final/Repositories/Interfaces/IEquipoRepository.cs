using DIARS_Proyecto_Final.Models;

namespace DIARS_Proyecto_Final.Repositories.Interfaces
{
    // Interfaces/IEquipoRepository.cs
    public interface IEquipoRepository
    {
        Task<List<Equipo>> GetAllAsync();
        Task<Equipo> GetByIdAsync(int id);
        Task AddAsync(Equipo equipo);
        Task UpdateAsync(Equipo equipo);
        Task IncreaseStockAsync(int equipoId, int cantidad);
    }
}