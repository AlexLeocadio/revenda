using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Domain.Services;
using System;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class EnderecoCreateControllerTest
    {
        private EnderecoDTO EnderecoCreate { get; set; }

        public EnderecoCreateControllerTest()
        {
            EnderecoCreate = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o logradouro.")]
        public void LogradouroVazio()
        {
            EnderecoCreate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o logradouro.")]
        public void LogradouroNulo()
        {
            EnderecoCreate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o bairro.")]
        public void BairroVazio()
        {
            EnderecoCreate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o bairro.")]
        public void BairroNulo()
        {
            EnderecoCreate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cidade.")]
        public void CidadeVazio()
        {
            EnderecoCreate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cidade.")]
        public void CidadeNulo()
        {
            EnderecoCreate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o número.")]
        public void NumeroVazio()
        {
            EnderecoCreate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o número.")]
        public void NumeroNulo()
        {
            EnderecoCreate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cep.")]
        public void CepVazio()
        {
            EnderecoCreate.Logradouro = string.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o cep.")]
        public void CepNulo()
        {
            EnderecoCreate.Logradouro = null;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione o estado.")]
        public void SelecionarEstado()
        {
            EnderecoCreate.IdEstado = Guid.Empty;

            var enderecoRepository = new Mock<IEnderecoRepository>();

            var enderecoService = new EnderecoService(enderecoRepository.Object);

            enderecoService.Create(EnderecoCreate);
        }
    }
}
