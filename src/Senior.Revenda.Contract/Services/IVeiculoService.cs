using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Services
{
    public interface IVeiculoService
    {
        List<VeiculoDTO> GetAll(StatusVeiculoEnum status);
        VeiculoFilterDTO GetByFilter(VeiculoFilterDTO filtro);
        VeiculoDTO Get(Guid id);
        Guid Update(VeiculoDTO veiculoDTO);
        Guid Create(VeiculoDTO veiculoDTO);
        Guid Vendido(Guid id);
        Guid Indisponivel(Guid id);
    }
}
