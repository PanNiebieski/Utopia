using AutoMapper;
using DeclarationPlus.Core.CQRS.Declarations.Commands.SubmitDeclaration;
using DeclarationPlus.Core.Mapper.Dto;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.Mapper
{


    public class MappingCommands : Profile
    {
        public MappingCommands()
        {


            CreateMap<SubmitDeclarationCommand, Declaration>();


        }

        //public class DeclarationTypeConverter : ITypeConverter<SubmitDeclarationCommand, Declaration>
        //{
        //    public Declaration Convert(SubmitDeclarationCommand source, Declaration destination,
        //        ResolutionContext context)
        //    {



        //        Declaration declaration = new Declaration()
        //    }
        //}


    }
}
