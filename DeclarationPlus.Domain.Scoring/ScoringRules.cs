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

        //public DeclarationScoringResult Evaluate(/*Declaration  dec*/)
        //{

        //}
    }
}
