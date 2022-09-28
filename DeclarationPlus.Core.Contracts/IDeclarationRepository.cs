﻿using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects;
using DeclarationPlus.Domain.ValueObjects.Ids;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Contracts
{
    public interface IDeclarationRepository
    {
        Task<Declaration> GetByIdAsync(DeclarationId id);

        Task<IReadOnlyList<Declaration>> GetAllAsync();

        Task<DeclarationId> SubmitAsync(Declaration declaration);

        Task SaveEvaluatationAsync(DeclarationId id,
            DeclarationScoringResult score);

        Task SaveAcceptenceAsync(DeclarationId id, AdministratorId administratorId,
            Decision dec);

        Task SaveRejectionAsync(DeclarationId id, AdministratorId administratorId,
            Decision dec);
    }
}
