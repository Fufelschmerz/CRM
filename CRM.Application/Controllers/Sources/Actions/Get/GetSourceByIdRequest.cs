namespace CRM.Application.Controllers.Sources.Actions.Get
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class GetSourceByIdRequest : IRequest<GetSourceByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetSourceByIdRequestValidator : AbstractValidator<GetSourceByIdRequest>
    {
        public GetSourceByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
