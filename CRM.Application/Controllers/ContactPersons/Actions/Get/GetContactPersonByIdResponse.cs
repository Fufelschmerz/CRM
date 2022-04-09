namespace CRM.Application.Controllers.ContactPersons.Actions.Get
{
    using Api.Responses.Abstractions;
    using Dto;

    public class GetContactPersonByIdResponse : IResponse
    {
        public ContactPersonDto ContactPerson { get; set; }
    }
}