using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.Builders
{
    public class AdministratorBuilder
    {
        private Territory terriory = TerritoryBuilder.GivenTerritory().Build();

        private AdministratorId administratorId = new AdministratorId(999);

        public static AdministratorBuilder GiveAdministrator() => new AdministratorBuilder();

        public AdministratorBuilder WithTerritory(
Action<TerritoryBuilder> territoryBuilderAction)
        {
            var territoryBuilder = new TerritoryBuilder();
            territoryBuilderAction(territoryBuilder);
            terriory = territoryBuilder.Build();
            return this;
        }

        public Administrator Build()
        {
            return new Administrator(terriory,administratorId);
        }

        public AdministratorBuilder WithId(int v)
        {
            administratorId = new AdministratorId(v);
            return this; ;
        }
    }
}
