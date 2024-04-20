using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;
using Shared.DataTransferObjects;
namespace Cafe_management_system
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForAuthenticationDto, User>();
            CreateMap<User, UserDto>()
                .ForCtorParam("role", opts => opts.MapFrom(src => src.Role))
                .ForCtorParam("id", opts => opts.MapFrom(src => src.userId));
            CreateMap<Role, RoleDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
