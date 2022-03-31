using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Business.Applications
{
    public class MarcaApplication : IMarcaApplication
    {
        private readonly IMarcaService _marcaService;

        public MarcaApplication(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        public MarcaDTO Get(Guid id)
        {
            var result = _marcaService.Get(id);
            return result;
        }

        public Guid Create(MarcaDTO marcaDTO)
        {
            var result = _marcaService.Create(marcaDTO);
            return result;
        }

        public bool Cancelar(Guid id)
        {
            var result = _marcaService.Cancelar(id);
            return result;
        }

        public bool Ativar(Guid id)
        {
            var result = _marcaService.Ativar(id);
            return result;
        }

        public List<MarcaDTO> GetAll(bool status = true)
        {
            var result = _marcaService.GetAll(status);
            return result;
        }

        public MarcaFilterDTO GetByFilter(MarcaFilterDTO filtro)
        {
            var result = _marcaService.GetByFilter(filtro);
            return result;
        }

        public List<MarcaDTO> GetAllAtivos()
        {
            var result = _marcaService.GetAll(true);
            return result;
        }
    }
}
