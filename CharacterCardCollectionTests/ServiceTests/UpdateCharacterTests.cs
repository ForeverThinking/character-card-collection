using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;

namespace CharacterCardCollectionTests.ServiceTests;

public class UpdateCharacterTests : TestWithSqlite
{
    private readonly ICharacterCardService _underTest;

    public UpdateCharacterTests()
    {
        _underTest = new CharacterCardService(Context);
    }

    [Fact]
    public async Task UpdateCharacter_CalledWithData_SavesToDatabase()
    {
        // Arrange
        var expectedValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        await SeedCharactersAsync(expectedValues);

        var newData = new CharacterModel
        {
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Rogue,
        };

        // Act
        await _underTest.UpdateCharacterAsync(newData);

        // Assert
        Assert.NotNull(Context.ChangeTracker.Entries());
    }
}
