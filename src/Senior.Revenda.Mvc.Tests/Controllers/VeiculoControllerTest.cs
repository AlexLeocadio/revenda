using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.Producer;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Domain.Services;
using System;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class VeiculoControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Veiculo não encontrado.")]
        public void VeiculoNaoEncontrado()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Get(Guid.Empty);
        }
    }
}
