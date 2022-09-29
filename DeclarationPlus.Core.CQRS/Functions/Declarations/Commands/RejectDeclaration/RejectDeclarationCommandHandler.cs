using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.CQRS.Declarations.Commands.AcceptDeclaration;
using DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.RejectDeclaration
{
    public class RejectDeclarationCommandHandler :
        ICommandHandler<RejectDeclarationCommand, RejectDeclarationCommandResponse>
    {

        private readonly IDeclarationRepository _declarationRepository;

        private readonly IAdministratorRepository _adminRepository;

        public RejectDeclarationCommandHandler(IDeclarationRepository declarationRepository, IAdministratorRepository adminRepository)
        {
            _declarationRepository = declarationRepository;
            _adminRepository = adminRepository;
        }

        public async ValueTask<RejectDeclarationCommandResponse> Handle(RejectDeclarationCommand command, CancellationToken token)
        {
            var administrator = await _adminRepository.GetByIdAsync(new AdministratorId(command.AdministratorId));

            if (administrator == null)
                return new RejectDeclarationCommandResponse();

            var declaration = await _declarationRepository.GetByIdAsync(new DeclarationId(command.DeclarationId));

            if (declaration == null)
                return new RejectDeclarationCommandResponse();

            try
            {
                declaration.Accept(administrator);
            }
            catch (Exception ex)
            {
                return new RejectDeclarationCommandResponse(ex.Message);
            }

            await _declarationRepository.SaveRejectionAsync(declaration.Id, administrator.Id, declaration.FinalDecision);

            return new RejectDeclarationCommandResponse();
        }
    }
}
