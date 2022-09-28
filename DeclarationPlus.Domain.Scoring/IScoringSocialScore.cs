using DeclarationPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Scoring
{
    public interface IScoringSocialScore
    {
        public int AddOrLowerPoints(Declaration  dec);
        public string Description { get; }
    }
}
