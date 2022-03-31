using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Services;

namespace Senior.Revenda.Business.Applications
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoApplication(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public CepDTO GetByCep(string cep)
        {
            var result = _enderecoService.GetByCep(cep);
            return result;
        }
    }
}
