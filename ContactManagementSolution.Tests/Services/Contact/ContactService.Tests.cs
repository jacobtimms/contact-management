namespace ContactManagementSolution.Tests.Services.Contact;

using ContactManagementSolution.Features.Contact;
using Moq;
using Shouldly;

public class ContactServiceTests
{
    private readonly Mock<IContactDbContext> _contextMock;
    private readonly ContactService _contactService;

    public ContactServiceTests()
    {
        _contextMock = new Mock<IContactDbContext>();
        _contactService = new ContactService(_contextMock.Object);
    }

    [Fact]
    public async Task GetContactByIdAsync_ReturnsContact_WhenContactExists()
    {
        // Arrange
        var contact = TestData.Contacts[0];
        var contacts = TestData.GetMockFundsDbSet();
        
        _contextMock.Setup(c => c.Contacts).Returns(contacts.Object);

        // Act
        var result = await _contactService.GetContactByIdAsync(contact.Id);

        // Assert
        result.ShouldBe(contact);
    }

    [Fact]
    public async Task GetContactByIdAsync_ReturnsNull_WhenContactDoesNotExist()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        var contacts = TestData.GetMockFundsDbSet();
        
        _contextMock.Setup(c => c.Contacts).Returns(contacts.Object);

        // Act
        var result = await _contactService.GetContactByIdAsync(contactId);

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public async Task CreateContactAsync_CreatesAndReturnsContact()
    {
        // Arrange
        var contact = TestData.Contacts[0];
        
        _contextMock.Setup(c => c.CreateEntityAsync(contact, It.IsAny<CancellationToken>())).ReturnsAsync(contact);

        // Act
        var result = await _contactService.CreateContactAsync(contact);

        // Assert
        result.ShouldBe(contact);
        _contextMock.Verify(c => c.CreateEntityAsync(contact, It.IsAny<CancellationToken>()), Times.Once);
    }
}