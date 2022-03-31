using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.Repositories
{
    public interface IVeiculoRepository
    {
        List<VeiculoDTO> GetAll(StatusVeiculoEnum statusEnum);
        List<VeiculoDTO> GetByFilter(VeiculoFilterDTO filter);
        VeiculoDTO Get(Guid id);
        VeiculoDTO GetByRenavam(string renavam);
        Guid Update(VeiculoDTO veiculoDTO);
        Guid Create(VeiculoDTO veiculoDTO);
        Guid UpdateStatus(Guid id, StatusVeiculoEnum status);
    }
}
