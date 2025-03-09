namespace ContactManagementSolution.Entities;

public class Fund
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<FundContact> FundContacts { get; set; }
}