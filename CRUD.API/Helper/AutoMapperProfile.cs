
using AutoMapper;

using CRUD.API.Core.Domain;
using CRUD.API.Core.Dto;

namespace CRUD.API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForDetailDto>();
            CreateMap<User, UserForListDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
