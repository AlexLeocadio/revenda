using Senior.Revenda.Contract.DTOs;
using System;

namespace Senior.Revenda.Contract.Repositories
{
    public interface IEnderecoRepository
    {
        EnderecoDTO Get(Guid id);
        Guid Update(EnderecoDTO enderecoDTO, bool transaction = false);
        Guid Create(EnderecoDTO enderecoDTO, bool transaction = false);
    }
}
