using Api.Requests.Abstractions;

namespace CRM.Application.Controllers.Contacts.Actions.GetList
{
    public class GetContactListForManagerRequest : IRequest<GetContactListForManagerResponse>
    {
        public int Offset { get; set; }

        public int Count { get; set; }
    }
}
