using DeclarationPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.XUnitTests.Asserts
{
    public static class DeclarationAssertExtension
    {
        public static DeclarationAssert Should(this Declaration dec)
            => new DeclarationAssert(dec);
    }
}
