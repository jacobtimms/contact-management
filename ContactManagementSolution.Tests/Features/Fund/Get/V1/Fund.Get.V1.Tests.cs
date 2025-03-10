namespace ContactManagementSolution.Tests.Features.Fund.Get.V1;

using System.Net;
using ContactManagementSolution.Features.Fund;
using ContactManagementSolution.Features.Fund.Get.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;

public class Tests()
{
    [Fact]
    public async Task GetFunds_ReturnsOk_ResponseDataCountMatches()
    {
        // Arrange
        var fakeContactService = A.Fake<IFundService>();
        A.CallTo(() => fakeContactService.GetAllFundsAsync(A<CancellationToken>.Ignored))
            .Returns(TestData.Funds);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);

        // Act
        await ep.HandleAsync(default);
        var rsp = ep.Response;

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        
        rsp.ShouldNotBeNull();
        rsp.Funds.Count().ShouldBe(TestData.Funds.Count);
    }
}