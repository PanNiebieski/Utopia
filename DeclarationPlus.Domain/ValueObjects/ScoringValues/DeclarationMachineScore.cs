using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.Scoring
{
    public enum DeclarationMachineScore
    {
        None = 0,
        Red = 1, //Rejected
        Yellow = 2, //WithWarrings
        Green = 3, //AllOkej
    }
}
