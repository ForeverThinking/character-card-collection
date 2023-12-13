using CharacterCardCollection.Models.CharacterCard;
using Microsoft.EntityFrameworkCore;

namespace CharacterCardCollection.Services;

public interface ICharacterCardService
{
    public Task<ICollection<CharacterModel>> GetAllCharactersAsync();
    public Task AddCharacterAsync(CharacterModel character);
    public Task<CharacterModel> GetCharacterAsync(int id);
    public Task UpdateCharacterAsync(CharacterModel model);
    public  Task DeleteCharacterAsync(CharacterModel model);
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
        var allCharacters = await _context.Characters
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToArrayAsync();

        return allCharacters;
    }

    public async Task AddCharacterAsync(CharacterModel character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task<CharacterModel> GetCharacterAsync(int id)
        => await _context.Characters.AsNoTracking().SingleAsync(c => c.Id == id);

    public async Task UpdateCharacterAsync(CharacterModel model)
    {
        _context.Characters.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(CharacterModel model)
    {
        _context.Characters.Remove(model);
        await _context.SaveChangesAsync();
    }
}