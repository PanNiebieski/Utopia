using DeclarationPlus.Core.CQRS.Administrators.Queries.GetAllAdministrators;
using DeclarationPlus.Core.CQRS.Declarations.Commands.AcceptDeclaration;
using DeclarationPlus.Core.CQRS.Declarations.Commands.EvaluateDeclaration;
using DeclarationPlus.Core.CQRS.Declarations.Commands.RejectDeclaration;
using DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration;
using DeclarationPlus.Core.CQRS.Declarations.Queries.GetAllDeclaration;
using DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddCommandHandler<SubmitDeclarationCommand, SubmitDeclarationCommandResponse,
                SubmitDeclarationCommandHandler>();

            services.AddCommandHandler<RejectDeclarationCommand, RejectDeclarationCommandResponse,
                RejectDeclarationCommandHandler>();

            services.AddCommandHandler<EvaluateDeclarationCommand, EvaluateDeclarationCommandResponse,
                EvaluateDeclarationCommandHandler>();

            services.AddCommandHandler<AcceptDeclarationCommand, AcceptDeclarationCommandResponse
                ,AcceptDeclarationCommandHandler>();

            return services;
        }
    }
}
