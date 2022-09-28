using DeclarationPlus.Domain.Ddd;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeclarationPlus.Domain.Entities
{
    public class Territory : Entity<TerritoryId>
    {
        public Territory(TerritoryId Id)
        {
            if (Id == null)
                throw new ArgumentException("Id cannot be null");


            this.Id = Id;
        }
    }
}
