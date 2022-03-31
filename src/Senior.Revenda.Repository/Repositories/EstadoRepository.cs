using AutoMapper;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Repository.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Senior.Revenda.Repository.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {

        public RevendaContext _context { get; }
        protected readonly IMapper _mapper;

        public EstadoRepository(RevendaContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EstadoDTO> GetAllAtivos()
        {
            var result = _context.Estado.Where(e => e.Status).ToList();
            var returnResult = _mapper.Map<List<EstadoDTO>>(result);
            return returnResult;
        }
    }
}
