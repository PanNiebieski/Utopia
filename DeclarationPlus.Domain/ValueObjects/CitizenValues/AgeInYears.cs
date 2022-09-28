using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.CitizenValues
{
    public class AgeInYears : ValueObject<AgeInYears>, IComparable<AgeInYears>
    {
        private readonly int age;

        public int Age
        {
            get { return age; }
        }

        public AgeInYears(int age)
        {
            this.age = age;
        }

        public static AgeInYears Between(DateTime start, DateTime end)
        {
            return new AgeInYears(end.Year - start.Year);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return age;
        }

        public static bool operator >(AgeInYears one, AgeInYears two) => one.CompareTo(two) > 0;

        public static bool operator <(AgeInYears one, AgeInYears two) => one.CompareTo(two) < 0;

        public static bool operator >=(AgeInYears one, AgeInYears two) => one.CompareTo(two) >= 0;

        public static bool operator <=(AgeInYears one, AgeInYears two) => one.CompareTo(two) <= 0;


        public int CompareTo(AgeInYears other)
        {
            return age.CompareTo(other.age);
        }
    }

    public static class AgeInYearsExtensions
    {
        public static AgeInYears Years(this int age) => new AgeInYears(age);
    }
}
