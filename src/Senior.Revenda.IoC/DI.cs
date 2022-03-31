using Autofac;
using AutoMapper;
using Senior.Revenda.Business.Applications;
using Senior.Revenda.Contract.Applications;
using Senior.Revenda.Contract.Repositories;
using Senior.Revenda.Contract.Services;
using Senior.Revenda.Domain.Services;
using Senior.Revenda.Repository.Contexts;
using Senior.Revenda.Repository.Repositories;

namespace Senior.Revenda.IoC
{
    public class DI
    {
        public static IContainer Container { get; private set; }

        public static void RegisterTypes(ContainerBuilder services)
        {
            services.RegisterType<RevendaContext>().InstancePerLifetimeScope();

            services.RegisterType<EnderecoApplication>().As<IEnderecoApplication>();
            services.RegisterType<EstadoApplication>().As<IEstadoApplication>();
            services.RegisterType<MarcaApplication>().As<IMarcaApplication>(); ;
            services.RegisterType<ProprietarioApplication>().As<IProprietarioApplication>();
            services.RegisterType<VeiculoApplication>().As<IVeiculoApplication>();

            services.RegisterType<EnderecoRepository>().As<IEnderecoRepository>();
            services.RegisterType<EstadoRepository>().As<IEstadoRepository>();
            services.RegisterType<MarcaRepository>().As<IMarcaRepository>();
            services.RegisterType<ProprietarioRepository>().As<IProprietarioRepository>();
            services.RegisterType<VeiculoRepository>().As<IVeiculoRepository>();

            services.RegisterType<EnderecoService>().As<IEnderecoService>();
            services.RegisterType<EstadoService>().As<IEstadoService>();
            services.RegisterType<MarcaService>().As<IMarcaService>();
            services.RegisterType<ProprietarioService>().As<IProprietarioService>();
            services.RegisterType<VeiculoService>().As<IVeiculoService>();

            BusModule.ConfigureServices(services);

            services.Register(context => AutoMapperConfig.Configure()).AsSelf().SingleInstance();

            services.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            Container = services.Build();
        }
    }
}
