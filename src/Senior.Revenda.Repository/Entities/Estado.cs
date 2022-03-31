using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senior.Revenda.Repository.Entities
{
    [Table("estado")]
    public class Estado
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public bool Status { get; set; }
    }
}
