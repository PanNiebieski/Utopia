using Common.Domain.Ddd;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects
{
    public class Decision : ValueObject<Decision>
    {
        public DateTime DecisionDate { get; init; }
        public AdministratorId DecisionBy { get; init; }

        public Decision(DateTime decisionDate, Administrator decisionBy)
            : this(decisionDate, decisionBy.Id)
        {
        }


        public Decision(DateTime decisionDate, AdministratorId decisionBy)
        {
            DecisionDate = decisionDate;
            DecisionBy = decisionBy;
        }

        public Decision()
        {
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return DecisionDate;
            yield return DecisionBy;
        }
    }
}
