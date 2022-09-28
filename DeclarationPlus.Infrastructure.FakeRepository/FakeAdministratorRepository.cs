﻿using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;

namespace DeclarationPlus.Infrastructure.FakeRepository
{
    public class FakeAdministratorRepository : IAdministratorRepository
    {
        List<Administrator> administrators = new List<Administrator>();

        public FakeAdministratorRepository()
        {
            administrators.Add(new Administrator(, new AdministratorId(1));
            administrators.Add(new Administrator(, new AdministratorId(2));
            administrators.Add(new Administrator(, new AdministratorId(3));
            administrators.Add(new Administrator(, new AdministratorId(4));
            administrators.Add(new Administrator(, new AdministratorId(5));
            administrators.Add(new Administrator(, new AdministratorId(6));
            administrators.Add(new Administrator(, new AdministratorId(7));
            administrators.Add(new Administrator(, new AdministratorId(8));
            administrators.Add(new Administrator(, new AdministratorId(9));
            administrators.Add(new Administrator(, new AdministratorId(10));
        }


        public async Task<Administrator> GetByIdAsync(AdministratorId id)
        {
            await Task.Delay(500);
            return administrators.FirstOrDefault(ad => ad.Id.Value == id.Value);
        }
    }
}