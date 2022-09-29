using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Scoring
{
    public static partial class DeclarationPlusInstalator
    {
        public static IServiceCollection AddScoringRulesFactory(this IServiceCollection services)
        {
            services.AddSingleton<IScoringRulesFactory, ScoringRulesFactory>();

            return services;
        }
    }
}
