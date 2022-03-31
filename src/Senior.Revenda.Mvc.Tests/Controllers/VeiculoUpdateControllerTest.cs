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
    public class VeiculoUpdateControllerTest
    {
        private MarcaDTO Marca { get; set; }
        private EnderecoDTO Endereco { get; set; }
        private ProprietarioDTO Proprietario { get; set; }

        private VeiculoDTO Veiculo { get; set; }

        private VeiculoDTO VeiculoUpdate { get; set; }

        public VeiculoUpdateControllerTest()
        {
            Marca = new MarcaDTO { Id = Guid.NewGuid(), Nome = "BMW", Status = StatusEnum.Ativo };
            Endereco = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            Proprietario = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = Endereco.Id, Status = StatusEnum.Ativo, Endereco = Endereco };

            Veiculo = new VeiculoDTO { Id = Guid.NewGuid(), IdProprietario = Guid.NewGuid(), Renavam = "123546", IdMarca = Guid.NewGuid(), Modelo = "Modelo", AnoFabricacao = 2022, AnoModelo = 2022, Quilometragem = 100, Valor = 1000.50M, Status = StatusVeiculoEnum.Disponivel, Marca = Marca, Proprietario = Proprietario };

            VeiculoUpdate = new VeiculoDTO { Id = Guid.NewGuid(), IdProprietario = Guid.NewGuid(), Renavam = "123546", IdMarca = Guid.NewGuid(), Modelo = "Modelo", AnoFabricacao = 2022, AnoModelo = 2022, Quilometragem = 100, Valor = 1000.50M, Status = StatusVeiculoEnum.Disponivel, Marca = Marca, Proprietario = Proprietario };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Já existe renavam 123546 cadastro.")]
        public void RenavamExistente()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione o proprietário.")]
        public void ProprietarioVazio()
        {
            VeiculoUpdate.IdProprietario = Guid.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o renavam.")]
        public void RenavamVazio()
        {
            VeiculoUpdate.Renavam = String.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o renavam.")]
        public void RenavamNulo()
        {
            VeiculoUpdate.Renavam = null;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, selecione a marca.")]
        public void MarcaVazio()
        {
            VeiculoUpdate.IdMarca = Guid.Empty;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano de fabricação.")]
        public void AnoFabricacaoIgualZero()
        {
            VeiculoUpdate.AnoFabricacao = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano de fabricação.")]
        public void AnoFabricacaoMenorQueZero()
        {
            VeiculoUpdate.AnoFabricacao = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano do modelo.")]
        public void AnoModeloIgualZero()
        {
            VeiculoUpdate.AnoModelo = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe ano do modelo.")]
        public void AnoModeloMenorQueZero()
        {
            VeiculoUpdate.AnoModelo = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a quilometragem.")]
        public void QuilometragemIgualZero()
        {
            VeiculoUpdate.Quilometragem = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a quilometragem.")]
        public void QuilometragemMenorQueZero()
        {
            VeiculoUpdate.Quilometragem = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o valor do veiculo.")]
        public void ValorIgualZero()
        {
            VeiculoUpdate.Valor = 0;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o valor do veiculo.")]
        public void ValorMenorQueZero()
        {
            VeiculoUpdate.Valor = -10;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe a situação do veiculo.")]
        public void StatusNulo()
        {
            VeiculoUpdate.Status = null;

            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            veiculoRepository.Setup(x => x.GetByRenavam(VeiculoUpdate.Renavam)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Veiculo não pode ficar disponivel.")]
        public void VeiculoVendidoNaoVoltaDisponivel()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            Veiculo.Status = StatusVeiculoEnum.Vendido;

            veiculoRepository.Setup(x => x.Get(Veiculo.Id)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            VeiculoUpdate.Id = Veiculo.Id;

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Veiculo não pode ficar disponivel.")]
        public void VeiculoIndisponivelNaoVoltaDisponivel()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            Veiculo.Status = StatusVeiculoEnum.Indisponivel;

            veiculoRepository.Setup(x => x.Get(Veiculo.Id)).Returns(Veiculo);

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            VeiculoUpdate.Id = Veiculo.Id;

            veiculoService.Update(VeiculoUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Veiculo não encontrado.")]
        public void ProprietarioNaoEncontrado()
        {
            var veiculoRepository = new Mock<IVeiculoRepository>();
            var messageBus = new Mock<IMessageBus>();

            var veiculoService = new VeiculoService(veiculoRepository.Object, messageBus.Object);

            veiculoService.Get(Guid.Empty);
        }
    }
}
