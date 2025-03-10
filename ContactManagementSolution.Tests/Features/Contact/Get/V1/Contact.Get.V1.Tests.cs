namespace ContactManagementSolution.Tests.Features.Contact.Get.V1;

using ContactManagementSolution.Features.Contact;
using ContactManagementSolution.Features.Contact.Get.V1;
using FakeItEasy;
using FastEndpoints;
using Shouldly;
using System.Net;

public class Tests()
{
    [Fact]
    public async Task GetContact_ReturnsOk_ResponseDataCountMatches()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.GetAllContactsAsync(A<CancellationToken>.Ignored))
            .Returns(TestData.Contacts);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);

        // Act
        await ep.HandleAsync(default);
        var rsp = ep.Response;

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        
        rsp.ShouldNotBeNull();
        rsp.Contacts.Count().ShouldBe(TestData.Contacts.Count);
    }
}