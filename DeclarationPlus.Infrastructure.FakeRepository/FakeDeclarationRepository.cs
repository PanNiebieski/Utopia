using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.Scoring;
using DeclarationPlus.Domain.ValueObjects;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using DeclarationPlus.Domain.ValueObjects.Ids;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Infrastructure.FakeRepository
{
    public class FakeDeclarationRepository : IDeclarationRepository
    {
        List<Declaration> declarations = new List<Declaration>();

        public FakeDeclarationRepository()
        {
            declarations.Add(new Declaration(
                new Citizen(new Name("Cezary", "Walenciuk"), DateTime.Now.AddYears(-34), new NumberOfKids(1)),
                new DeclarationId(1), new Territory(new TerritoryId(1))));

            declarations[0].Evaluate(new ScoringRulesFactory().DefaultSet);
        }


        public async Task<List<Declaration>> GetAllAsync()
        {
            await Task.Delay(500);
            return declarations.ToList();
        }

        public async Task<Declaration> GetByIdAsync(DeclarationId id)
        {
            await Task.Delay(500);
            return declarations.FirstOrDefault(d => d.Id.Value == id.Value);
        }

        public async Task<DeclarationId> SubmitAsync(Declaration declaration)
        {
            await Task.Delay(500);
            declaration.Id = new DeclarationId(declarations.Count() + 1);
            declarations.Add(declaration);
            return declaration.Id;
        }

        public async Task SaveAcceptenceAsync(DeclarationId id, AdministratorId administratorId, Decision dec)
        {
            await Task.Delay(500);

            var de = declarations.FirstOrDefault(d => d.Id.Value == id.Value);

            de.FinalDecision = dec;
            
        }

        public async Task SaveEvaluatationAsync(DeclarationId id, DeclarationMachineResult score)
        {
            await Task.Delay(500);

            var de = declarations.FirstOrDefault(d => d.Id.Value == id.Value);

            de.EvaluationResult = score;
        }

        public async Task SaveRejectionAsync(DeclarationId id, AdministratorId administratorId, Decision dec)
        {
            await Task.Delay(500);

            var de = declarations.FirstOrDefault(d => d.Id.Value == id.Value);

            de.FinalDecision = dec;
        }


    }
}
