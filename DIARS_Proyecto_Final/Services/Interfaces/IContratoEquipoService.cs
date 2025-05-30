using DIARS_Proyecto_Final.Models;

namespace DIARS_Proyecto_Final.Services.Interfaces
{
    public interface IContratoEquipoService
    {
        Task AsignarContratoEquipoAsync(int contratoId, int equipoId, string estado);
        Task<List<ContratoEquipo>> ListarAsignacionesAsync();
    }
}