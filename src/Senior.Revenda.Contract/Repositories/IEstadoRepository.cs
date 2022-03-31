using Senior.Revenda.Contract.DTOs;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Repositories
{
    public interface IEstadoRepository
    {
        List<EstadoDTO> GetAllAtivos();
    }
}
