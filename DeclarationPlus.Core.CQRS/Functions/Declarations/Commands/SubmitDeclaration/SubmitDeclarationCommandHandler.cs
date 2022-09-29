using AutoMapper;
using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration
{
    public class SubmitDeclarationCommandHandler :
        ICommandHandler<SubmitDeclarationCommand, SubmitDeclarationCommandResponse>
    {

        private readonly IMapper _mapper;

        private readonly IDeclarationRepository _declarationRepository;

        private readonly ITerritoryRepository _territoryRepository;

        public SubmitDeclarationCommandHandler(IMapper mapper, IDeclarationRepository declarationRepository,
            ITerritoryRepository territoryRepository)
        {
            _mapper = mapper;
            _declarationRepository = declarationRepository;
            _territoryRepository = territoryRepository;
        }

        public async ValueTask<SubmitDeclarationCommandResponse> Handle
            (SubmitDeclarationCommand command, CancellationToken token)
        {
            var domainDeclaration = _mapper.Map<SubmitDeclarationCommand, Declaration>(command);

            var validatorResult = domainDeclaration.CheckValidation();
            if (!validatorResult.IsValid)
                return new SubmitDeclarationCommandResponse(validatorResult);

            //Maybe check if territory with that Id exist
            var check = _territoryRepository.GetByIdAsync(new TerritoryId(command.TerritoryId));
            if (check == null)
                return new SubmitDeclarationCommandResponse(validatorResult);

            domainDeclaration.Territory = new (new TerritoryId(command.TerritoryId));

            var id = await _declarationRepository.SubmitAsync(domainDeclaration);

            return new SubmitDeclarationCommandResponse(id.Value);
        }
    }
}
