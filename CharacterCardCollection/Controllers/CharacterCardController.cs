using CharacterCardCollection.Services;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCardCollection.Controllers;

public class CharacterCardController : Controller
{
    private readonly ICharacterCardService _characterCardService;
    
    public CharacterCardController(ICharacterCardService characterCardService)
    {
        _characterCardService = characterCardService;
    }
    
    public IActionResult Characters()
    {
        var characters = _characterCardService.GetAllCharacters();
        
        return View(characters);
    }

    public IActionResult Character()
    {
        return View();
    }

    public IActionResult AddCharacter()
    {
        return View();
    }

    public IActionResult DeleteCharacter()
    {
        return View();
    }
}