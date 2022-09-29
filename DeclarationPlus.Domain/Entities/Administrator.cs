using DeclarationPlus.Domain.Ddd;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Entities
{
    public class Administrator : Entity<AdministratorId>
    {
        public Territory Territory { get; set; }

        public Administrator(Territory territory, AdministratorId id)
        {
            if (territory == null)
                throw new ArgumentException("territory cannot be null");
            if (id == null)
                throw new ArgumentException("AdministratorId cannot be null");

            Id = id;
            Territory = territory;
        }

        public bool CanAccept(TerritoryId territoryId)
        {
            if (Territory != null)
                return territoryId == Territory.Id;
            return false;
        }
    }
}
