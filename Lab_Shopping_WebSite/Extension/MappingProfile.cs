using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;
using System.Reflection;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Extension
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") ??
                                 type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
