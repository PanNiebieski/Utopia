using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.Scoring
{
    public class DeclarationScoringStatus : ValueObject<DeclarationScoringStatus>
    {

        public DeclarationMachineScore Score { get; set; }

        public string RejectExplanation { get; set; }
        public string WarringExplanation { get; set; }

        public DeclarationScoringStatus(DeclarationMachineScore score,
            string rejectexlanation)
        {
            Score = score;
            RejectExplanation = rejectexlanation;
        }

        public DeclarationScoringStatus(DeclarationMachineScore score,
    string rejectExplanation, string warringExplanation)
        {
            Score = score;
            RejectExplanation = rejectExplanation;
            WarringExplanation = warringExplanation;
        }

        //To satisfy EF Core
        public DeclarationScoringStatus()
        {
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Score;
            yield return RejectExplanation;
        }

        public static DeclarationScoringStatus Green()
        {
            return new DeclarationScoringStatus(DeclarationMachineScore.Green, "", "");
        }

        public static DeclarationScoringStatus Red(string[] messages)
        {
            return new DeclarationScoringStatus(DeclarationMachineScore.Red, string.Join(Environment.NewLine, messages), "");
        }

        public static DeclarationScoringStatus Yellow(string[] messages)
        {
            return new DeclarationScoringStatus(DeclarationMachineScore.Yellow, "", string.Join(Environment.NewLine, messages));
        }

        public bool IsRed()
        {
            return Score == DeclarationMachineScore.Red;
        }

        public bool IsYellow()
        {
            return Score == DeclarationMachineScore.Yellow;
        }

        public bool IsGreen()
        {
            return Score == DeclarationMachineScore.Green;
        }
    }
}
