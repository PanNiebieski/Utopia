using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.AcceptDeclaration
{
    public record AcceptDeclarationCommand(int DeclarationId, int AdministratorId)
    {
    }
}
