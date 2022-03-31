using Senior.Revenda.Contract.DTOs;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Applications
{
    public interface IEstadoApplication
    {
        List<EstadoDTO> GetAllAtivos();
    }
}
