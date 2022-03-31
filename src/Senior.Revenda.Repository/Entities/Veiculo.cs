using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senior.Revenda.Repository.Entities
{
    [Table("veiculo")]
    public class Veiculo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid IdProprietario { get; set; }
        public string Renavam { get; set; }
        public Guid IdMarca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int Quilometragem { get; set; }
        public decimal Valor { get; set; }
        public int Status { get; set; }
    }
}
