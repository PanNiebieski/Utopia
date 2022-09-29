using DeclarationPlus.Core.CQRS.Administrators.Queries.GetAllAdministrators;
using DeclarationPlus.Core.CQRS.Declarations.Queries.GetAllDeclaration;
using DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.CQRS
{
    public static partial class DeclarationPlusInstalator
    {
        public static IServiceCollection AddQueries (this IServiceCollection services)
        {

            services.AddQueryHandler
                <GetAllAdministratorsQuery, GetAllAdministratorsQueryResponse, GetAllAdministratorsQueryHandler>();

            services.AddQueryHandler
                <GetAllTerriotiesQuery, GetAllTerriotiesQueryResponse, GetAllTerriotiesQueryHandler>();

            services.AddQueryHandler
                <GetAllDeclarationQuery, GetAllDeclarationQueryResponse, GetAllDeclarationQueryHandler>();

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {


            return services;
        }
    }
}
