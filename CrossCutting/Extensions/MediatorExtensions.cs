using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services)
        {
            List<Type> handlerTypes = new List<Type>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo di = new DirectoryInfo(path);
            List<Assembly> assemblies = new List<Assembly>();

            foreach(FileInfo file in di.GetFiles("*.dll")){
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                IEnumerable<TypeInfo> classTypes = assembly.GetExportedTypes().Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

                 foreach (TypeInfo type in classTypes)
                 {
                    IEnumerable<TypeInfo> interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());                    
                    foreach (TypeInfo handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                    {
                        handlerTypes.Add(type.AsType());
                    }
                 }
            }
            services.AddMediatR(handlerTypes.ToArray());

            return services;
        }
    }
}