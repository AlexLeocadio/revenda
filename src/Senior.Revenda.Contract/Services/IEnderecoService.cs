using Senior.Revenda.Contract.DTOs;
using System;
using System.Threading.Tasks;

namespace Senior.Revenda.Contract.Services
{
    public interface IEnderecoService
    {
        EnderecoDTO Get(Guid id);
        Guid UpdateOrCreate(EnderecoDTO enderecoDTO, bool transaction = false);
        Guid Create(EnderecoDTO enderecoDTO, bool transaction = false);
        CepDTO GetByCep(string cep);
    }
}
