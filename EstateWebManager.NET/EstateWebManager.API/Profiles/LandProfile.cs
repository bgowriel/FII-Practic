using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.Application.Commands;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.API.Profiles
{
    public class LandProfile : Profile
    {
        public LandProfile()
        {
            CreateMap<Land, LandGetDto>();
            CreateMap<LandPutPostDto, InsertLand>();
        }
    }
}
