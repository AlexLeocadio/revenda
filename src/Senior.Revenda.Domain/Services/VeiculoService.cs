using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Producer;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senior.Revenda.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMessageBus _messageBus;

        public VeiculoService(IVeiculoRepository veiculoRepository
            , IMessageBus messageBus)
        {
            _veiculoRepository = veiculoRepository;
            _messageBus = messageBus;
        }

        public VeiculoDTO Get(Guid id)
        {
            var result = ExisteVeiculo(id);
            _messageBus.SendAsync(result, "veiculoQueue");
            return result;
        }

        public Guid Update(VeiculoDTO veiculoDTO)
        {
            VeiculoDTO entity = ExisteVeiculo(veiculoDTO.Id);
            ValidarStatus(veiculoDTO, entity);
            ValidarRenavam(veiculoDTO);
            ValidarVeiculoDTO(veiculoDTO);
            var result = _veiculoRepository.Update(veiculoDTO);
            return result;
        }

        public Guid Create(VeiculoDTO veiculoDTO)
        {
            veiculoDTO.Status = StatusVeiculoEnum.Disponivel;

            ValidarRenavam(veiculoDTO);
            ValidarVeiculoDTO(veiculoDTO);
            var result = _veiculoRepository.Create(veiculoDTO);

            _messageBus.SendAsync(veiculoDTO, "veiculoQueue");

            return result;
        }

        public Guid Vendido(Guid id)
        {
            var result = _veiculoRepository.UpdateStatus(id, StatusVeiculoEnum.Vendido);
            return result;
        }

        public Guid Indisponivel(Guid id)
        {
            var result = _veiculoRepository.UpdateStatus(id, StatusVeiculoEnum.Indisponivel);
            return result;
        }

        public List<VeiculoDTO> GetAll(StatusVeiculoEnum status)
        {
            var result = _veiculoRepository.GetAll(status);
            return result;
        }

        public VeiculoFilterDTO GetByFilter(VeiculoFilterDTO filtro)
        {
            if (filtro.ValorMinimo > filtro.ValorMaximo)
                throw new Exception("O valor máximo não pode ser menor que o valor minimo.");
            if (filtro.ValorMinimo < 0)
                throw new Exception("O valor minimo não pode ser negativo.");
            if (filtro.ValorMaximo < 0)
                throw new Exception("O valor máximo não pode ser negativo.");

            var result = _veiculoRepository.GetByFilter(filtro);
            filtro.Lista = result;
            return filtro;
        }

        private void ValidarRenavam(VeiculoDTO veiculoDTO)
        {
            var result = _veiculoRepository.GetByRenavam(veiculoDTO?.Renavam);

            if (result != null && result.Id != veiculoDTO?.Id)
                throw new Exception($"Já existe renavam {veiculoDTO?.Renavam} cadastro.");
        }

        private void ValidarVeiculoDTO(VeiculoDTO veiculoDTO)
        {
            string msg = string.Empty;

            if (veiculoDTO.IdProprietario == Guid.Empty)
                msg += "Por favor, selecione o proprietário." + Environment.NewLine;
            if (string.IsNullOrEmpty(veiculoDTO.Renavam))
                msg += "Por favor, informe o renavam." + Environment.NewLine;
            if (veiculoDTO.IdMarca == Guid.Empty)
                msg += "Por favor, selecione a marca." + Environment.NewLine;
            if (string.IsNullOrEmpty(veiculoDTO.Modelo))
                msg += "Por favor, informe o modelo." + Environment.NewLine;
            if (veiculoDTO.AnoFabricacao <= 0)
                msg += "Por favor, informe ano de fabricação." + Environment.NewLine;
            if (veiculoDTO.AnoModelo <= 0)
                msg += "Por favor, informe ano do modelo." + Environment.NewLine;
            if (veiculoDTO.Quilometragem <= 0)
                msg += "Por favor, informe a quilometragem." + Environment.NewLine;
            if (veiculoDTO.Valor <= 0)
                msg += "Por favor, informe o valor do veiculo." + Environment.NewLine;
            if (!veiculoDTO.Status.HasValue)
                msg += "Por favor, informe a situação do veiculo." + Environment.NewLine;

            if (!string.IsNullOrEmpty(msg))
                throw new Exception(msg);
        }

        private VeiculoDTO ExisteVeiculo(Guid id)
        {
            var entity = _veiculoRepository.Get(id);

            if (entity == null)
                throw new Exception("Veiculo não encontrado.");

            return entity;
        }

        private void ValidarStatus(VeiculoDTO veiculoDTO, VeiculoDTO entity)
        {
            if (!veiculoDTO.Status.HasValue)
                veiculoDTO.Status = entity.Status;

            var statusPermitidos = new int[] { (int)StatusVeiculoEnum.Vendido, (int)StatusVeiculoEnum.Indisponivel };

            if (statusPermitidos.Contains((int)entity.Status) && veiculoDTO.Status == StatusVeiculoEnum.Disponivel)
                throw new Exception("Veiculo não pode ficar disponivel.");
        }
    }
}
