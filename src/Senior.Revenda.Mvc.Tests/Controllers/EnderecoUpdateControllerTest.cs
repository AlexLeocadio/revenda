using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Domain.Services;
using System;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class EnderecoUpdateControllerTest
    {
        private EnderecoDTO EnderecoUpdate { get; set; }

        public EnderecoUpdateControllerTest()
        {
            EnderecoUpdate = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o logradouro.")]
        public void LogradouroVazio()
        {
            EnderecoUpdate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o logradouro.")]
        public void LogradouroNulo()
        {
            EnderecoUpdate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o bairro.")]
        public void BairroVazio()
        {
            EnderecoUpdate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o bairro.")]
        public void BairroNulo()
        {
            EnderecoUpdate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cidade.")]
        public void CidadeVazio()
        {
            EnderecoUpdate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cidade.")]
        public void CidadeNulo()
        {
            EnderecoUpdate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o número.")]
        public void NumeroVazio()
        {
            EnderecoUpdate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o número.")]
        public void NumeroNulo()
        {
            EnderecoUpdate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cep.")]
        public void CepVazio()
        {
            EnderecoUpdate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cep.")]
        public void CepNulo()
        {
            EnderecoUpdate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione o estado.")]
        public void SelecionarEstado()
        {
            EnderecoUpdate.IdEstado = Guid.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.UpdateOrCreate(EnderecoUpdate);
        }
    }
}
