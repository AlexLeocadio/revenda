using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senior.Revenda.Repository.Entities
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Guid IdEstado { get; set; }
        public string Numero { get; set; }
        public int Cep { get; set; }
    }
}
