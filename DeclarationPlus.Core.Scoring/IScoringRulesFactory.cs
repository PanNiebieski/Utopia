using DeclarationPlus.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Scoring
{
    public interface IScoringRulesFactory
    {
        ScoringRules DefaultSet { get; }
    }
}
