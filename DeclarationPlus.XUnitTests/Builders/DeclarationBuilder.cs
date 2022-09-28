using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.Builders
{
    public class DeclarationBuilder
    {
        private DeclarationId declarationId = new DeclarationId(999);

        private Citizen citizen = new CitizenBuilder().Build();

        private Territory territory = TerritoryBuilder.GivenBuilder().Build();


        private ScoringRulesFactory scoringRulesFactory = new ScoringRulesFactory();

        private Administrator administrator = AdministratorBuilder.GiveBuilder().Build();


        public DeclarationBuilder WithAdministrator(int adminstratorId, int territoryId)
        {
            administrator = AdministratorBuilder.GiveBuilder().WithId(adminstratorId)
                .WithTerritory(s => s.WithId(territoryId)).Build();

            return this;
        }

        public DeclarationBuilder WithAdministrator(Action<AdministratorBuilder> administratorBuilderAction)
        {
            var adminstratorBuilder = new AdministratorBuilder();
            administratorBuilderAction(adminstratorBuilder);
            administrator = adminstratorBuilder.Build();

            return this;
        }

        public DeclarationBuilder WithTerritory(
            Action<TerritoryBuilder> terriotryBuilderAction)
        {
            var categoryBuilder = new TerritoryBuilder();
            terriotryBuilderAction(categoryBuilder);
            territory = categoryBuilder.Build();
            return this;
        }

        public Declaration Build()
        {
            var cfs = new Declaration
            (
               citizen, declarationId, territory

            );

            return cfs;
        }

    }
}
