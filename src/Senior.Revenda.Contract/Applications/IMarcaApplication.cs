using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Applications
{
    public interface IMarcaApplication
    {
        List<MarcaDTO> GetAll(bool status = true);
        MarcaFilterDTO GetByFilter(MarcaFilterDTO filtro);
        List<MarcaDTO> GetAllAtivos();
        MarcaDTO Get(Guid id);
        Guid Create(MarcaDTO marcaDTO);
        bool Cancelar(Guid id);
        bool Ativar(Guid id);
    }
}
