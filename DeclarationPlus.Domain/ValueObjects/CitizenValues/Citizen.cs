using Common.Domain.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Domain.ValueObjects.CitizenValues
{
    public class Citizen : ValueObject<Citizen>
    {
        public DateTime Birthdate { get; init; }

        public Name Name { get; init; }

        public NumberOfKids NumberOfKids { get; init; }


        public Citizen(Name name, DateTime birthdate, NumberOfKids numberOfKids)
        {
            if (name == null)
                throw new ArgumentException("Name cannot be null");
            if (birthdate == default)
                throw new ArgumentException("Birthdate cannot be empty");
            if (numberOfKids == default)
                throw new ArgumentException("NumberOfKids cannot be empty");

            Name = name;
            Birthdate = birthdate;
            NumberOfKids = numberOfKids;
        }

        public AgeInYears AgeInYearsAt(DateTime date)
        {
            return AgeInYears.Between(Birthdate, date);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>
            {
                Name,
                Birthdate,
            };
        }
    }
}
