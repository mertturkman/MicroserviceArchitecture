using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Product.Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;

namespace Product.API.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo di = new DirectoryInfo(path);
            List<Assembly> assemblies = new List<Assembly>();
            
            foreach(FileInfo file in di.GetFiles("*.dll")){
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                IEnumerable<TypeInfo> classTypes = assembly.GetExportedTypes().Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);;
                
                foreach (TypeInfo type in classTypes)
                {
                    IEnumerable<TypeInfo> interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());                    
                    foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)))
                    {
                        services.AddScoped(type.ImplementedInterfaces.ElementAt(0),type.AsType());
                    }
                }
            }

            return services;
        }
    }
}