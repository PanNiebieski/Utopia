using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.Scoring
{
    public class DeclarationScoringFlag : ValueObject<DeclarationScoringFlag>
    {

        public DeclarationFlag Flag { get; set; }

        public string RejectExplanation { get; set; }
        public string WarringExplanation { get; set; }

        public DeclarationScoringFlag(DeclarationFlag score,
            string rejectexlanation)
        {
            Flag = score;
            RejectExplanation = rejectexlanation;
        }

        public DeclarationScoringFlag(DeclarationFlag score,
    string rejectExplanation, string warringExplanation)
        {
            Flag = score;
            RejectExplanation = rejectExplanation;
            WarringExplanation = warringExplanation;
        }

        //To satisfy EF Core
        public DeclarationScoringFlag()
        {
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Flag;
            yield return RejectExplanation;
        }

        public static DeclarationScoringFlag Green()
        {
            return new DeclarationScoringFlag(DeclarationFlag.Green, "", "");
        }

        public static DeclarationScoringFlag Red(string[] messages)
        {
            return new DeclarationScoringFlag(DeclarationFlag.Red, string.Join(Environment.NewLine, messages), "");
        }

        public static DeclarationScoringFlag Yellow(string[] messages)
        {
            return new DeclarationScoringFlag(DeclarationFlag.Yellow, "", string.Join(Environment.NewLine, messages));
        }

        public bool IsRed()
        {
            return Flag == DeclarationFlag.Red;
        }

        public bool IsYellow()
        {
            return Flag == DeclarationFlag.Yellow;
        }

        public bool IsGreen()
        {
            return Flag == DeclarationFlag.Green;
        }
    }
}
