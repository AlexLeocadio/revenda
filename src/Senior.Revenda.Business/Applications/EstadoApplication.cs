using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Services;
using System.Collections.Generic;

namespace Senior.Revenda.Business.Applications
{
    public class EstadoApplication : IEstadoApplication
    {
        private readonly IEstadoService _estadoService;

        public EstadoApplication(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }
        
        public List<EstadoDTO> GetAllAtivos()
        {
            var result = _estadoService.GetAllAtivos();
            return result;
        }
    }
}
