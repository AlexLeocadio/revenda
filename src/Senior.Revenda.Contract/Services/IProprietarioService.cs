using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Services
{
    public interface IProprietarioService
    {
        List<ProprietarioDTO> GetAll(bool status = true);
        ProprietarioFilterDTO GetByFilter(ProprietarioFilterDTO filtro);
        ProprietarioDTO Get(Guid id);
        Guid Update(ProprietarioDTO proprietarioDTO);
        Guid Create(ProprietarioDTO proprietarioDTO);
        bool Cancelar(Guid id);
        bool Ativar(Guid id);
    }
}
