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

    [HttpGet]
    public async Task<IActionResult> Characters()
    {
        var characters = await _characterCardService.GetAllCharactersAsync();

        return View(characters);
    }

    [HttpGet]
    public async Task<IActionResult> Character(int id)
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddCharacter(CharacterModel character)
    {
        if (!ModelState.IsValid)
        {
            return View(character);
        }

        await _characterCardService.AddCharacterAsync(character);

        return RedirectToAction(nameof(Characters));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCharacter(int id)
    {
        var character = await _characterCardService.GetCharacterAsync(id);

        return View(character);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateCharacter(CharacterModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _characterCardService.UpdateCharacterAsync(model);

        return RedirectToAction(nameof(Characters));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        var character = await _characterCardService.GetCharacterAsync(id);

        return View(character);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCharacter(CharacterModel model)
    {
        await _characterCardService.DeleteCharacterAsync(model);

        return RedirectToAction(nameof(Characters));
    }
}
