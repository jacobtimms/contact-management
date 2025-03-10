namespace ContactManagementSolution.Tests.Features.Fund.AssignContact.V1;

using ContactManagementSolution.Features.Fund;
using ContactManagementSolution.Features.Fund.AssignContact.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests()
{
    [Fact]
    public async Task AssignContact_ReturnsOkNoContent_WhenSuccessful()
    {
        // Arrange
        var fakeFundService = A.Fake<IFundService>();
        A.CallTo(() => fakeFundService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.ContactExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.FundContactExistsAsync(A<Guid>.Ignored, A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(false);

        var ep = Factory.Create<Endpoint>(fakeFundService);
        
        var req = new Request { Id = TestData.Fund.Id, ContactId = TestData.Contact.Id };

        // Act
        await ep.HandleAsync(req, default);

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task AssignContact_ReturnsNotFound_WhenContactDoesNotExist()
    {
        // Arrange
        var fakeFundService = A.Fake<IFundService>();
        A.CallTo(() => fakeFundService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.ContactExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(false);

        var ep = Factory.Create<Endpoint>(fakeFundService);
        
        var req = new Request { Id = TestData.Fund.Id, ContactId = TestData.Contact.Id };

        // Act
        await Should.ThrowAsync<ValidationFailureException>(async () => await ep.HandleAsync(req, default));

        // Assert
        ep.ValidationFailures.ShouldContain(f => f.ErrorMessage == "Contact not found");
    }

    [Fact]
    public async Task AssignContact_ReturnsBadRequest_WhenContactAlreadyAssigned()
    {
        // Arrange
        var fakeFundService = A.Fake<IFundService>();
        A.CallTo(() => fakeFundService.FundExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.ContactExistsAsync(A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);
        A.CallTo(() => fakeFundService.FundContactExistsAsync(A<Guid>.Ignored, A<Guid>.Ignored, A<CancellationToken>.Ignored))
            .Returns(true);

        var ep = Factory.Create<Endpoint>(fakeFundService);
        
        var req = new Request { Id = TestData.Fund.Id, ContactId = TestData.Contact.Id };

        // Act
        await Should.ThrowAsync<ValidationFailureException>(async () => await ep.HandleAsync(req, default));

        // Assert
        ep.ValidationFailures.ShouldContain(f => f.ErrorMessage == "Contact already assigned to the fund");
    }
}