using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.ResolveAnything;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Interseguro.Mantenimiento.Poliza.CrossCutting.IoC
{
    public class IoCAutofacContainer
    {
        private static IContainer container;
        protected static readonly Lazy<IoCAutofacContainer> instance = new Lazy<IoCAutofacContainer>(() => new IoCAutofacContainer(), true);


        public static IoCAutofacContainer Current
        {
            get { return instance.Value; }
        }
        public static IContainer Initialize(IServiceCollection services)
        {

            ContainerBuilder builder;
            try
            {
                builder = new ContainerBuilder();
                builder.Populate(services);


                string[] assemblyScanerPattern = new[] {
                    "Interseguro.Mantenimiento.Poliza.Application.*.dll",
                    "Interseguro.Mantenimiento.Poliza.Repository.*.dll"
                };

                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);


                List<Assembly> assemblies = new List<Assembly>();
                assemblies.AddRange(
                    Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                             .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                             .Select(Assembly.LoadFrom)
                    );

                //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

                foreach (var assembly in assemblies)
                    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

                container = builder.Build();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            return container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        public T Resolve<T>(string name, object value)
        {
            return container.Resolve<T>(new NamedParameter(name, value));
        }
    }
}
