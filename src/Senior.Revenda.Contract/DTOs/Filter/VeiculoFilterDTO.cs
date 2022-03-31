using Senior.Revenda.Contract.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Senior.Revenda.Contract.DTOs.Filter
{
    public class VeiculoFilterDTO
    {
        public string Renavam { get; set; }
        public string Modelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public int? Quilometragem { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
        [DisplayName("Proprietário")]
        public Guid? IdProprietario { get; set; }
        [DisplayName("Marca")]
        public Guid? IdMarca { get; set; }
        public StatusVeiculoFilterEnum Status { get; set; }
        public List<VeiculoDTO> Lista { get; set; } = new List<VeiculoDTO>();
    }
}
