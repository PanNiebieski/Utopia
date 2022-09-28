using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.Ids
{
    public class DeclarationId : ValueObject<DeclarationId>
    {
        public int Value { get; set; }

        public DeclarationId(int value)
        {
            Value = value;
        }

        public DeclarationId()
        {

        }

        public static AdministratorId Empty()
        {
            return new AdministratorId(0);
        }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
