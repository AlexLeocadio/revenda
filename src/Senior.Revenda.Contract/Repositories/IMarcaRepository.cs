using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Repositories
{
    public interface IMarcaRepository
    {
        List<MarcaDTO> GetAll(bool status = true);
        List<MarcaDTO> GetByFilter(MarcaFilterDTO filtro);
        MarcaDTO Get(Guid id);
        MarcaDTO GetByNome(string nome);
        Guid Create(MarcaDTO marcaDTO);
        bool UpdateStatus(Guid id, bool status);
    }
}
