using CharacterCardCollection.Models.CharacterCard;
using Microsoft.EntityFrameworkCore;

namespace CharacterCardCollection.Services;

public interface ICharacterCardService
{
    public Task<ICollection<CharacterModel>> GetAllCharactersAsync();
    public Task AddCharacterAsync(CharacterModel character);
}

public sealed class CharacterCardService : ICharacterCardService
{
    private readonly CharacterCardContext _context;

    public CharacterCardService(CharacterCardContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CharacterModel>> GetAllCharactersAsync()
    {
        var allCharacters = await _context.Characters.ToArrayAsync();

        return allCharacters;
    }

    public async Task AddCharacterAsync(CharacterModel character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }
}