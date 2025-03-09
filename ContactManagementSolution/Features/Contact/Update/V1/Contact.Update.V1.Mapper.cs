namespace ContactManagementSolution.Features.Contact.Update.V1;

using Entities;
using FastEndpoints;

public sealed class Mapper : RequestMapper<Request, Contact>
{
    public static void ToEntity(Request r, Contact e)
    {
        e.Name = r.Name ?? e.Name;
        e.Email = r.Email ?? e.Email;
        e.PhoneNumber = r.PhoneNumber ?? e.PhoneNumber;
    }
}