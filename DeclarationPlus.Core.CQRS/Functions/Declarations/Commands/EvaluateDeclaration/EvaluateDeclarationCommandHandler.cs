using Common.Core.CQRS;
using DeclarationPlus.Core.Contracts;
using DeclarationPlus.Core.CQRS.Declarations.Commands.RejectDeclaration;
using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Declarations.Commands.EvaluateDeclaration
{
    public class EvaluateDeclarationCommandHandler
        :
        ICommandHandler<EvaluateDeclarationCommand, EvaluateDeclarationCommandResponse>
    {

        private readonly IDeclarationRepository _declarationRepository;

        private readonly IScoringRulesFactory _scoringRulesFactory;

        public EvaluateDeclarationCommandHandler(IDeclarationRepository declarationRepository,
            IScoringRulesFactory scoringRulesFactory)
        {
            _declarationRepository = declarationRepository;
            _scoringRulesFactory = scoringRulesFactory;
        }

        public async ValueTask<EvaluateDeclarationCommandResponse> Handle(EvaluateDeclarationCommand command, CancellationToken token)
        {
            var declaration = await _declarationRepository.GetByIdAsync(new DeclarationId(command.Id));

            if (declaration == null)
                return new EvaluateDeclarationCommandResponse($"Declaration with this ID {command.Id} doesn't exist");

            try
            {
                declaration.Evaluate(_scoringRulesFactory.DefaultSet);
            }
            catch (Exception ex)
            {
                return new EvaluateDeclarationCommandResponse(ex.Message);
            }

            await _declarationRepository.SaveEvaluatationAsync(declaration.Id, declaration.EvaluationResult);

            return new EvaluateDeclarationCommandResponse();
        }
    }
}
