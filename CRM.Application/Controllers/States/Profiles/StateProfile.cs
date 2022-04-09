namespace CRM.Application.Controllers.States.Profiles
{
    using AutoMapper;
    using Dto;
    using CRM.Domain.States.Objects.Entities;

    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDto>();

            CreateMap<State, StateListDto>();
        }
    }
}
