using Common.Domain;
using DeclarationPlus.Domain.Ddd;
using DeclarationPlus.Domain.Scoring;
using DeclarationPlus.Domain.ValueObjects;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using DeclarationPlus.Domain.ValueObjects.Ids;
using DeclarationPlus.Domain.ValueObjects.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeclarationPlus.Domain.Entities
{
    public class Declaration : Entity<DeclarationId>
    {
        public Citizen Citizen { get; set; }

        public Territory Territory { get; set; }

        public DeclarationMachineResult? EvaluationResult { get; set; }

        public Decision? FinalDecision { get; set; }

        public DeclarationStatus Status { get; private set; }

        public Declaration(Citizen citizen,
               DeclarationId declarationId, Territory territory)
        {
            if (citizen == null)
                throw new ArgumentException("citizen cannot be null");
            if (declarationId == null)
                throw new ArgumentException("declarationId cannot be null");
            if (territory == null)
                throw new ArgumentException("territory cannot be null");


            Id = declarationId;
            Citizen = citizen;
            Territory = territory;
        }

        public Declaration(Citizen citizen, Territory territory)
        {
            if (citizen == null)
                throw new ArgumentException("citizen cannot be null");
            if (territory == null)
                throw new ArgumentException("territory cannot be null");

            Citizen = citizen;
            Territory = territory;
        }

        //needed for automapper
        //need for EF Core propably
        public Declaration()
        {

        }

        public void Evaluate(ScoringRules rules)
        {
            if (Status != DeclarationStatus.New)
            {
                throw new ApplicationException("Cannot accept application that isn't new");
            }

            EvaluationResult = rules.Evaluate(this);

            if (!EvaluationResult.ScoringFlag.IsRed())
            {
                Status = DeclarationStatus.EvaluatedByMachine;
            }
            else
            {
                Status = DeclarationStatus.Rejected;
            }
        }

        public void Reject(Administrator decisionBy)
        {
            if (Status == DeclarationStatus.Rejected ||
                Status == DeclarationStatus.AcceptedByAdministrator)
            {
                throw new ApplicationException("Cannot reject application that is already accepted or rejected");
            }

            if (!decisionBy.CanAccept(this.Territory.Id))
            {
                throw new ApplicationException("Administrator is from diffrent Territory. Can't Accept");
            }

            Status = DeclarationStatus.Rejected;
            FinalDecision = new Decision(AppTime.Now(), decisionBy);
        }

        public void Accept(Administrator decisionBy)
        {
            if (Status == DeclarationStatus.AcceptedByAdministrator)
            {
                throw new ApplicationException("You already Accepted this Declaration");
            }

            if (Status == DeclarationStatus.Rejected)
            {
                throw new ApplicationException("Cannot accept application that is already rejected");
            }

            if (EvaluationResult == null)
            {
                throw new ApplicationException("Cannot accept application before scoring");
            }

            if (!decisionBy.CanAccept(this.Territory.Id))
            {
                throw new ApplicationException("Administrator is from diffrent territory. Can't Accept");
            }

            Status = DeclarationStatus.AcceptedByAdministrator;
            FinalDecision = new Decision(AppTime.Now(), decisionBy);
        }
    }
}
