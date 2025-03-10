namespace ContactManagementSolution.Tests.Services.Fund;

using ContactManagementSolution.Features.Fund;
using MockQueryable.Moq;
using Moq;
using Shouldly;

public class FundServiceTests
{
    private readonly Mock<IFundDbContext> _contextMock;
    private readonly FundService _fundService;

    public FundServiceTests()
    {
        _contextMock = new Mock<IFundDbContext>();
        _fundService = new FundService(_contextMock.Object);
    }

    [Fact]
    public async Task FundExistsAsync_ReturnsTrue_WhenFundExists()
    {
        // Arrange
        var fundId = TestData.Funds[0].Id;
        var funds = TestData.GetMockFundsDbSet();
        
        _contextMock.Setup(c => c.Funds).Returns(funds.Object);

        // Act
        var result = await _fundService.FundExistsAsync(fundId);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public async Task FundExistsAsync_ReturnsFalse_WhenFundDoesNotExist()
    {
        // Arrange
        var fundId = Guid.NewGuid();
        var funds = new List<Entities.Fund>().AsQueryable().BuildMockDbSet();
        
        _contextMock.Setup(c => c.Funds).Returns(funds.Object);

        // Act
        var result = await _fundService.FundExistsAsync(fundId);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public async Task GetAllFundsAsync_ReturnsAllFunds()
    {
        // Arrange
        var funds = TestData.GetMockFundsDbSet();
        
        _contextMock.Setup(c => c.Funds).Returns(funds.Object);

        // Act
        var result = await _fundService.GetAllFundsAsync();

        // Assert
        result.ShouldBe(funds.Object);
    }

    [Fact]
    public async Task RemoveFundContactAsync_RemovesFundContact()
    {
        // Arrange
        var fundContact = TestData.FundContact;

        // Act
        await _fundService.RemoveFundContactAsync(fundContact);

        // Assert
        _contextMock.Verify(c => c.DeleteEntityAsync(fundContact, It.IsAny<CancellationToken>()), Times.Once);
    }
}