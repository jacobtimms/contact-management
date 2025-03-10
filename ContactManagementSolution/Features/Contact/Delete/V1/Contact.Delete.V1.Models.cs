namespace ContactManagementSolution.Features.Contact.Delete.V1;

public sealed record Request
{
    public Guid Id { get; init; }
}