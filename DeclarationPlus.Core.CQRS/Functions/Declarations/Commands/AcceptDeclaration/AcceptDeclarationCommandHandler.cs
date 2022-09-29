using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.CQRS.Declarations.Commands.EvaluateDeclaration;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.AcceptDeclaration
{
    public class AcceptDeclarationCommandHandler
        :
        ICommandHandler<AcceptDeclarationCommand, AcceptDeclarationCommandResponse>
    {
        private readonly IDeclarationRepository _declarationRepository;

        private readonly IAdministratorRepository _adminRepository;

        public AcceptDeclarationCommandHandler(IDeclarationRepository declarationRepository, IAdministratorRepository adminRepository)
        {
            _declarationRepository = declarationRepository;
            _adminRepository = adminRepository;
        }

        public async ValueTask<AcceptDeclarationCommandResponse> Handle(AcceptDeclarationCommand command, CancellationToken token)
        {
            var administrator = await _adminRepository.GetByIdAsync(new AdministratorId(command.AdministratorId));

            if (administrator == null)
                return new AcceptDeclarationCommandResponse();

            var declaration = await _declarationRepository.GetByIdAsync(new DeclarationId(command.DeclarationId));

            if (declaration == null)
                return new AcceptDeclarationCommandResponse();

            try
            {
                declaration.Accept(administrator);
            }
            catch (Exception ex)
            {
                return new AcceptDeclarationCommandResponse();
            }

            await _declarationRepository.SaveRejectionAsync(declaration.Id, administrator.Id, declaration.FinalDecision);

            return new AcceptDeclarationCommandResponse();
        }
    }
}
