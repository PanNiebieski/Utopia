using AutoMapper;
using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.Mapper.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries
{
    public class GetAllTerriotiesQueryHandler :
        IQueryHandler<GetAllTerriotiesQuery, GetAllTerriotiesQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryRepository _territoryRepository;

        public GetAllTerriotiesQueryHandler(IMapper mapper, ITerritoryRepository territoryRepository)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
        }


        public async ValueTask<GetAllTerriotiesQueryResponse> Handle
            (GetAllTerriotiesQuery query, CancellationToken ct)
        {
            var list = await _territoryRepository.GetAllAsync();

            if (query.OrderBy == OrderByTerritoryOptions.ById)
                list = list.OrderByDescending(t => t.Id).Skip((query.Page -1) * query.Page).
                    Take(query.PageSize).ToList();

            var maped = _mapper.Map<List<TerritoryDto>>(list);

            return new GetAllTerriotiesQueryResponse(maped);
        }
    }
}
