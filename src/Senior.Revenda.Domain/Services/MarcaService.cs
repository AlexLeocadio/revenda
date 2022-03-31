using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public MarcaDTO Get(Guid id)
        {
            var result = ExisteMarca(id);
            return result;
        }

        public Guid Create(MarcaDTO marcaDTO)
        {
            marcaDTO.Status = StatusEnum.Ativo;

            ValidarNome(marcaDTO);
            ValidarMarcaDTO(marcaDTO);

            var result = _marcaRepository.Create(marcaDTO);
            return result;
        }

        public bool Ativar(Guid id)
        {
            ExisteMarca(id);
            var result = _marcaRepository.UpdateStatus(id, true);
            return result;
        }

        public bool Cancelar(Guid id)
        {
            ExisteMarca(id);
            var result = _marcaRepository.UpdateStatus(id, false);
            return result;
        }

        public List<MarcaDTO> GetAll(bool status = true)
        {
            var result = _marcaRepository.GetAll(status);
            return result;
        }

        public MarcaFilterDTO GetByFilter(MarcaFilterDTO filtro)
        {
            var result = _marcaRepository.GetByFilter(filtro);
            filtro.Lista = result;
            return filtro;
        }

        private MarcaDTO ExisteMarca(Guid id)
        {
            var entity = _marcaRepository.Get(id);

            if (entity == null)
                throw new Exception("Marca não encontrado.");

            return entity;
        }

        private void ValidarNome(MarcaDTO marcaDTO)
        {
            var result = _marcaRepository.GetByNome(marcaDTO?.Nome);

            if (result != null && result.Id != marcaDTO?.Id)
                throw new Exception($"Já existe nome {marcaDTO?.Nome} cadastro.");
        }

        private void ValidarMarcaDTO(MarcaDTO marcaDTO)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(marcaDTO.Nome))
                msg += "Por favor, informe o nome.";

            if (!string.IsNullOrEmpty(msg))
                throw new Exception(msg);
        }
    }
}
