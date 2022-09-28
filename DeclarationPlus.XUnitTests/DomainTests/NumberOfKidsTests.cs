using DeclarationPlus.Domain.ValueObjects.CitizenValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.DomainTests
{
    public class NumberOfKidsTests
    {

        [Fact]
        public void NumberOfKids_CanNotBeLessThanZero()
        {
            Action act = () => new NumberOfKids
            (
                -1
            );


            act
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("NumberOfKids can't be less than zero");
        }
    }
}
