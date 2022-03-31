using Senior.Revenda.Contract.DTOs;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Services
{
    public interface IEstadoService
    {
        List<EstadoDTO> GetAllAtivos();
    }
}
