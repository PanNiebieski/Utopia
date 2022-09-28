using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects
{
    public enum DeclarationStatus
    {
        New = 0,
        EvaluatedByMachine = 1,
        AcceptedByJudge = 2,
        Rejected = 5
    }
}
