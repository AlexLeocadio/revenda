using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using System.Collections.Generic;

namespace Senior.Revenda.Domain.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
        
        public List<EstadoDTO> GetAllAtivos()
        {
            var result = _estadoRepository.GetAllAtivos();
            return result;
        }
    }
}
