using DeclarationPlus.Core.Mapper.Dto;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration
{
    public record SubmitDeclarationCommand
    {

        public CitizenDto Citizen { get; set; }

        public int TerritoryId { get; set; }
    }
}
