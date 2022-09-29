using AutoMapper;
using DeclarationPlus.Core.Mapper.Dto;
using DeclarationPlus.Domain.Entities;

namespace DeclarationPlus.Core.Mapper
{
    public class DeclarationViewModelTypeConverter : ITypeConverter<Declaration, DeclarationViewModel>
    {
        public DeclarationViewModel Convert(Declaration source, DeclarationViewModel destination, ResolutionContext context)
        {
            DeclarationViewModel declarationViewModel = new DeclarationViewModel();

            declarationViewModel.Id = source.Id.Value;

            declarationViewModel.Status = (int)source.Status;

            if (source.EvaluationResult != null)
            {
                declarationViewModel.Flag = (int)source.EvaluationResult.ScoringFlag.Flag;
                declarationViewModel.SocialScore = source.EvaluationResult.SocialScore.SocialScore;
            }

            return declarationViewModel;
        }
    }
}