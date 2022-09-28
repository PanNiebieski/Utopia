using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeclarationPlus.Infrastructure.FakeRepository
{
    public class FakeTerritoryRepository : ITerritoryRepository
    {
        List<Territory> territories = new List<Territory>();

        public async Task<ImmutableArray<Territory>> GetAllAsync()
        {
            await Task.Delay(500);
            return territories.ToImmutableArray();
        }

        public async Task<Territory> GetByIdAsync(TerritoryId id)
        {
            await Task.Delay(500);
            return territories.FirstOrDefault(ad => ad.Id.Value == id.Value);
        }
    }
}
