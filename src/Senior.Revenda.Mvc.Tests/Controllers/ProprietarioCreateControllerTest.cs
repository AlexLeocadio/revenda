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
    public class ProprietarioCreateControllerTest
    {
        private EnderecoDTO Endereco { get; set; }
        private ProprietarioDTO Proprietario { get; set; }
        
        private EnderecoDTO EnderecoCreate { get; set; }
        private ProprietarioDTO ProprietarioCreate { get; set; }

        public ProprietarioCreateControllerTest()
        {
            Endereco = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            Proprietario = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = Endereco.Id, Status = StatusEnum.Ativo, Endereco = Endereco };

            EnderecoCreate = new EnderecoDTO { Id = Guid.NewGuid(), Logradouro = "Rua A", Numero = "255", Cidade = "Cuiabá", Bairro = "Centro", Cep = "78000000", IdEstado = Guid.NewGuid() };
            ProprietarioCreate = new ProprietarioDTO { Id = Guid.NewGuid(), Nome = "João Maria", Documento = "00000000000", Email = "teste@teste.com", IdEndereco = EnderecoCreate.Id, Status = StatusEnum.Ativo, Endereco = EnderecoCreate };
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Já existe documento 00000000000 cadastro.")]
        public void DocumentoExistente()
        {
            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento)).Returns(Proprietario);

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeVazio()
        {
            ProprietarioCreate.Nome = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o nome.")]
        public void NomeNulo()
        {
            ProprietarioCreate.Nome = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o documento.")]
        public void DocumentoVazio()
        {
            ProprietarioCreate.Documento = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o documento.")]
        public void DocumentoNulo()
        {
            ProprietarioCreate.Documento = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o e-mail.")]
        public void EmailVazio()
        {
            ProprietarioCreate.Email = string.Empty;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Por favor, informe o e-mail.")]
        public void EmailNulo()
        {
            ProprietarioCreate.Email = null;

            var proprietarioRepository = new Mock<IProprietarioRepository>();
            var enderecoService = new Mock<IEnderecoService>();

            proprietarioRepository.Setup(x => x.GetByDocumento(ProprietarioCreate.Documento));
            enderecoService.Setup(x => x.Create(ProprietarioCreate.Endereco, true));

            var proprietarioService = new ProprietarioService(proprietarioRepository.Object, enderecoService.Object);

            proprietarioService.Create(ProprietarioCreate);
        }
    }
}
