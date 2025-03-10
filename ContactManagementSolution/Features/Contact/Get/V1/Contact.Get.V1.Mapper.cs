﻿namespace ContactManagementSolution.Features.Contact.Get.V1;

using Entities;
using FastEndpoints;

public sealed class Mapper : ResponseMapper<Response, IEnumerable<Contact>>
{
    public override Response FromEntity(IEnumerable<Contact> e)
    {
        return new Response
        {
            Contacts = e.Select(record => new ContactData
            {
                Id = record.Id,
                Name = record.Name,
                Email = record.Email,
                PhoneNumber = record.PhoneNumber
            })
        };
    }

    public override Task<Response> FromEntityAsync(IEnumerable<Contact> e, CancellationToken ct = default)
    {
        return Task.FromResult(FromEntity(e));
    }
}