    using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.Application.Commands;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.API.Profiles
{
    public class FlatProfile : Profile
    {
        public FlatProfile()
        {
            CreateMap<Flat, FlatGetDto>();
            CreateMap<FlatPutPostDto, InsertFlat>();
        }
    }
}
