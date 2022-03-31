using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Contract.Producer;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Domain.Services;
using System;

namespace Senior.Revenda.Mvc.Tests.Controllers
{
    [TestClass]
    public class VeiculoCreateControllerTest
    {
        private MarcaDTO Marca { get; set; }
        private EnderecoDTO Endereco { get; set; }
        private ProprietarioDTO Proprietario { get; set; }

        private VeiculoDTO Veiculo { get; set; }

        private VeiculoDTO VeiculoCreate { get; set; }

        public VeiculoCreateControllerTest()
        {
            Marca = new MarcaDTO { Id = Guid.NewGuid(), Nome = "BMW", Status = StatusEnum.Ativo };
            Endereco = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            Proprietario = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = Endereco.Id, Status = StatusEnum.Ativo, Endereco = Endereco };

            Veiculo = new VeiculoDTO { Id = Guid.NewGuid(), IdProprietario = Guid.NewGuid(), Renavam = "123546", IdMarca = Guid.NewGuid(), Modelo = "Modelo", AnoFabricacao = 2022, AnoModelo = 2022, Quilometragem = 100, Valor = 1000.50M, Status = StatusVeiculoEnum.Disponivel, Marca = Marca, Proprietario = Proprietario };

            VeiculoCreate = new VeiculoDTO { Id = Guid.NewGuid(), IdProprietario = Guid.NewGuid(), Renavam = "123546", IdMarca = Guid.NewGuid(), Modelo = "Modelo", AnoFabricacao = 2022, AnoModelo = 2022, Quilometragem = 100, Valor = 1000.50M, Status = StatusVeiculoEnum.Disponivel, Marca = Marca, Proprietario = Proprietario };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Já existe renavam 123546 cadastro.")]
        public void RenavamExistente()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione o proprietário.")]
        public void ProprietarioVazio()
        {
            VeiculoCreate.IdProprietario = Guid.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o renavam.")]
        public void RenavamVazio()
        {
            VeiculoCreate.Renavam = String.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o renavam.")]
        public void RenavamNulo()
        {
            VeiculoCreate.Renavam = null;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione a marca.")]
        public void MarcaVazio()
        {
            VeiculoCreate.IdMarca = Guid.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano de fabricação.")]
        public void AnoFabricacaoIgualZero()
        {
            VeiculoCreate.AnoFabricacao = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano de fabricação.")]
        public void AnoFabricacaoMenorQueZero()
        {
            VeiculoCreate.AnoFabricacao = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano do modelo.")]
        public void AnoModeloIgualZero()
        {
            VeiculoCreate.AnoModelo = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano do modelo.")]
        public void AnoModeloMenorQueZero()
        {
            VeiculoCreate.AnoModelo = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a quilometragem.")]
        public void QuilometragemIgualZero()
        {
            VeiculoCreate.Quilometragem = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a quilometragem.")]
        public void QuilometragemMenorQueZero()
        {
            VeiculoCreate.Quilometragem = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o valor do veiculo.")]
        public void ValorIgualZero()
        {
            VeiculoCreate.Valor = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o valor do veiculo.")]
        public void ValorMenorQueZero()
        {
            VeiculoCreate.Valor = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a situação do veiculo.")]
        public void StatusNulo()
        {
            VeiculoCreate.Status = null;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoCreate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Create(VeiculoCreate);
        }
    }
}
