using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects;
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
        public static DeclarationBuilder GivenDeclaration() => new DeclarationBuilder();


        private DeclarationId declarationId = new DeclarationId(999);

        private Citizen citizen = new CitizenBuilder().Build();

        private Territory territory = TerritoryBuilder.GivenTerritory().Build();


        private ScoringRulesFactory scoringRulesFactory = new ScoringRulesFactory();

        private Administrator administrator = AdministratorBuilder.GiveAdministrator().Build();

        private DeclarationStatus targetStatus = DeclarationStatus.New;


        public DeclarationBuilder WithAdministrator(int adminstratorId, int territoryId)
        {
            administrator = AdministratorBuilder.GiveAdministrator().WithId(adminstratorId)
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


        public DeclarationBuilder WithAdministrator(Administrator administrator)
        {
            this.administrator = administrator;
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

        public DeclarationBuilder WithCitizen(
    Action<CitizenBuilder> CitizenBuilderAction)
        {
            var citizenBuilder = new CitizenBuilder();
            CitizenBuilderAction(citizenBuilder);
            citizen = citizenBuilder.Build();
            return this;
        }

        public DeclarationBuilder Evaluated()
        {
            targetStatus = DeclarationStatus.EvaluatedByMachine;
            return this;
        }

        public DeclarationBuilder Rejected()
        {
            targetStatus = DeclarationStatus.Rejected;
            return this;
        }

        public DeclarationBuilder NotEvaluated()
        {
            targetStatus = DeclarationStatus.New;
            return this;
        }

        public DeclarationBuilder New()
        {
            targetStatus = DeclarationStatus.New;
            return this;
        }

        public DeclarationBuilder Accepted()
        {
            targetStatus = DeclarationStatus.AcceptedByAdministrator;
            return this;
        }


        public Declaration Build()
        {
            var cfs = new Declaration
            (
               citizen, declarationId, territory
            );

            if (targetStatus == DeclarationStatus.EvaluatedByMachine)
            {
                cfs.Evaluate(scoringRulesFactory.DefaultSet);
            }

            if (targetStatus == DeclarationStatus.AcceptedByAdministrator)
            {
                cfs.Evaluate(scoringRulesFactory.DefaultSet);
                cfs.Accept(administrator);
            }

            if (targetStatus == DeclarationStatus.Rejected)
            {
                cfs.Reject(administrator);
            }

            return cfs;
        }

    }
}
