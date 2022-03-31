using Autofac;
using MassTransit;
using Senior.Revenda.Contract.Producer;
using Senior.Revenda.Producer;
using System;
using System.Threading;

namespace Senior.Revenda.IoC
{
    public class BusModule
    {
        public static void ConfigureServices(ContainerBuilder builder)
        {
            builder.RegisterType<MessageBus>().As<IMessageBus>();

            builder.Register(context =>
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });
                });
            })
           .SingleInstance()
           .As<IBus>()
           .As<IBusControl>();

            
        }
    }
}
