using DeclarationPlus.Domain.ValueObjects.CitizenValues;

namespace DeclarationPlus.XUnitTests.DomainTests
{
    public class AgeInYearsTests
    {
        [Fact]
        public void AgeInYears_PersonBorn1970_AfterBirthdateIn2019_45()
        {
            var age = AgeInYears.Between
                (new DateTime(1970, 6, 26),
                new DateTime(2019, 11, 28));

            age.Should().Be(49.Years());
        }

        [Fact]
        public void AgeInYears_PersonBorn1970_BeforeBirthdateIn2019_45()
        {
            var age = AgeInYears.Between(new DateTime(1970, 6, 26),
                new DateTime(2019, 5, 28));

            age.Should().Be(49.Years());
        }
    }
}
