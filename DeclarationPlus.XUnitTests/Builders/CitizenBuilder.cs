using Common.Domain;
using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.Builders
{
    public class CitizenBuilder
    {
        private Name name = new Name("Jan", "B");

        private DateTime birthDate = AppTime.Now().AddYears(-34);

        private NumberOfKids numberOfKids = new NumberOfKids(0);


        public static CitizenBuilder GivenBuilder() => new CitizenBuilder();

        public CitizenBuilder WithAge(int age)
        {
            this.birthDate = AppTime.Now().AddYears(-1 * age);
            return this;
        }

        public CitizenBuilder BornOn(DateTime birthDate)
        {
            this.birthDate = birthDate;
            return this;
        }

        public CitizenBuilder WithKids(int numberofkids)
        {
            this.numberOfKids = new NumberOfKids(numberofkids);
            return this;
        }

        public Citizen Build()
        {
            return new Citizen
            (
                name,
                birthDate,
                numberOfKids
            );
        }
    }
}
