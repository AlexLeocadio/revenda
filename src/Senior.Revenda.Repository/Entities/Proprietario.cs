using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senior.Revenda.Repository.Entities
{
    [Table("proprietario")]
    public class Proprietario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public Guid IdEndereco { get; set; }
        public bool Status { get; set; }
    }
}
