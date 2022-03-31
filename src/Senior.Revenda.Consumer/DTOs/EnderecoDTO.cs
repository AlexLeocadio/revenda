using System;

namespace Senior.Revenda.Contract.DTOs
{
    public class EnderecoDTO
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Guid IdEstado { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}
