using Senior.Revenda.Contract.Enum;
using System;

namespace Senior.Revenda.Contract.DTOs
{
    public class MarcaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public StatusEnum Status { get; set; }
    }
}
