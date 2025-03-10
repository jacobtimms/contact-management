namespace ContactManagementSolution.Tests.Features.Contact.Delete.V1;

using ContactManagementSolution.Features.Contact;
using ContactManagementSolution.Features.Contact.Delete.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests
{
    [Fact]
    public async Task DeleteContact_ReturnsOkNoContent_WhenContactExists()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.DeleteContactAsync(A<Entities.Contact>.Ignored, A<CancellationToken>.Ignored))
            .Returns(Task.CompletedTask);

        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var req = new Request { Id = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteContact_ReturnsNotFound_WhenContactDoesNotExist()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.GetContactByIdAsync(A<Guid>.That.Matches(id => id ==TestData.Contact.Id), A<CancellationToken>.Ignored))
            .Returns<Entities.Contact?>(null);
        A.CallTo(() => fakeContactService.DeleteContactAsync(A<Entities.Contact>.Ignored, A<CancellationToken>.Ignored))
            .Returns(Task.CompletedTask);

        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var req = new Request { Id = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
    }
}