using Senior.Revenda.Contract.DTOs;

namespace Senior.Revenda.Contract.Applications
{
    public interface IEnderecoApplication
    {
        CepDTO GetByCep(string cep);
    }
}
