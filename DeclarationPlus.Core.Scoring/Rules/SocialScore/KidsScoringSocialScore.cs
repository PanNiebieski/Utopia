using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Scoring.Rules.SocialScore
{
    public class KidsScoringSocialScore : IScoringSocialScore
    {
        public string Description
        {
            get
            {
                return "";
            }
        }

        public int AddOrLowerPoints(Declaration dec)
        {
            return dec.Citizen.NumberOfKids.Kids * 20;
        }
    }
}
