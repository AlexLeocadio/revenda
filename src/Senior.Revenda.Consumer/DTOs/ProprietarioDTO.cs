using Senior.Revenda.Contract.Enum;
using System;

namespace Senior.Revenda.Contract.DTOs
{
    public class ProprietarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public Guid IdEndereco { get; set; }
        public StatusEnum Status { get; set; }

        public EnderecoDTO Endereco { get; set; }
    }
}
