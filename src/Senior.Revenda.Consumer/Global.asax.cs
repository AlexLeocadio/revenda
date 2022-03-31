using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Senior.Revenda.Consumer.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Senior.Revenda.Consumer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var services = new ServiceCollection();
            services.AddMassTransit(x =>
            {
                x.AddConsumer<VeiculoConsumer>();

                Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("admin");
                        h.Password("admin");
                    });

                    cfg.ReceiveEndpoint("veiculoQueue", e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(r => r.Interval(2, 100));
                        e.Consumer<VeiculoConsumer>();
                    });
                }).Start();
            });
        }
    }
}
