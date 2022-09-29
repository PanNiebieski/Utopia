using Common.Domain.Ddd;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DeclarationPlus.Domain.ValueObjects.Scoring
{
    public class DeclarationMachineResult : ValueObject<Citizen>
    {
        public DeclarationScoringFlag ScoringFlag { get; set; }

        public DeclarationSocialScore SocialScore { get; set; }

        public DeclarationMachineResult(DeclarationScoringFlag status, DeclarationSocialScore score)
        {
            if (status == null)
                throw new ArgumentException("Name cannot be null");
            if (score == default)
                throw new ArgumentException("Birthdate cannot be empty");

            ScoringFlag = status;
            SocialScore = score;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>
            {
                ScoringFlag,
                SocialScore,
            };
        }
    }
}
