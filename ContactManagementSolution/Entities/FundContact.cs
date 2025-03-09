namespace ContactManagementSolution.Entities;

public class FundContact
{
    public Guid FundId { get; set; }
    public Fund Fund { get; set; }

    public Guid ContactId { get; set; }
    public Contact Contact { get; set; }
}