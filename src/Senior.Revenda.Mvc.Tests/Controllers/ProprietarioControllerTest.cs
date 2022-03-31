using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using Senior.Revenda.Domain.Services;
using System;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class ProprietarioControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Proprietario não encontrado.")]
        public void ProprietarioNaoEncontrado()
        {
            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Get(Guid.Empty);
        }
    }
}
