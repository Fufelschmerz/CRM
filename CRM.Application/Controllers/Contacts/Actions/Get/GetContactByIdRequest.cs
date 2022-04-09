namespace CRM.Application.Controllers.Contacts.Actions.Get
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class GetContactByIdRequest : IRequest<GetContactByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetContactByIdRequestValidator : AbstractValidator<GetContactByIdRequest>
    {
        public GetContactByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}