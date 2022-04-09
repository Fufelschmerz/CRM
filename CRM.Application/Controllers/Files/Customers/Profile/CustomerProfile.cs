namespace CRM.Application.Controllers.Files.Customers.Profile
{
    using System.Linq;
    using CRM.Domain.Customers.Objects.Entities;
    using AutoMapper;
    using Dto;

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.LastDateContact, opt =>
                    opt.MapFrom(x => x.OrderedContacts.FirstOrDefault().CreationOfDate))
                .ForMember(dest=>dest.ManagerName, opt => 
                    opt.MapFrom(x=>x.OrderedContacts.FirstOrDefault().Manager.Name))
                .ForMember(dest=>dest.ContactComment, opt=>
                    opt.MapFrom(x=>x.OrderedContacts.FirstOrDefault().Comment));
        }
    }
}