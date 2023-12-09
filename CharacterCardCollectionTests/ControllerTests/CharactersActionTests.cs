using System.Collections.ObjectModel;
using CharacterCardCollection.Controllers;
using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CharacterCardCollectionTests.ControllerTests;

public class CharactersActionTests
{
    private readonly ICharacterCardService _characterCardService = Substitute.For<ICharacterCardService>();
    private readonly CharacterCardController _underTest;

    public CharactersActionTests()
    {
        _underTest = new CharacterCardController(_characterCardService);
    }

    [Fact]
    public void Characters_Called_ReturnsValidView()
    {
        // Arrange
        var expectedValues = new Collection<CharacterModel>
        {
            new() { Id = 0, Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Id = 1, Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        _characterCardService.GetAllCharacters().Returns(expectedValues);
        
        // Act
        var result = _underTest.Characters();
        
        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<ICollection<CharacterModel>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedValues);
    }
}