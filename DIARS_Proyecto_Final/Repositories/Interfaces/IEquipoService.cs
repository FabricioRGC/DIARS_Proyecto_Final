using DIARS_Proyecto_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace DIARS_Proyecto_Final.Repositories.Interfaces
{
    // Interfaces/IEquipoService.cs
    public interface IEquipoService
    {
        Task<List<Equipo>> ListarAsync();
        Task<Equipo> BuscarPorIdAsync(int id);
        Task CrearAsync(Equipo equipo);
        Task AumentarStockAsync(int equipoId, int cantidad);
    }

}
