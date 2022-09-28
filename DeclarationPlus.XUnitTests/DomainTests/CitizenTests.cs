using DeclarationPlus.Domain.ValueObjects.CitizenValues;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.DomainTests
{
    public class CitizenTests
    {
        [Fact]
        public void Citizen_Born1976_IsAt2021_45YearsOld()
        {
            var customer = GivenCitizen()
                .BornOn(new DateTime(1976, 6, 26))
                .Build();

            var ageAt2019 = customer.AgeInYearsAt(new DateTime(2021, 1, 1));

            ageAt2019.Should().Be(45.Years());
        }

        [Fact]
        public void Citizen_Born1976_IsAt2022_46YearsOld()
        {
            var customer = GivenCitizen()
                .BornOn(new DateTime(1976, 6, 26))
                .Build();

            var ageAt2019 = customer.AgeInYearsAt(new DateTime(2022, 1, 1));

            ageAt2019.Should().Be(46.Years());
        }

        [Fact]
        public void Citizen_Born1976_IsAt2023_47YearsOld()
        {
            var customer = GivenCitizen()
                .BornOn(new DateTime(1976, 6, 26))
                .Build();

            var ageAt2019 = customer.AgeInYearsAt(new DateTime(2023, 1, 1));

            ageAt2019.Should().Be(47.Years());
        }

        [Fact]
        public void Citizen_CannotBeCreatedWithout_Birthdate()
        {
            Action act = () => new Citizen
            (
                new Name("Cezary", "W"), default, new NumberOfKids(1)
            );

            act
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Birthdate cannot be empty");
        }

        [Fact]
        public void Citizen_CannotBeCreatedWithout_NumberOfKids()
        {
            Action act = () => new Citizen
            (
                new Name("Cezary", "W"), new DateTime(1976, 6, 26), null
            );

            act
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Birthdate cannot be empty");
        }

        [Fact]
        public void Citizen_CannotBeCreatedWithout_Name()
        {
            Action act = () => new Citizen
            (
                null, new DateTime(1976, 6, 26), new NumberOfKids(1)
            );

            act
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Birthdate cannot be empty");
        }
    }
}
