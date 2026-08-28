using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebArMa.Application.Mappings;

namespace WebArMa.Common.Extensions
{
    public static class WebArMaMappingExtensions
    {
        public static IServiceCollection AddWebArMaMapping(this IServiceCollection services, params Assembly[] assemblies)
        {
            var config = new WebArMaTypeAdapterConfig();
            var mappingTypes = assemblies.SelectMany(a => a.GetTypes()).Where(t => !t.IsAbstract && !t.IsInterface && typeof(IWebArMaMapperConfiguration).IsAssignableFrom(t)).ToList();

            foreach (var type in mappingTypes)
            {
                var mapping = (IWebArMaMapperConfiguration)Activator.CreateInstance(type)!;
                mapping.Register(config);
            }

            services.AddSingleton(config);
            return services;
        }
    }
}
