using AutoMapper;
using CRM.Application.Controllers.ContactPersons.Dto;
using CRM.Domain.ContactPersons.Objects.Entities;

namespace CRM.Application.Controllers.ContactPersons.Profiles
{
    public class ContactPersonProfile : Profile
    {
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonDto>()
                .ForMember(x=>x.ContactData,
                x=>x.MapFrom(y=>y.ContactData));
        }
    }
}