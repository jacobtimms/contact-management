namespace ContactManagementSolution.Tests.Features.Contact.Create.V1;

using System.Net;
using ContactManagementSolution.Features.Contact;
using ContactManagementSolution.Features.Contact.Create.V1;
using FakeItEasy;
using FastEndpoints;
using FluentValidation.TestHelper;
using Shouldly;

public class Tests()
{
    [Fact(Skip = "Disabled until LinkGenerator can be faked")]
    public async Task CreateContact_ReturnsOk()
    {
        // Arrange
        var fakeContactService = A.Fake<IContactService>();
        A.CallTo(() => fakeContactService.CreateContactAsync(A<Entities.Contact>.Ignored, A<CancellationToken>.Ignored))
            .Returns(TestData.Contact);
        
        var ep = Factory.Create<Endpoint>(fakeContactService);
        
        var request = new Request { Name = TestData.Contact.Name, Email = TestData.Contact.Email, PhoneNumber = TestData.Contact.PhoneNumber };

        // Act
        await ep.HandleAsync(request, default);
        var rsp = ep.Response;

        // Assert
        ep.HttpContext.Response.StatusCode.ShouldBe((int)HttpStatusCode.Created);
        
        rsp.ShouldNotBeNull();
        rsp.Id.ShouldBe(TestData.Contact.Id);
    }
    
    [Fact]
    public void CreateContact_RequestValidator_NoError_ValidRequest()
    {
        // Arrange
        var request = new Request 
        { 
            Name = "John Doe", 
            Email = "john.doe@example.com", 
            PhoneNumber = "123-456-7890" 
        };
            
        // Act
        var result = new Validator().TestValidate(request);
            
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void CreateContact_RequestValidator_ReturnError_InvalidEmailFormat()
    {
        // Arrange
        var request = new Request { Email = "invalid_email" };
        
        // Act
        var result = new Validator().TestValidate(request);
        
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("'Email' is not a valid email address.");
    }
}