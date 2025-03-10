namespace ContactManagementSolution.Tests.Features.Contact.Update.V1;

using System.Net;
using ContactManagementSolution.Features.Contact;
using ContactManagementSolution.Features.Contact.Update.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;

public class Tests()
{
    [Fact]
    public async Task UpdateContact_ReturnsOkNoContent()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.GetContactByIdAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(TestData.Contact);
        A.CallTo(() => fakeContactService.UpdateContactAsync(A<Entities.Contact>.Ignored, A<CancellationToken>.Ignored))
            .Returns(Task.CompletedTask);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var req = new Request { Id = TestData.Contact.Id, Email = "NewEmail@test.com" };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NoContent);
    }
}