﻿using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;

namespace CharacterCardCollectionTests;

public sealed class AddCharacterTests : TestWithSqlite
{
    private readonly ICharacterCardService _underTest;

    public AddCharacterTests()
    {
        _underTest = new CharacterCardService(Context);
    }

    [Fact]
    public async Task AddCharacter_CalledWithData_SAvesToDatabase()
    {
        // Arrange
        var data = new CharacterModel
        {
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Rogue,
        };

        // Act
        await _underTest.AddCharacterAsync(data);

        // Assert
        Assert.NotNull(Context.ChangeTracker.Entries());
    }
}
