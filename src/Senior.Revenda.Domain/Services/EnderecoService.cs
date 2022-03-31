using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using Senior.Revenda.Infrastructure.Extensions;
using System;
using System.Net.Http;

namespace Senior.Revenda.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public EnderecoDTO Get(Guid id)
        {
            var result = _enderecoRepository.Get(id);
            return result;
        }

        public Guid Create(EnderecoDTO enderecoDTO, bool transaction = false)
        {
            ValidarEnderecoDTO(enderecoDTO);

            var result = _enderecoRepository.Create(enderecoDTO, transaction);
            return result;
        }

        public Guid UpdateOrCreate(EnderecoDTO enderecoDTO, bool transaction = false)
        {
            ValidarEnderecoDTO(enderecoDTO);

            var entity = Get(enderecoDTO.Id);

            if (entity != null)
            {
                var result = _enderecoRepository.Update(enderecoDTO, transaction);
                return result;
            }

            return Create(enderecoDTO, transaction);
        }

        public CepDTO GetByCep(string cep)
        {
            var cepInt = cep.RemoverFormatacaoCep();

            CepDTO result = null;

            HttpClient cliente = new HttpClient();

            var response = cliente.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cepInt}").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<CepDTO>().Result;
            }

            return result;
        }

        private void ValidarEnderecoDTO(EnderecoDTO enderecoDTO)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(enderecoDTO.Logradouro))
                msg += "Por favor, informe o logradouro." + Environment.NewLine;

            if (string.IsNullOrEmpty(enderecoDTO.Bairro))
                msg += "Por favor, informe o bairro." + Environment.NewLine;

            if (string.IsNullOrEmpty(enderecoDTO.Cidade))
                msg += "Por favor, informe o cidade." + Environment.NewLine;

            if (enderecoDTO.IdEstado == Guid.Empty)
                msg += "Por favor, selecione o estado." + Environment.NewLine;

            if (string.IsNullOrEmpty(enderecoDTO.Numero))
                msg += "Por favor, informe o número." + Environment.NewLine;

            if (string.IsNullOrEmpty(enderecoDTO.Cep))
                msg += "Por favor, informe o cep." + Environment.NewLine;

            if (!string.IsNullOrEmpty(msg))
                throw new Exception(msg);
        }
    }
}
