using System.Collections.Generic;
using Api.Responses.Abstractions;
using CRM.Domain.ContactPersons.Objects.Entities;

namespace CRM.Application.Controllers.ContactPersons.Actions.GetList
{
    public class GetListContactPersonResponse : IResponse
    {
        public List<ContactPerson> ContactPersons { get; set; }
    }
}
