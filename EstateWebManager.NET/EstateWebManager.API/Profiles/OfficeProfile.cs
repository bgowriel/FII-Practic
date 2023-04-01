using AutoMapper;
using EstateWebManager.API.Dto;
using EstateWebManager.Application.Commands;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.API.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeGetDto>();
            CreateMap<OfficePutPostDto, InsertOffice>();
        }
    }
}
