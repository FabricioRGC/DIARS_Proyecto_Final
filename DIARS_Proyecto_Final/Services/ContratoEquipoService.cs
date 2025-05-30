using DIARS_Proyecto_Final.Models;
using DIARS_Proyecto_Final.Repositories.Interfaces;
using DIARS_Proyecto_Final.Services.Interfaces;

namespace pruevas_diars_fabricio_0001.Services
{
    public class ContratoEquipoService : IContratoEquipoService
    {
        private readonly IContratoEquipoRepository _repo;

        public ContratoEquipoService(IContratoEquipoRepository repo)
        {
            _repo = repo;
        }

        public async Task AsignarContratoEquipoAsync(int contratoId, int equipoId, string estado)
        {
            var asignacion = new ContratoEquipo
            {
                ContratoId = contratoId,
                EquipoId = equipoId,
                FechaAsignacion = DateTime.Now,
                Estado = estado
            };
            await _repo.CrearAsync(asignacion);
        }

        public async Task<List<ContratoEquipo>> ListarAsignacionesAsync()
        {
            return await _repo.ListarAsync();
        }
    }
}