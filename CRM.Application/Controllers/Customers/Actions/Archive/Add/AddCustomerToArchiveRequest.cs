namespace CRM.Application.Controllers.Customers.Actions.Archive.Add
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class AddCustomerToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class AddCustomerToArchiveRequestValidator : AbstractValidator<AddCustomerToArchiveRequest>
    {
        public AddCustomerToArchiveRequestValidator()
        {
            RuleFor(x => x.Id);
        }
    }
}