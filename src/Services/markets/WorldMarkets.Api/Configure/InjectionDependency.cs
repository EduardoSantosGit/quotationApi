using LightInject;
using Microsoft.Extensions.Configuration;
using Services.markets.WorldMarkets.Api.Controllers;
using Services.markets.WorldMarkets.Domain;
using Services.markets.WorldMarkets.Domain.Common;
using Services.markets.WorldMarkets.Domain.Services;
using Services.markets.WorldMarkets.Infrastructure;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Services.markets.WorldMarkets.Configure
{
    public class InjectionDependency
    {
        public static ServiceContainer ConfigureService()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            var containerOptions = new ContainerOptions { EnablePropertyInjection = false };
            var container = new ServiceContainer(containerOptions);

            container.RegisterInstance(
                new WorldMarketsServiceScrap(new WorldMarketServicesApi(), new ScrapParser())
            );

            container.RegisterInstance(
                new WorldMarketsService(container.GetInstance<WorldMarketsServiceScrap>())
            );

            container.RegisterInstance(
                new WorldMarketsController(container.GetInstance<WorldMarketsService>())
            );

            container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            return container;
        }

    }
}
