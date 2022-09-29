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

namespace DeclarationPlus.Core.CQRS.Administrators.Queries.GetAllAdministrators
{
    public class GetAllAdministratorsQueryHandler
          : IQueryHandler<GetAllAdministratorsQuery, GetAllAdministratorsQueryResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAdministratorRepository _territoryRepository;

        public GetAllAdministratorsQueryHandler(IMapper mapper, IAdministratorRepository territoryRepository)
        {
            _mapper = mapper;
            _territoryRepository = territoryRepository;
        }


        public async ValueTask<GetAllAdministratorsQueryResponse> Handle
            (GetAllAdministratorsQuery query, CancellationToken ct)
        {
            var list = await _territoryRepository.GetAllAsync();

            if (query.territoryId.HasValue)
                list = list.Where(a => a.Territory.Id.Value == query.territoryId.Value).ToImmutableArray();

            var maped = _mapper.Map<ImmutableArray<AdministratorDto>>(list);

            return new GetAllAdministratorsQueryResponse(maped);
        }
    }
}
