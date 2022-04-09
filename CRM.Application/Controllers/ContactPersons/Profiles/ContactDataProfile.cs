using AutoMapper;
using CRM.Application.Controllers.ContactPersons.Dto;
using CRM.Domain.ContactPersons.Objects.ValueObjects;

namespace CRM.Application.Controllers.ContactPersons.Profiles
{
    public class ContactDataProfile : Profile
    {
        public ContactDataProfile()
        {
            CreateMap<ContactData, ContactDataDto>();
        }
    }
}