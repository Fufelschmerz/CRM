namespace CRM.Application.Controllers.Contacts.Actions.Get
{
    using Api.Responses.Abstractions;
    using Dto;

    public class GetContactByIdResponse :IResponse
    {
        public ContactDto Contact { get; set; }
    }
}