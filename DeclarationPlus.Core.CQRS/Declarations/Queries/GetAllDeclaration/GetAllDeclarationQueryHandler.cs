using AutoMapper;
using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries;
using DeclarationPlus.Core.Mapper.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Queries.GetAllDeclaration
{
    public class GetAllDeclarationQueryHandler :
        IQueryHandler<GetAllDeclarationQuery, GetAllDeclarationQueryResponse>
    {

        private readonly IMapper _mapper;
        private readonly IDeclarationRepository _territoryRepository;

        public GetAllDeclarationQueryHandler(IMapper mapper, IDeclarationRepository territoryRepository)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
        }


        public async ValueTask<GetAllDeclarationQueryResponse> Handle(GetAllDeclarationQuery query, CancellationToken ct)
        {
            var list = await _territoryRepository.GetAllAsync();

            var maped = _mapper.Map<List<DeclarationViewModel>>(list);

            return new GetAllDeclarationQueryResponse(maped);
        }
    }
}
