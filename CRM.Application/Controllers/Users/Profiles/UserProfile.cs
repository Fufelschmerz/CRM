namespace CRM.Application.Controllers.Users.Profiles
{
    using AutoMapper;
    using Dto;
    using CRM.Domain.Users.Objects.Entities;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ForMember(opt => opt.Login, dest => dest.MapFrom(x => x.Email));

            CreateMap<User, UserListDto>().ForMember(opt => opt.Login, dest => dest.MapFrom(x => x.Email));
        }
    }
}
