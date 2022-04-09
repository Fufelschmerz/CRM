namespace CRM.Application.Controllers.ContactPersons.Actions.Get
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class GetContactPersonByIdRequest : IRequest<GetContactPersonByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetContactPersonByIdRequestValidator : AbstractValidator<GetContactPersonByIdRequest>
    {
        public GetContactPersonByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}