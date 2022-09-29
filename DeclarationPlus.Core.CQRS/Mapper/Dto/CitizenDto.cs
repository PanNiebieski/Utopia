using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Mapper.Dto
{
    public class CitizenDto
    {
        public NameDto Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int NumberOfKids { get; set; }
    }
}
