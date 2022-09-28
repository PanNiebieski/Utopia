using DeclarationPlus.Core.Scoring.Rules.Accept;
using DeclarationPlus.Core.Scoring.Rules.SocialScore;
using DeclarationPlus.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Scoring
{
    public class ScoringRulesFactory : IScoringRulesFactory
    {
        public ScoringRulesFactory()
        {

        }

        public ScoringRules DefaultSet => new ScoringRules(
        new List<IScoringRejectRule>
        {
            new CitizenAgeMusteBeBelow70()
        },
        new List<IScoringWarringRule>()
        {

        },
        new List<IScoringSocialScore>()
        {
            new KidsScoringSocialScore()
        });
    }
}
