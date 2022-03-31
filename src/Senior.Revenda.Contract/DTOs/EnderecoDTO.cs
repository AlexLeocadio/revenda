using System;
using System.ComponentModel;

namespace Senior.Revenda.Contract.DTOs
{
    public class EnderecoDTO
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        [DisplayName("Estado")]
        public Guid IdEstado { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}
