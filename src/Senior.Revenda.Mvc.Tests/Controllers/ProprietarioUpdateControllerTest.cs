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
    public class ProprietarioUpdateControllerTest
    {
        private EnderecoDTO Endereco { get; set; }
        private ProprietarioDTO Proprietario { get; set; }
        
        private EnderecoDTO EnderecoUpdate { get; set; }
        private ProprietarioDTO ProprietarioUpdate { get; set; }

        public ProprietarioUpdateControllerTest()
        {
            Endereco = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            Proprietario = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = Endereco.Id, Status = StatusEnum.Ativo, Endereco = Endereco };

            EnderecoUpdate = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            ProprietarioUpdate = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = EnderecoUpdate.Id, Status = StatusEnum.Ativo, Endereco = EnderecoUpdate };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Já existe documento 00000000000 cadastro.")]
        public void DocumentoExistente()
        {
            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento)).Returns(Proprietario);

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeVazio()
        {
            ProprietarioUpdate.Nome = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeNulo()
        {
            ProprietarioUpdate.Nome = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o documento.")]
        public void DocumentoVazio()
        {
            ProprietarioUpdate.Documento = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o documento.")]
        public void DocumentoNulo()
        {
            ProprietarioUpdate.Documento = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o e-mail.")]
        public void EmailVazio()
        {
            ProprietarioUpdate.Email = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o e-mail.")]
        public void EmailNulo()
        {
            ProprietarioUpdate.Email = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioUpdate.Documento));
            enderecoService.Setup(x => x.UpdateOrCreate(ProprietarioUpdate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Update(ProprietarioUpdate);
        }
    }
}
