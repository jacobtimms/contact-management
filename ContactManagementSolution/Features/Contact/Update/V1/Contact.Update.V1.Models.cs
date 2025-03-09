namespace ContactManagementSolution.Features.Contact.Update.V1;

using FastEndpoints;
using FluentValidation;
using Shared.Constants;

public sealed record Request
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
}

public sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .Length(1, 50)
            .When(x => x.Name != null);

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => x.Email != null);

        RuleFor(x => x.PhoneNumber)
            .Matches(Constants.ValidPhoneNumber())
            .When(x => x.PhoneNumber != null);
    }
}