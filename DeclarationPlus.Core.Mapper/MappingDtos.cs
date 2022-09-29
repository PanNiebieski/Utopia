﻿using AutoMapper;
using DeclarationPlus.Core.Mapper.Dto;
using DeclarationPlus.Domain.Entities;
using DeclarationPlus.Domain.ValueObjects.Ids;
using System.Net;

namespace DeclarationPlus.Core.Mapper
{
    public class MappingDtos : Profile
    {
        public MappingDtos()
        {
            CreateMap<int, TerritoryId>().ConstructUsing(c => new TerritoryId(c));
            CreateMap<TerritoryId, int>().ConstructUsing(c => c.Value);

            CreateMap<Territory, TerritoryDto>()
                .ForMember(s => s.Id, o => o.MapFrom(k => k.Id.Value));

            CreateMap<TerritoryDto, Territory>()
                .ForMember(s => s.Id, o => o.MapFrom(k => new TerritoryId(k.Id)));

        }
    }
}