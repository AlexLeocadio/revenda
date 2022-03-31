using Senior.Revenda.Contract.Enum;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.DTOs.Filter
{
    public class MarcaFilterDTO
    {
        public string Nome { get; set; }
        public StatusFilterEnum Status { get; set; }

        public List<MarcaDTO> Lista { get; set; } = new List<MarcaDTO>();
    }
}
