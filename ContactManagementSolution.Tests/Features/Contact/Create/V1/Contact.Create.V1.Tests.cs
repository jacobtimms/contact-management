namespace ContactManagementSolution.Tests.Features.Contact.Create.V1;

using ContactManagementSolution.Features.Contact.Create.V1;
using FluentValidation.TestHelper;

public class Tests()
{
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
        var res = new Validator().TestValidate(request);
            
        // Assert
        res.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void CreateContact_RequestValidator_ReturnError_InvalidEmailFormat()
    {
        // Arrange
        var req = new Request { Email = "invalid_email" };
        
        // Act
        var res = new Validator().TestValidate(req);
        
        // Assert
        res.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("'Email' is not a valid email address.");
    }
}