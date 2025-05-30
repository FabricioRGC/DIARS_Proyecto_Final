using DIARS_Proyecto_Final.Models;
using System.Diagnostics.Contracts;

namespace DIARS_Proyecto_Final.Repositories.Interfaces
{
    public interface IClienteService
    {
        Task<List<Contrato>> ObtenerContratosPorClienteAsync(int usuarioId);
        Task<List<Pago>> ObtenerPagosPendientesAsync(int clienteId);
        Task<bool> RegistrarPagoAsync(int pagoId, string metodoPago);
    }

}
