using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Services
{
    public interface IMarcaService
    {
        List<MarcaDTO> GetAll(bool status = true);
        MarcaFilterDTO GetByFilter(MarcaFilterDTO filtro);
        MarcaDTO Get(Guid id);
        Guid Create(MarcaDTO marcaDTO);
        bool Cancelar(Guid id);
        bool Ativar(Guid id);
    }
}
