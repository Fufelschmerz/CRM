namespace CRM.Application.Controllers.Contacts.Profile
{
    using Dto;
    using CRM.Domain.Contacts.Objects.Entities;
    using AutoMapper;

    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>();

            CreateMap<Contact, ContactListDto>().ForMember(dest => dest.ContactDataType, opt=> opt.MapFrom(x=>x.ContactData.ContactDataType));
        }
    }
}