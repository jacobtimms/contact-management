namespace ContactManagementSolution.Features.Contact.Delete.V1;

public sealed record Request
{
    public Guid Id { get; init; }
}

public sealed record Response
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}