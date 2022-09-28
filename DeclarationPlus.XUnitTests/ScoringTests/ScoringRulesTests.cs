using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Core.Scoring.Rules.Accept;

namespace DeclarationPlus.XUnitTests
{
    public class ScoringRulesTests
    {
        [Fact]
        public void Citizen_Age_Is_70_CitizenAgeMusteBeBelow70_Rule_IsNotSatisfied()
        {
            var dec = GivenDeclaration().WithCitizen(
                c => c.WithAge(70))
                .Build();

            var rule = new CitizenAgeMusteBeBelow70();
            var ruleCheckResult = rule.IsSatisfiedBy(dec);

            ruleCheckResult.Should().BeFalse();
        }
    }
}