using Bit.Core;
using Bit.Core.Contracts;
using Bit.Owin.Implementations;
using Bit.OwinCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BitWebApiODataVersioningSample
{
    public class Startup : AutofacAspNetCoreAppStartup, IAppModule, IAppModulesProvider
    {
        public Startup(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
            DefaultAppModulesProvider.Current = this;

            return base.ConfigureServices(services);
        }

        public IEnumerable<IAppModule> GetAppModules()
        {
            yield return this;
        }

        public virtual void ConfigureDependencies(IServiceCollection services, IDependencyManager dependencyManager)
        {
            AssemblyContainer.Current.Init();
            AssemblyContainer.Current.AddAppAssemblies(Assembly.Load("ApiSrcV1"), Assembly.Load("ApiSrcV2"));

            dependencyManager.RegisterMinimalDependencies();

            dependencyManager.RegisterDefaultLogger(typeof(DebugLogStore).GetTypeInfo(), typeof(ConsoleLogStore).GetTypeInfo());

            dependencyManager.RegisterDefaultAspNetCoreApp();

            dependencyManager.RegisterMinimalAspNetCoreMiddlewares();

            dependencyManager.RegisterDefaultWebApiAndODataConfiguration();

            dependencyManager.RegisterODataMiddleware(odataDependencyManager =>
            {
                odataDependencyManager.RegisterGlobalWebApiCustomizerUsing(httpConfiguration =>
                {
                    httpConfiguration.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("MyApp", $"Swagger-Api");
                        c.ApplyDefaultODataConfig(httpConfiguration);
                    }).EnableBitSwaggerUi();
                });

                odataDependencyManager.RegisterWebApiODataMiddlewareUsingDefaultConfiguration();
            });
        }
    }
}
