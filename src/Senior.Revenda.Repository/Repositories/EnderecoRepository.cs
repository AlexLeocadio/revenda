using AutoMapper;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Repository.Contexts;
using Senior.Revenda.Repository.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Senior.Revenda.Repository.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public RevendaContext _context { get; }
        protected readonly IMapper _mapper;

        public EnderecoRepository(RevendaContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EnderecoDTO Get(Guid id)
        {
            var result = _context.Endereco.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var returnResult = _mapper.Map<EnderecoDTO>(result);
            return returnResult;
        }

        public Guid Update(EnderecoDTO enderecoDTO, bool transaction = false)
        {
            _context.IgnoreSaveChangeAndUseTransaction = transaction;

            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            var result = _context.Endereco.Attach(endereco);

            _context.Entry(result).State = EntityState.Modified;

            _context.SaveChanges();

            return result.Id;
        }

        public Guid Create(EnderecoDTO enderecoDTO, bool transaction = false)
        {
            _context.IgnoreSaveChangeAndUseTransaction = transaction;

            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            var result = _context.Endereco.Add(endereco);

            _context.SaveChanges();

            return result.Id;
        }
    }
}
