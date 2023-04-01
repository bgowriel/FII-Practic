using EstateWebManager.API.Dto;
using EstateWebManager.Domain.Models;
using AutoMapper;
using EstateWebManager.Application.Commands;

namespace EstateWebManager.API.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaPutPostDto, InsertArea>();
            CreateMap<Area, AreaGetDto>();
        }
    }
}
