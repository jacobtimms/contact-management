namespace ContactManagementSolution.Features.Contact.Create.V1;

using FastEndpoints;
using FluentValidation;
using Shared.Constants;

public sealed record Request
{
    public string Name { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
}

public sealed record Response
{
    public Guid Id { get; set; }
}

public sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => x.Email != null);

        RuleFor(x => x.PhoneNumber)
            .Matches(Constants.ValidPhoneNumber())
            .When(x => x.PhoneNumber != null);
    }
}