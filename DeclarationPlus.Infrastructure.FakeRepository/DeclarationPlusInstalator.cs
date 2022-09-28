using DeclarationPlus.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Infrastructure.FakeRepository
{
    public static partial class DeclarationPlusInstalator
    {

        public static IServiceCollection
            AddDeclarationPlusFakeRepositoriesServices
            (this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IDeclarationRepository, FakeDeclarationRepository>();
            services.AddSingleton<ITerritoryRepository, FakeTerritoryRepository>(); 
            services.AddSingleton<IAdministratorRepository, FakeAdministratorRepository>();

            return services;
        }
    }
}
