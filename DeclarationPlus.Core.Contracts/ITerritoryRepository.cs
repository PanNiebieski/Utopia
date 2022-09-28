using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Contracts
{
    public interface ITerritoryRepository
    {
        Task<Territory> GetByIdAsync(TerritoryId id);

        Task<ImmutableArray<Territory>> GetAllAsync();
    }
}
