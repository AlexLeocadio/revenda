using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Repositories
{
    public interface IProprietarioRepository
    {
        List<ProprietarioDTO> GetAll(bool status = true);
        List<ProprietarioDTO> GetByFilter(ProprietarioFilterDTO filtro);
        ProprietarioDTO Get(Guid id);
        ProprietarioDTO GetByDocumento(string documento);
        Guid Update(ProprietarioDTO proprietarioDTO, bool transaction = false);
        Guid Create(ProprietarioDTO proprietarioDTO, bool transaction = false);
        bool UpdateStatus(Guid id, bool status);
    }
}
