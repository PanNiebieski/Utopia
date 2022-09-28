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
    public class TerritoryBuilder
    {

        private TerritoryId territoryId =
            new TerritoryId(999);

        public static TerritoryBuilder GivenTerritory() => new TerritoryBuilder();

        public TerritoryBuilder WithId(int categorId)
        {
            territoryId = new TerritoryId(categorId);
            return this;
        }


        public Territory Build()
        {
            var c = new Territory(territoryId);

            return c;
        }
    }
}
