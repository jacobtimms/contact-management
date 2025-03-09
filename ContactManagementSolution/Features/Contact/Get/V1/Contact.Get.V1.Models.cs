namespace ContactManagementSolution.Features.Contact.Get.V1;

public sealed record Response
{
    public required IEnumerable<ContactInfo> Contacts { get; set; }
}

public sealed record ContactInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}