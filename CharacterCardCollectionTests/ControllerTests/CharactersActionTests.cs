using CharacterCardCollection.Controllers;
using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CharacterCardCollectionTests.ControllerTests;

public sealed class CharactersActionTests : TestWithSqlite
{
    private readonly ICharacterCardService _characterCardService = Substitute.For<ICharacterCardService>();
    private readonly CharacterCardController _underTest;

    public CharactersActionTests()
    {
        _underTest = new CharacterCardController(_characterCardService);
    }

    [Fact]
    public async Task Characters_Called_ReturnsValidView()
    {
        // Arrange
        var expectedValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        await SeedCharactersAsync(expectedValues);

        _characterCardService.GetAllCharactersAsync().Returns(expectedValues);

        // Act
        var result = await _underTest.Characters();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<ICollection<CharacterModel>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedValues);
    }

    [Fact]
    public void GetAddCharacter_Called_ReturnsValidView()
    {
        // Arrange and Act
        var result = _underTest.AddCharacter();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task PostAddCharacter_CalledWithValidModel_ReturnsValidRedirectAction()
    {
        // Arrange
        var validModel = new CharacterModel
        {
            Id = 0,
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        var result = await _underTest.AddCharacter(validModel);

        //Assert
        Assert.IsType<RedirectToActionResult>(result);
        await _characterCardService.Received().AddCharacterAsync(validModel);
    }

    [Fact]
    public async Task PostAddCharacter_CalledWithInvalidModel_ReturnsView()
    {
        // Arrange
        var inValidModel = new CharacterModel
        {
            Id = 0,
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        _underTest.ModelState.AddModelError("fake", "fake");
        var result = await _underTest.AddCharacter(inValidModel);

        //Assert
        Assert.IsType<ViewResult>(result);
        await _characterCardService.DidNotReceive().AddCharacterAsync(inValidModel);
    }

    [Fact]
    public async Task Character_Called_ReturnsValidView()
    {
        // Arrange
        var seedValues = new List<CharacterModel>
        {
            new() { Name = "test1", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Name = "test2", Race = Race.Elf, Class = CharacterClass.Mage }
        };

        var data = new CharacterModel
        {
            Name = "test1",
            Race = Race.Human,
            Class = CharacterClass.Cleric
        };

        await SeedCharactersAsync(seedValues);

        _characterCardService.GetCharacterAsync(0).Returns(data);

        // Act
        var result = await _underTest.Character(0);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<CharacterModel>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(data);
    }

    [Fact]
    public async Task GetUpdateCharacter_CalledWithValidModel_ReturnsValidViewResult()
    {
        // Arrange
        var validModel = new CharacterModel
        {
            Id = 0,
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        var result = await _underTest.UpdateCharacter(validModel.Id);

        //Assert
        Assert.IsType<ViewResult>(result);
        await _characterCardService.Received().GetCharacterAsync(validModel.Id);
    }

    [Fact]
    public async Task PostUpdateCharacter_CalledWithValidModel_ReturnsValidRedirectAction()
    {
        // Arrange
        var validModel = new CharacterModel
        {
            Id = 0,
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        var result = await _underTest.UpdateCharacter(validModel);

        //Assert
        Assert.IsType<RedirectToActionResult>(result);
        await _characterCardService.Received().UpdateCharacterAsync(validModel);
    }

    [Fact]
    public async Task PostUpdateCharacter_CalledWithInvalidModel_ReturnsView()
    {
        // Arrange
        var inValidModel = new CharacterModel
        {
            Id = 0,
            Name = null!,
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        _underTest.ModelState.AddModelError("fake", "fake");
        var result = await _underTest.UpdateCharacter(inValidModel);

        //Assert
        Assert.IsType<ViewResult>(result);
        await _characterCardService.DidNotReceive().UpdateCharacterAsync(inValidModel);
    }

    [Fact]
    public async Task GetDeleteCharacter_CalledWithValidModel_ReturnsValidViewResult()
    {
        // Arrange
        var validModel = new CharacterModel
        {
            Id = 0,
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        var result = await _underTest.DeleteCharacter(validModel.Id);

        //Assert
        Assert.IsType<ViewResult>(result);
        await _characterCardService.Received().GetCharacterAsync(validModel.Id);
    }

    [Fact]
    public async Task PostDeleteCharacter_CalledWithValidModel_ReturnsValidRedirectAction()
    {
        // Arrange
        var validModel = new CharacterModel
        {
            Id = 0,
            Name = "Test",
            Race = Race.Human,
            Class = CharacterClass.Bard,
        };

        // Act
        var result = await _underTest.DeleteCharacter(validModel);

        //Assert
        Assert.IsType<RedirectToActionResult>(result);
        await _characterCardService.Received().DeleteCharacterAsync(validModel);
    }
}
