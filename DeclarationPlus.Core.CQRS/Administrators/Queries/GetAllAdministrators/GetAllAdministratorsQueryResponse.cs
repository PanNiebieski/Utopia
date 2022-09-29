using DeclarationPlus.Core.Mapper.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Administrators.Queries.GetAllAdministrators
{
    public class GetAllAdministratorsQueryResponse
    {
        public ImmutableArray<AdministratorDto> List { get; set; }

        public GetAllAdministratorsQueryResponse(ImmutableArray<AdministratorDto> list)
        {
            List = list;
        }
    }
}
