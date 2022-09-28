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
    public class DeclarationScoringResult : ValueObject<Citizen>
    {
        public DeclarationScoringStatus DeclarationScoringStatus { get; set; }

        public DeclarationSocialScore DeclarationSocialScore { get; set; }

        public DeclarationScoringResult(DeclarationScoringStatus status, DeclarationSocialScore score)
        {
            if (status == null)
                throw new ArgumentException("Name cannot be null");
            if (score == default)
                throw new ArgumentException("Birthdate cannot be empty");

            DeclarationScoringStatus = status;
            DeclarationSocialScore = score;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>
            {
                DeclarationScoringStatus,
                DeclarationSocialScore,
            };
        }
    }
}
