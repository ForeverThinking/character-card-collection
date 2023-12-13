using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;
using FluentAssertions;

namespace CharacterCardCollectionTests.ServiceTests;

public sealed class GetAllCharactersTests : TestWithSqlite
{
    private readonly ICharacterCardService _underTest;

    public GetAllCharactersTests()
    {
        _underTest = new CharacterCardService(Context);
    }

    [Fact]
    public async Task GetAllCharacters_Called_ReturnsCollection()
    {
        // Arrange
        var expectedValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        await SeedCharactersAsync(expectedValues);

        // Act
        var result = await _underTest.GetAllCharactersAsync();

        // Assert
        result.Should().NotBeEmpty();
        result.Should().HaveCount(2);
    }
}