using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System.Collections.Immutable;

namespace DeclarationPlus.Infrastructure.FakeRepository
{
    public class FakeAdministratorRepository : IAdministratorRepository
    {
        List<Administrator> administrators = new List<Administrator>();

        public FakeAdministratorRepository()
        {
            administrators.Add(new Administrator(new Territory(new TerritoryId(1)), new AdministratorId(1)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(1)), new AdministratorId(2)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(1)), new AdministratorId(3)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(1)), new AdministratorId(4)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(2)), new AdministratorId(5)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(2)), new AdministratorId(6)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(2)), new AdministratorId(7)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(3)), new AdministratorId(8)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(3)), new AdministratorId(9)));
            administrators.Add(new Administrator(new Territory(new TerritoryId(3)), new AdministratorId(10)));
        }

        public async Task<List<Administrator>> GetAllAsync()
        {
            await Task.Delay(500);
            return administrators.ToList();
        }

        public async Task<Administrator> GetByIdAsync(AdministratorId id)
        {
            await Task.Delay(500);
            return administrators.FirstOrDefault(ad => ad.Id.Value == id.Value);
        }
    }
}