using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.CitizenValues
{
    public class NumberOfKids : ValueObject<NumberOfKids>, IComparable<NumberOfKids>
    {
        private readonly int kids;

        public int Kids
        {
            get { return kids; }
        }

        public NumberOfKids(int kids)
        {
            this.kids = kids;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return kids;
        }

        public static bool operator >(NumberOfKids one, NumberOfKids two) => one.CompareTo(two) > 0;

        public static bool operator <(NumberOfKids one, NumberOfKids two) => one.CompareTo(two) < 0;

        public static bool operator >=(NumberOfKids one, NumberOfKids two) => one.CompareTo(two) >= 0;

        public static bool operator <=(NumberOfKids one, NumberOfKids two) => one.CompareTo(two) <= 0;


        public int CompareTo(NumberOfKids other)
        {
            return kids.CompareTo(other.kids);
        }
    }
}

