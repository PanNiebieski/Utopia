using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Scoring
{
    public class ScoringRules
    {
        private readonly IList<IScoringRejectRule> rejectrules;
        private readonly IList<IScoringWarringRule> warringrules;
        private readonly IList<IScoringSocialScore> socialscorerules;

        public ScoringRules(IList<IScoringRejectRule> rejectrules,
            IList<IScoringWarringRule> warringrules,
            IList<IScoringSocialScore> socialscorerules)
        {
            this.rejectrules = rejectrules;
            this.warringrules = warringrules;
            this.socialscorerules = socialscorerules;
        }

        public DeclarationScoringResult Evaluate(Declaration  dec)
        {
            //int score = 0;
            //foreach (var item in socialscorerules)
            //{
            //    score += item.AddOrLowerPoints(dec);
            //}

            //bool warring = false;
            //foreach (var item in warringrules)
            //{
            //    if (!item.IsSatisfiedBy(dec))
            //    {
            //        warring = true;
            //        break;
            //    }
            //}

            //bool reject = false;
            //foreach (var item in rejectrules)
            //{
            //    if (!item.IsSatisfiedBy(dec))
            //    {
            //        reject = true;
            //        break;
            //    }
            //}

            int score = 0;
            foreach (var item in socialscorerules)
            {
               score += item.AddOrLowerPoints(dec);
            }

            DeclarationSocialScore declarationSocialScore =
                new DeclarationSocialScore(score);

            DeclarationScoringStatus status = DeclarationScoringStatus.Green();

            //Analogicznie napisać dla warringrules

            var brokenRules = this.rejectrules
                .Where(r => !r.IsSatisfiedBy(dec))
                .ToList();

            if (brokenRules.Any())
                status = DeclarationScoringStatus.Red
                    (brokenRules.Select(r => r.Message).
                    ToArray());

            return 
                new DeclarationScoringResult(status, declarationSocialScore);
        }
    }
}
