using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.Asserts
{
    public class DeclarationAssert:
        ReferenceTypeAssertions<Declaration, DeclarationAssert>
    {
        public DeclarationAssert(Declaration dec)
            : base(dec)
        {

        }

        public AndConstraint<DeclarationAssert> BeInStatus(DeclarationStatus expectedStatus)
        {
            Subject.Status.Should().Be(expectedStatus);
            return new AndConstraint<DeclarationAssert>(this);
        }

        public AndConstraint<DeclarationAssert> BeAccepted()
        {
            return BeInStatus(DeclarationStatus.AcceptedByJudge);
        }


        public AndConstraint<DeclarationAssert> BeRejected()
        {
            return BeInStatus(DeclarationStatus.Rejected);
        }

        public AndConstraint<DeclarationAssert> BeNew()
        {
            return BeInStatus(DeclarationStatus.New);
        }

        public AndConstraint<DeclarationAssert> BeEvaluatedByMachine()
        {
            return BeInStatus(DeclarationStatus.EvaluatedByMachine);
        }

        public AndConstraint<DeclarationAssert> ScoreIsNull()
        {
            Subject?.Result.DeclarationScoringStatus.Should().BeNull();
            return new AndConstraint<DeclarationAssert>(this);
        }

        public AndConstraint<DeclarationAssert> FlagIs(DeclarationMachineScore expectedScore)
        {
            Subject?.Result.DeclarationScoringStatus.Should().Be(expectedScore);
            return new AndConstraint<DeclarationAssert>(this);
        }

        public AndConstraint<DeclarationAssert> HaveRedScore()
        {
            return FlagIs(DeclarationMachineScore.Red);
        }

        public AndConstraint<DeclarationAssert> HaveGreenScore()
        {
            return FlagIs(DeclarationMachineScore.Green);
        }

        public AndConstraint<DeclarationAssert> HaveYellowScore()
        {
            return FlagIs(DeclarationMachineScore.Yellow);
        }

        protected override string Identifier => "CallForSpeechAssert";
    }
}

