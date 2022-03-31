using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.DTOs.Filter;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using System;
using System.Collections.Generic;

namespace Senior.Revenda.Domain.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IEnderecoService _enderecoService;

        public ProprietarioService(IProprietarioRepository proprietarioRepository
            , IEnderecoService enderecoService)
        {
            _proprietarioRepository = proprietarioRepository;
            _enderecoService = enderecoService;
        }

        public ProprietarioDTO Get(Guid id)
        {
            var result = ExisteProprietario(id);
            if (result != null)
                result.Endereco = _enderecoService.Get(result.IdEndereco);
            return result;
        }

        public Guid Update(ProprietarioDTO proprietarioDTO)
        {
            ValidarDocumento(proprietarioDTO);
            var proprietario = ExisteProprietario(proprietarioDTO.Id);
            UpdateOrCreateEndereco(proprietarioDTO, proprietario);
            ValidarProprietarioDTO(proprietarioDTO);

            var result = _proprietarioRepository.Update(proprietarioDTO);
            return result;
        }

        public Guid Create(ProprietarioDTO proprietarioDTO)
        {
            proprietarioDTO.Status = StatusEnum.Ativo;

            ValidarDocumento(proprietarioDTO);
            CreateEndereco(proprietarioDTO);
            ValidarProprietarioDTO(proprietarioDTO);

            var result = _proprietarioRepository.Create(proprietarioDTO);
            return result;
        }

        public bool Ativar(Guid id)
        {
            ExisteProprietario(id);
            var result = _proprietarioRepository.UpdateStatus(id, true);
            return result;
        }

        public bool Cancelar(Guid id)
        {
            ExisteProprietario(id);
            var result = _proprietarioRepository.UpdateStatus(id, false);
            return result;
        }

        public List<ProprietarioDTO> GetAll(bool status = true)
        {
            var result = _proprietarioRepository.GetAll(status);
            return result;
        }

        public ProprietarioFilterDTO GetByFilter(ProprietarioFilterDTO filtro)
        {
            var result = _proprietarioRepository.GetByFilter(filtro);
            filtro.Lista = result;
            return filtro;
        }

        private void CreateEndereco(ProprietarioDTO proprietarioDTO)
        {
            proprietarioDTO.IdEndereco = Guid.NewGuid();
            proprietarioDTO.Endereco.Id = proprietarioDTO.IdEndereco;
            _enderecoService.Create(proprietarioDTO.Endereco, true);
        }

        private void UpdateOrCreateEndereco(ProprietarioDTO proprietarioDTO, ProprietarioDTO proprietario)
        {
            proprietarioDTO.IdEndereco = proprietario.IdEndereco;
            proprietarioDTO.Endereco.Id = proprietario.IdEndereco; 

            _enderecoService.UpdateOrCreate(proprietarioDTO.Endereco, true);
        }

        private void ValidarDocumento(ProprietarioDTO proprietarioDTO)
        {
            if (string.IsNullOrEmpty(proprietarioDTO?.Documento)) return;

            var result = _proprietarioRepository.GetByDocumento(proprietarioDTO?.Documento);

            if (result != null && result.Id != proprietarioDTO?.Id)
                throw new Exception($"Já existe documento {proprietarioDTO?.Documento} cadastro.");
        }

        private void ValidarProprietarioDTO(ProprietarioDTO proprietarioDTO)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(proprietarioDTO.Nome))
                msg += "Por favor, informe o nome." + Environment.NewLine;

            if (string.IsNullOrEmpty(proprietarioDTO.Documento))
                msg += "Por favor, informe o documento." + Environment.NewLine;

            if (string.IsNullOrEmpty(proprietarioDTO.Email))
                msg += "Por favor, informe o e-mail." + Environment.NewLine;

            if (proprietarioDTO.IdEndereco == Guid.Empty || proprietarioDTO.Endereco == null)
                msg += "Por favor, endereco não cadastrado." + Environment.NewLine;

            if (!string.IsNullOrEmpty(msg))
                throw new Exception(msg);
        }

        private ProprietarioDTO ExisteProprietario(Guid id)
        {
            var entity = _proprietarioRepository.Get(id);

            if (entity == null)
                throw new Exception("Proprietario não encontrado.");

            return entity;
        }
    }
}
