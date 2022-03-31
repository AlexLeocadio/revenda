using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Business.Applications
{
    public class ProprietarioApplication : IProprietarioApplication
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioApplication(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        public ProprietarioDTO Get(Guid id)
        {
            var result = _proprietarioService.Get(id);
            return result;
        }

        public Guid Update(ProprietarioDTO proprietarioDTO)
        {
            var result = _proprietarioService.Update(proprietarioDTO);
            return result;
        }

        public Guid Create(ProprietarioDTO proprietarioDTO)
        {
            var result = _proprietarioService.Create(proprietarioDTO);
            return result;
        }

        public bool Cancelar(Guid id)
        {
            var result = _proprietarioService.Cancelar(id);
            return result;
        }

        public List<ProprietarioDTO> GetAll(bool status = true)
        {
            var result = _proprietarioService.GetAll(status);
            return result;
        }

        public ProprietarioFilterDTO GetByFilter(ProprietarioFilterDTO filtro)
        {
            var result = _proprietarioService.GetByFilter(filtro);
            return result;
        }

        public bool Ativar(Guid id)
        {
            var result = _proprietarioService.Ativar(id);
            return result;
        }

        public List<ProprietarioDTO> GetAllAtivos()
        {
            var result = _proprietarioService.GetAll(true);
            return result;
        }
    }
}
