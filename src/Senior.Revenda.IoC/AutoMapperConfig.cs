using AutoMapper;
using Senior.Revenda.Contract.DTOs;
using Senior.Revenda.Contract.Enum;
using Senior.Revenda.Infrastructure.Extensions;
using Senior.Revenda.Repository.Entities;

namespace Senior.Revenda.IoC
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Endereco, EnderecoDTO>().ForMember(e => e.Cep, x => x.MapFrom(y => y.Cep.FormatarCep()))
                                         .ReverseMap().ForMember(e => e.Cep, x => x.MapFrom(y => y.Cep.RemoverFormatacaoCep()));
                cfg.CreateMap<Estado, EstadoDTO>().ReverseMap();
                cfg.CreateMap<Marca, MarcaDTO>().ForMember(e => e.Status, x => x.MapFrom(y => y.Status ? StatusEnum.Ativo : StatusEnum.Cancelado))
                                   .ReverseMap().ForMember(e => e.Status, x => x.MapFrom(y => y.Status == StatusEnum.Ativo));
                cfg.CreateMap<Proprietario, ProprietarioDTO>().ForMember(e => e.Status, x => x.MapFrom(y => y.Status ? StatusEnum.Ativo : StatusEnum.Cancelado))
                                                 .ReverseMap().ForMember(e => e.Status, x => x.MapFrom(y => y.Status == StatusEnum.Ativo));
                cfg.CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
            });

            return mapperConfiguration;
        }
    }
}
