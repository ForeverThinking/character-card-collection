using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;
using FluentAssertions;

namespace CharacterCardCollectionTests.ServiceTests;

public class GetCharacterTests : TestWithSqlite
{
    private readonly ICharacterCardService _underTest;

    public GetCharacterTests()
    {
        _underTest = new CharacterCardService(Context);
    }

    [Fact]
    public async Task GetCharacter_CalledWithId_ReturnsCharacter()
    {
        // Arrange
        var data = new CharacterModel
        {
            Name = "test1",
            Race = Race.Human,
            Class = CharacterClass.Cleric
        };

        var expectedValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        await SeedCharactersAsync(expectedValues);

        // Act
        var result = await _underTest.GetCharacterAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(data.Name);
        result.Race.Should().Be(data.Race);
        result.Class.Should().Be(data.Class);
    }
}
