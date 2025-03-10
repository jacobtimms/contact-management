namespace ContactManagementSolution.Tests.Features.Fund.RemoveContact.V1;

using Entities;
using ContactManagementSolution.Features.Fund;
using ContactManagementSolution.Features.Fund.RemoveContact.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests()
{
    [Fact]
    public async Task RemoveContact_ReturnsNoContent_WhenSuccessful()
    {
        // Arrange
        var fakeFundService = A.Fake<IFundService>();
        A.CallTo(() => fakeFundService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.ContactExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.GetFundContactAsync(A<Guid>.Ignored, A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(new FundContact());

        var ep = Factory.Create<Endpoint>(fakeFundService);
        
        var req = new Request { Id = TestData.Fund.Id, ContactId = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task RemoveContact_ReturnsNotFound_WhenFundContactDoesNotExist()
    {
        // Arrange
        var fakeFundService = A.Fake<IFundService>();
        A.CallTo(() => fakeFundService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.ContactExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.GetFundContactAsync(A<Guid>.Ignored, A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns<FundContact?>(null);

        var ep = Factory.Create<Endpoint>(fakeFundService);
        
        var req = new Request { Id = TestData.Fund.Id, ContactId = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
    }
}