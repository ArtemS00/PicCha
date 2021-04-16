using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PicCha
{
    public static class ConfiguredModuleRegistrationExtensions
    {
        public static void RegisterConfiguredModulesFromAssemblyContaining<TType>(this ContainerBuilder builder, IConfigurationRoot configuration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var metaBuilder = new ContainerBuilder();

            metaBuilder.RegisterInstance(configuration);
            metaBuilder.RegisterAssemblyTypes(typeof(TType).GetTypeInfo().Assembly)
                .AssignableTo<IModule>()
                .As<IModule>()
                .PropertiesAutowired();

            using (var metaContainer = metaBuilder.Build())
            {
                foreach (var module in metaContainer.Resolve<IEnumerable<IModule>>())
                    builder.RegisterModule(module);
            }
        }
    }
}
