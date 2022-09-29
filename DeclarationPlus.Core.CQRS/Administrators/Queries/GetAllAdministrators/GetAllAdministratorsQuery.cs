using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Administrators.Queries.GetAllAdministrators
{
    public record GetAllAdministratorsQuery(int? territoryId)
    {

    }
}
