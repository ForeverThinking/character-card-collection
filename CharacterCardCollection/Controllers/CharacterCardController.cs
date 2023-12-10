using CharacterCardCollection.Models.CharacterCard;
using CharacterCardCollection.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCardCollection.Controllers;

public sealed class CharacterCardController : Controller
{
    private readonly ICharacterCardService _characterCardService;

    public CharacterCardController(ICharacterCardService characterCardService)
    {
        _characterCardService = characterCardService;
    }

    public async Task<IActionResult> Characters()
    {
        var characters = await _characterCardService.GetAllCharactersAsync();

        return View(characters);
    }

    public async Task<IActionResult> Character([FromRoute] int id)
    {
        var character = await _characterCardService.GetCharacterAsync(id);

        return View(character);
    }

    [HttpGet]
    public IActionResult AddCharacter()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCharacter(CharacterModel character)
    {
        if (!ModelState.IsValid)
        {
            return View(character);
        }

        await _characterCardService.AddCharacterAsync(character);

        return RedirectToAction(nameof(Characters));
    }

    public IActionResult DeleteCharacter()
    {
        return View();
    }
}
