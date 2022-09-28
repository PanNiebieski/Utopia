using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.Scoring
{
    public interface IScoringSocialScore
    {
        public int AddPoints(/*Declaration  dec*/);
        public int Description { get; }
    }
}
