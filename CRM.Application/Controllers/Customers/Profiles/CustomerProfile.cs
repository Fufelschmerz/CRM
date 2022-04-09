namespace CRM.Application.Controllers.Customers.Profiles
{
    using Dto;
    using CRM.Domain.Customers.Objects.Entities;
    using AutoMapper;

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();

            CreateMap<Customer, CustomerListDto>();
        }
    }
}