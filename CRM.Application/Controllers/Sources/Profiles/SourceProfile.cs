namespace CRM.Application.Controllers.Sources.Profiles
{
    using AutoMapper;
    using Dto;
    using CRM.Domain.Sources.Objects.Entities;

    public class SourceProfile : Profile
    {
        public SourceProfile()
        {
            CreateMap<Source, SourceDto>();

            CreateMap<Source, SourceListDto>();
        }
    }
}
