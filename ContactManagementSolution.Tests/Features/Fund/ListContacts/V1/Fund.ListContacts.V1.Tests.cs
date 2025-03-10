namespace ContactManagementSolution.Tests.Features.Fund.ListContacts.V1;

using ContactManagementSolution.Features.Fund;
using ContactManagementSolution.Features.Fund.ListContacts.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests()
{
    [Fact]
    public async Task ListFundContacts_ReturnsOk_ResponseDataCountMatches()
    {
        // Arrange
        var fakeContactService = A.Fake<IFundService>();
        A.CallTo(() => fakeContactService.FundExistsAsync(A<Guid>.That.Matches(id => id == TestData.Fund.Id),A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeContactService.ListFundContactsAsync(A<Guid>.That.Matches(id => id == TestData.Fund.Id),A<CancellationToken>.Ignored))
            .Returns(TestData.Contacts);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var request = new Request{ Id = TestData.Fund.Id };

        // Act
        await ep.HandleAsync(request, default);
        var rsp = ep.Response;

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        
        rsp.ShouldNotBeNull();
        rsp.Contacts.Count().ShouldBe(TestData.FundContacts.Count);
    }
    
    [Fact]
    public async Task ListFundContacts_ReturnsNotFound_WhenFundDoesNotExist()
    {
        // Arrange
        var fakeContactService = A.Fake<IFundService>();
        A.CallTo(() => fakeContactService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(false);

        var ep = Factory.Create<Endpoint>(fakeContactService);

        var request = new Request { Id = TestData.Fund.Id };

        // Act
        await ep.HandleAsync(request, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
    }
}