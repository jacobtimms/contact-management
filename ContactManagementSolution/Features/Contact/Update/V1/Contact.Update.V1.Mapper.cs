namespace ContactManagementSolution.Features.Contact.Update.V1;

using FastEndpoints;

public sealed class Mapper : RequestMapper<Request, Entities.Contact>
{
    public static void ToEntity(Request r, Entities.Contact e)
    {
        e.Name = r.Name ?? e.Name;
        e.Email = r.Email ?? e.Email;
        e.PhoneNumber = r.PhoneNumber ?? e.PhoneNumber;
    }
}