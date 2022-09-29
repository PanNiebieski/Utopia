using DeclarationPlus.Core.Mapper.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries
{
    public class GetAllTerriotiesQueryResponse
    {
        public ImmutableArray<TerritoryDto> List { get; set; }

        public GetAllTerriotiesQueryResponse(ImmutableArray<TerritoryDto> list)
        {
            List = list;
        }
    }
}
