using Common.Domain;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.Scoring;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Scoring.Rules.Accept
{
    internal class CitizenAgeMusteBeBelow70 : IScoringRejectRule
    {
        public string Message
        {
            get { return ""; }
        }


        public bool IsSatisfiedBy(Declaration dec)
        {
            return dec.Citizen.AgeInYearsAt(AppTime.Now()) < 70.Years();
        }
    }
}
