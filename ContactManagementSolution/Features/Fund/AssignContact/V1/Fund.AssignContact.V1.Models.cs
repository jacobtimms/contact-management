namespace ContactManagementSolution.Features.Fund.AssignContact.V1;

using FastEndpoints;
using FluentValidation;

public sealed record Request
{
    public Guid Id { get; init; }
    public Guid ContactId { get; init; }
}

public sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.ContactId)
            .NotNull();
    }
}