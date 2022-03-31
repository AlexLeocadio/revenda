using Senior.Revenda.Contract.Enum;
using System;

namespace Senior.Revenda.Contract.DTOs
{
    public class VeiculoDTO
    {
        public Guid Id { get; set; }
        public Guid IdProprietario { get; set; }
        public string Renavam { get; set; }
        public Guid IdMarca { get; set; }
        public string Modelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
        public int? Quilometragem { get; set; }
        public decimal Valor { get; set; }
        public StatusVeiculoEnum? Status { get; set; }
        public ProprietarioDTO Proprietario { get; set; }
        public MarcaDTO Marca { get; set; }
    }
}