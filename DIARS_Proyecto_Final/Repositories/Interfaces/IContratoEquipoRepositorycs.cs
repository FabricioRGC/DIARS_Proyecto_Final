using System.Collections.Generic;
using System.Threading.Tasks;
using DIARS_Proyecto_Final.Models;

namespace DIARS_Proyecto_Final.Repositories.Interfaces
{
    public interface IContratoEquipoRepository
    {
        Task<List<ContratoEquipo>> ListarAsync();
        Task<ContratoEquipo> BuscarPorIdAsync(int id);
        Task CrearAsync(ContratoEquipo contratoEquipo);
        Task EliminarAsync(int id);
    }
}