using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;

namespace CharacterCardCollectionTests.ServiceTests;

public class DeleteCharacterTests : TestWithSqlite
{
    private readonly ICharacterCardService _underTest;

    public DeleteCharacterTests()
    {
        _underTest = new CharacterCardService(Context);
    }

    [Fact]
    public async Task UpdateCharacter_CalledWithData_SavesToDatabase()
    {
        // Arrange
        var initialValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        await SeedCharactersAsync(initialValues);

        var data = Context.Characters.Single(c => c.Name == "test1");

        // Act
        await _underTest.DeleteCharacterAsync(data);

        // Assert
        Assert.NotNull(Context.ChangeTracker.Entries());
    }
}
