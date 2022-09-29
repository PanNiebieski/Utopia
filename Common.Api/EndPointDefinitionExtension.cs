using Common.Api.EndPointsMappingTool;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Api
{
    public static class EndPointDefinitionExtension
    {

        public static void AddEndpointDefinitions(
            this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpoints = new List<IEndpointDefinition>();

            foreach (var scanMarker in scanMarkers)
            {
                endpoints.AddRange(
                    scanMarker.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpointDefinition)
                    .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance)
                    .Cast<IEndpointDefinition>()
                );
            }

            foreach (var endpoint in endpoints)
            {
                endpoint.DefineServices(services);
            }

            services.AddSingleton
                (endpoints as IReadOnlyCollection<IEndpointDefinition>);
        }

        //public static void UseEndpointDefinitions(this IHost app)
        //public static void UseEndpointDefinitions(this IEndpointRouteBuilder app)
        public static void UseEndpointDefinitions(this WebApplication app)
        {
            var defs = app.Services.
            GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

            foreach (var def in defs)
            {
                def.DefineEndpoints(app);
            }
        }
    }
}