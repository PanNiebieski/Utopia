using DeclarationPlus.Core.Scoring;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;

namespace DeclarationPlus.XUnitTests.DomainTests
{
    public class DeclarationTests
    {
        private readonly ScoringRulesFactory scoringRulesFactory = new ScoringRulesFactory();

        [Fact]
        public void NewDeclaration_IsCreatedIn_NewStatus_AndNullScore()
        {
            var dec = GivenDeclaration()
                .WithCitizen(citizen => citizen.WithAge(25))
                .Build();

            dec
                .Should()
                .BeNew()
                .And
                .ScoreIsNull();
        }

        [Fact]
        public void ValidDeclaration_EvaluationScore_IsGreen()
        {
            var dec = GivenDeclaration()
                .WithCitizen(citizen => citizen.WithAge(31).WithKids(2))
                .Build();

            dec.Evaluate(scoringRulesFactory.DefaultSet);

            dec
                .Should()
                .BeEvaluatedByMachine()
                .And
                .HaveGreenScore();
        }

        [Fact]
        public void InvalidDeclaration_EvaluationScore_IsRed()
        {
            var dec = GivenDeclaration()
                .WithCitizen(citizen => citizen.WithAge(90).WithKids(0))
                .Build();

            dec.Evaluate(scoringRulesFactory.DefaultSet);

            dec
                .Should()
                .BeRejected()
                .And
                .HaveRedScore();
        }

        [Fact]
        public void Declaration_InStatusNew_EvaluatedGreen_CanBeRejected()
        {
            int terriotriumId = 8888;

            var dec = GivenDeclaration()
                .WithCitizen(speaker => speaker.WithAge(31))
                .Evaluated()
                .WithTerritory(ter => ter.WithId(terriotriumId))
                .Build();

            var administrator = GiveAdministrator().
                WithTerritory(ter => ter.WithId(terriotriumId))
                .Build();

            dec.Reject(administrator);

            dec
            .Should()
            .BeRejected()
            .And.HaveGreenScore();
        }

        [Fact]
        public void Declaration_InStatusNew_EvaluatedGreen_CanNOTBeAccepted()
        {
            int catid = 8888;

            var administrator = GiveAdministrator()
                .WithTerritory(ter => ter.WithId(catid))
                .Build();

            var dec = GivenDeclaration()
                .WithTerritory(ter => ter.WithId(catid))
                .WithAdministrator(administrator)
                .Build();

            Action act = () => dec.Accept(administrator);

            act
             .Should()
             .Throw<ApplicationException>()
             .WithMessage("Cannot accept application before scoring");
        }

        [Fact]
        public void Declaration_Rejected_CannotBeRejectedAgain()
        {
            int terrid = 8888;

            var administrator = GiveAdministrator()
                .WithTerritory(ter => ter.WithId(terrid))
                .Build();

            var dec = GivenDeclaration()
                .WithTerritory(ter => ter.WithId(terrid))
                .WithAdministrator(administrator)
                .Rejected()
                .Build();

            Action act = () => dec.Reject(administrator);

            act
             .Should()
             .Throw<ApplicationException>()
             .WithMessage("Cannot reject application that is already accepted or rejected");
        }

        [Fact]
        public void Declaration_Rejected_CannotBeAccepted()
        {
            int terrid = 8888;

            var administrator = GiveAdministrator()
                .WithTerritory(ter => ter.WithId(terrid))
                .Build();

            var dec = GivenDeclaration()
                .WithTerritory(ter => ter.WithId(terrid))
                .WithAdministrator(administrator)
                .Rejected()
                .Build();

            Action act = () => dec.Accept(administrator);

            act
             .Should()
             .Throw<ApplicationException>()
             .WithMessage("Cannot accept application that is already rejected");
        }

        [Fact]
        public void Declaration_Accepted_CannotBeRejected()
        {
            int terrid = 8888;

            var administrator = GiveAdministrator()
                .WithTerritory(ter => ter.WithId(terrid))
                .Build();

            var dec = GivenDeclaration()
                .WithTerritory(ter => ter.WithId(terrid))
                .WithAdministrator(administrator)
                .Rejected()
                .Build();

            Action act = () => dec.Reject(administrator);

            act
             .Should()
             .Throw<ApplicationException>()
             .WithMessage("Cannot reject application that is already accepted or rejected");
        }


    }
}