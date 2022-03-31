using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Applications
{
    public interface IProprietarioApplication
    {
        List<ProprietarioDTO> GetAll(bool status = true);
        ProprietarioFilterDTO GetByFilter(ProprietarioFilterDTO filtro);
        List<ProprietarioDTO> GetAllAtivos();
        ProprietarioDTO Get(Guid id);
        Guid Update(ProprietarioDTO proprietarioDTO);
        Guid Create(ProprietarioDTO proprietarioDTO);
        bool Cancelar(Guid id);
        bool Ativar(Guid id);
    }
}
