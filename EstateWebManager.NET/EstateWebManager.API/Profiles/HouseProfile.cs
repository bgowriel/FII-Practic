using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.Application.Commands;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.API.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseGetDto>();
            CreateMap<HousePutPostDto, InsertHouse>();
        }
    }
}
