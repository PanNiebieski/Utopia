using DeclarationPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Scoring
{
    public interface IScoringWarringRule
    {
        bool IsSatisfiedBy(Declaration  dec);

        string Message { get; }
    }
}
