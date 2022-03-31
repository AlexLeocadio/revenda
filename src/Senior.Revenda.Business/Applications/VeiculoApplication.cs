using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Business.Applications
{
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoApplication(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public VeiculoDTO Get(Guid id)
        {
            var result = _veiculoService.Get(id);
            return result;
        }

        public Guid Update(VeiculoDTO veiculoDTO)
        {
            var result = _veiculoService.Update(veiculoDTO);
            return result;
        }

        public Guid Create(VeiculoDTO veiculoDTO)
        {
            var result = _veiculoService.Create(veiculoDTO);
            return result;
        }

        public Guid Vendido(Guid id)
        {
            var result = _veiculoService.Vendido(id);
            return result;
        }

        public Guid Indisponivel(Guid id)
        {
            var result = _veiculoService.Indisponivel(id);
            return result;
        }

        public List<VeiculoDTO> GetAll(StatusVeiculoEnum status)
        {
            var result = _veiculoService.GetAll(status);
            return result;
        }
        public VeiculoFilterDTO GetByFilter(VeiculoFilterDTO filtro)
        {
            var result = _veiculoService.GetByFilter(filtro);
            return result;
        }
    }
}
