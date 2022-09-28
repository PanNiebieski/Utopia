using DeclarationPlus.Core.Scoring.Rules.Accept;
using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Core.Scoring.Rules.SocialScore;

namespace DeclarationPlus.XUnitTests
{
    public class SocialScoreTests
    {

        [Fact]
        public void Citizen_With_4_Kids_ShouldHave100Points_With_KidsScoringSocialScore()
        {
            var dec = GivenDeclaration().WithCitizen(
                c => c.WithKids(4))
                .Build();

            var rule = new KidsScoringSocialScore();
            var ruleCheckResult = rule.AddOrLowerPoints(dec);

            ruleCheckResult.Should().Be(100);
        }
    }
}