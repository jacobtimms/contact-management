namespace ContactManagementSolution.Tests.Features.Contact.GetById.V1;

using ContactManagementSolution.Features.Contact;
using ContactManagementSolution.Features.Contact.GetById.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests()
{
    [Fact]
    public async Task GetContactById_ReturnsOk_ResponseDataMatches()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.GetContactByIdAsync(A<Guid>.That.Matches(id => id == TestData.Contact.Id), A<CancellationToken>.Ignored))
            .Returns(TestData.Contact);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var req = new Request { Id = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);
        var rsp = ep.Response;

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        
        rsp.ShouldNotBeNull();
        rsp.Id.ShouldBe(TestData.Contact.Id);
        rsp.Name.ShouldBe(TestData.Contact.Name);
        rsp.Email.ShouldBe(TestData.Contact.Email);
        rsp.PhoneNumber.ShouldBe(TestData.Contact.PhoneNumber);
    }
    
    [Fact]
    public async Task GetContactById_ReturnsNotFound()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.GetContactByIdAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(Task.FromResult<Entities.Contact?>(null));
        
        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var req = new Request { Id = Guid.NewGuid() };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
    }
}