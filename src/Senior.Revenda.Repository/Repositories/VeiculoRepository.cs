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
    public class VeiculoRepository : IVeiculoRepository
    {
        public RevendaContext _context { get; }
        protected readonly IMapper _mapper;

        public VeiculoRepository(RevendaContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VeiculoDTO Get(Guid id)
        {
            var result = _context.Veiculo.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var returnResult = _mapper.Map<VeiculoDTO>(result);
            return returnResult;
        }

        public VeiculoDTO GetByRenavam(string renavam)
        {
            var result = _context.Veiculo.AsNoTracking().FirstOrDefault(x => x.Renavam == renavam);
            var returnResult = _mapper.Map<VeiculoDTO>(result);
            return returnResult;
        }

        public Guid Update(VeiculoDTO veiculoDTO)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

            var result = _context.Veiculo.Attach(veiculo);

            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return result.Id;
        }

        public Guid Create(VeiculoDTO veiculoDTO)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

            var result = _context.Veiculo.Add(veiculo);

            _context.SaveChanges();

            return result.Id;
        }

        public Guid UpdateStatus(Guid id, StatusVeiculoEnum status)
        {
            var result = _context.Veiculo.FirstOrDefault(e => e.Id == id);

            result.Status = (int)status;
            
            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return result.Id;
        }

        public List<VeiculoDTO> GetAll(StatusVeiculoEnum statusEnum)
        {
            var status = (int)statusEnum;

            var result = _context.Veiculo.Where(e => e.Status == status);
            var returnResult = _mapper.Map<List<VeiculoDTO>>(result);
            return returnResult;
        }

        public List<VeiculoDTO> GetByFilter(VeiculoFilterDTO filtro)
        {
            IQueryable<Veiculo> result = _context.Veiculo.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Renavam))
                result = result.Where(e => filtro.Renavam.Contains(e.Renavam));

            if (!string.IsNullOrEmpty(filtro.Modelo))
                result = result.Where(e => filtro.Modelo.Contains(e.Modelo));

            if (filtro.AnoFabricacao > 0)
                result = result.Where(e => e.AnoFabricacao == filtro.AnoFabricacao);

            if (filtro.Quilometragem > 0)
                result = result.Where(e => e.Quilometragem == filtro.Quilometragem);

            if (filtro.Quilometragem > 0)
                result = result.Where(e => e.Quilometragem == filtro.Quilometragem);

            if (filtro.IdProprietario != null)
                result = result.Where(e => e.IdProprietario == filtro.IdProprietario);

            if (filtro.IdMarca != null)
                result = result.Where(e => e.IdMarca == filtro.IdMarca);

            if (filtro.ValorMinimo >= 0 && filtro.ValorMaximo > 0)
                result = result.Where(e => e.Valor >= filtro.ValorMinimo && e.Valor <= filtro.ValorMaximo);

            if (filtro.Status != StatusVeiculoFilterEnum.Todos)
                result = result.Where(e => e.Status == (int)filtro.Status);

            var returnResult = _mapper.Map<List<VeiculoDTO>>(result);
            return returnResult;
        }
    }
}
