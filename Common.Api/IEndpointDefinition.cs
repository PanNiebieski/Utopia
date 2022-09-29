using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api.EndPointsMappingTool
{
    public interface IEndpointDefinition
    {
        void DefineServices(IServiceCollection
            services);

        //void DefineEndpoints(IHost app)
        //void DefineEndpoints(IEndpointRouteBuilder app)
        void DefineEndpoints(WebApplication app);
    }
}
