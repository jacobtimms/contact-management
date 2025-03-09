namespace ContactManagementSolution.Features.Fund.ListContacts.V1;

public sealed record Request
{
    public Guid Id { get; init; }
}

public sealed record Response
{
    public required IEnumerable<ContactData> Contacts { get; set; }
}

public sealed record ContactData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}