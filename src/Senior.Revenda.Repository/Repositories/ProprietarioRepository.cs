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
    public class ProprietarioRepository : IProprietarioRepository
    {
        public RevendaContext _context { get; }
        protected readonly IMapper _mapper;

        public ProprietarioRepository(RevendaContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProprietarioDTO Get(Guid id)
        {
            var result = _context.Proprietario.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var returnResult = _mapper.Map<ProprietarioDTO>(result);
            return returnResult;
        }

        public ProprietarioDTO GetByDocumento(string documento)
        {
            var result = _context.Proprietario.AsNoTracking().FirstOrDefault(x => x.Documento == documento);
            var returnResult = _mapper.Map<ProprietarioDTO>(result);
            return returnResult;
        }

        public Guid Update(ProprietarioDTO proprietarioDTO, bool transaction = false)
        {
            _context.IgnoreSaveChangeAndUseTransaction = transaction;

            var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

            var result = _context.Proprietario.Attach(proprietario);
            
            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return result.Id;
        }

        public Guid Create(ProprietarioDTO proprietarioDTO, bool transaction = false)
        {
            _context.IgnoreSaveChangeAndUseTransaction = transaction;

            var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

            var result = _context.Proprietario.Add(proprietario);

            _context.SaveChanges();

            return result.Id;
        }

        public bool UpdateStatus(Guid id, bool status)
        {
            var result = _context.Proprietario.FirstOrDefault(e => e.Id == id);

            result.Status = status;

            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return true;
        }

        public List<ProprietarioDTO> GetAll(bool status = true)
        {
            IQueryable<Proprietario> result = _context.Proprietario.Where(x => x.Status == status);
            var returnResult = _mapper.Map<List<ProprietarioDTO>>(result);
            return returnResult;
        }

        public List<ProprietarioDTO> GetByFilter(ProprietarioFilterDTO filtro)
        {
            IQueryable<Proprietario> result = _context.Proprietario.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome))
                result = result.Where(e => filtro.Nome.Contains(e.Nome));

            if (!string.IsNullOrEmpty(filtro.Documento))
                result = result.Where(e => e.Documento == filtro.Documento);

            switch (filtro.Status)
            {
                case StatusFilterEnum.Ativo:
                    result = result.Where(e => e.Status);
                    break;
                case StatusFilterEnum.Cancelado:
                    result = result.Where(e => !e.Status);
                    break;
            }

            var returnResult = _mapper.Map<List<ProprietarioDTO>>(result);
            return returnResult;
        }
    }
}
