using CharacterCardCollection.Services;
using FluentAssertions;

namespace CharacterCardCollectionTests.ServiceTests;

public class GetAllCharactersTests
{
    private readonly ICharacterCardService _underTest = new CharacterCardService();

    [Fact]
    public void GetAllCharacters_Called_ReturnsCollection()
    {
        // Arrange and Act
        var result = _underTest.GetAllCharacters();

        // Assert
        result.Should().NotBeEmpty();
        result.Should().HaveCount(4);
    }
}