using AutoMapper;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Repository.Contexts;
using Senior.Revenda.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Senior.Revenda.Repository.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        public RevendaContext _context { get; }
        protected readonly IMapper _mapper;

        public MarcaRepository(RevendaContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MarcaDTO Get(Guid id)
        {
            var result = _context.Marca.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var returnResult = _mapper.Map<MarcaDTO>(result);
            return returnResult;
        }

        public MarcaDTO GetByNome(string nome)
        {
            var result = _context.Marca.AsNoTracking().FirstOrDefault(x => x.Nome == nome);
            var returnResult = _mapper.Map<MarcaDTO>(result);
            return returnResult;
        }

        public Guid Create(MarcaDTO marcaDTO)
        {
            var marca = _mapper.Map<Marca>(marcaDTO);

            var result = _context.Marca.Add(marca);

            _context.SaveChanges();

            return result.Id;
        }

        public bool UpdateStatus(Guid id, bool status)
        {
            var result = _context.Marca.FirstOrDefault(e => e.Id == id);

            result.Status = status;

            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return true;
        }

        public List<MarcaDTO> GetAll(bool status = true)
        {
            IQueryable<Marca> result = _context.Marca.Where(x => x.Status == status);
            var returnResult = _mapper.Map<List<MarcaDTO>>(result);
            return returnResult;
        }

        public List<MarcaDTO> GetByFilter(MarcaFilterDTO filtro)
        {
            IQueryable<Marca> result = _context.Marca.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
                result = result.Where(e => filtro.Nome.Contains(e.Nome));

            switch (filtro.Status)
            {
                case StatusFilterEnum.Ativo:
                    result = result.Where(e => e.Status);
                    break;
                case StatusFilterEnum.Cancelado:
                    result = result.Where(e => !e.Status);
                    break;
            }

            var returnResult = _mapper.Map<List<MarcaDTO>>(result);
            return returnResult;
        }
    }
}
