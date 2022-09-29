using DeclarationPlus.Core.Mapper.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Queries.GetAllDeclaration
{
    public class GetAllDeclarationQueryResponse
    {
        public ImmutableArray<DeclarationViewModel> List { get; set; }

        public GetAllDeclarationQueryResponse(ImmutableArray<DeclarationViewModel> list)
        {
            List = list;
        }
    }
}
