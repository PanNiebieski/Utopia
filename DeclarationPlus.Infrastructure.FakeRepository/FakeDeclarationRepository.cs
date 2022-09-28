using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects;
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


        public async Task<ImmutableArray<Declaration>> GetAllAsync()
        {
            await Task.Delay(500);
            return declarations.ToImmutableArray();
        }

        public async Task<Declaration> GetByIdAsync(DeclarationId id)
        {
            await Task.Delay(500);
            return declarations.FirstOrDefault(d => d.Id.Value == id.Value);
        }

        public async Task<DeclarationId> SubmitAsync(Declaration declaration)
        {
            await Task.Delay(500);
            declarations.Add(declaration);
            return declaration.Id;
        }

        public async Task SaveAcceptenceAsync(DeclarationId id, AdministratorId administratorId, Decision dec)
        {
            await Task.Delay(500);
            throw new NotImplementedException();
        }

        public async Task SaveEvaluatationAsync(DeclarationId id, DeclarationScoringResult score)
        {
            await Task.Delay(500);
            throw new NotImplementedException();
        }

        public async Task SaveRejectionAsync(DeclarationId id, AdministratorId administratorId, Decision dec)
        {
            await Task.Delay(500);
            throw new NotImplementedException();
        }


    }
}
