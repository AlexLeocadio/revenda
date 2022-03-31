using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Domain.Services;
using Senior.Revenda.Mvc.Controllers;
using System;
using System.Web.Mvc;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class MarcaControllerTest
    {
        private MarcaDTO Marca { get; set; }
        private MarcaDTO MarcaCreate { get; set; }

        public MarcaControllerTest()
        {
            Marca = new MarcaDTO { Id = Guid.NewGuid(), Nome = "BMW", Status = StatusEnum.Ativo };
            MarcaCreate = new MarcaDTO { Id = Guid.NewGuid(), Nome = "BMW", Status = StatusEnum.Ativo };
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var marcaApplication = Mock.Of<IMarcaApplication>();
            var controller = new MarcaController(marcaApplication);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Já existe nome BMW cadastro.")]
        public void NomeExistente()
        {
            var marcaRepository = new Mock<IMarcaRepository>();
            marcaRepository.Setup(x => x.GetByNome(MarcaCreate.Nome)).Returns(Marca);

            var marcaService = new MarcaService(marcaRepository.Object);

            marcaService.Create(MarcaCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeVazio()
        {
            Marca.Nome = string.Empty;

            var marcaRepository = new Mock<IMarcaRepository>();
            marcaRepository.Setup(x => x.GetByNome(Marca.Nome));

            var marcaService = new MarcaService(marcaRepository.Object);

            marcaService.Create(Marca);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeNulo()
        {
            Marca.Nome = null;

            var marcaRepository = new Mock<IMarcaRepository>();
            marcaRepository.Setup(x => x.GetByNome(Marca.Nome));

            var marcaService = new MarcaService(marcaRepository.Object);

            marcaService.Create(Marca);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Marca não encontrado.")]
        public void MarcaNaoEncontrado()
        {
            var marcaRepository = new Mock<IMarcaRepository>();

            var marcaService = new MarcaService(marcaRepository.Object);

            marcaService.Get(Guid.Empty);
        }
    }
}
