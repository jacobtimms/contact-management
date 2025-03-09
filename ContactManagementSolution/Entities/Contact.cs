namespace ContactManagementSolution.Entities;

public class Contact
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Email { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public ICollection<FundContact> FundContacts { get; set; }
}