using Senior.Revenda.Contract.Enum;
using System.Collections.Generic;

namespace Senior.Revenda.Contract.DTOs.Filter
{
    public class ProprietarioFilterDTO
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public StatusFilterEnum Status { get; set; }

        public List<ProprietarioDTO> Lista { get; set; } = new List<ProprietarioDTO>();
    }
}
