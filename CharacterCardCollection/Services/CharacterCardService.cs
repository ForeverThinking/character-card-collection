using CharacterCardCollection.Enums;
using CharacterCardCollection.Models.CharacterCard;

namespace CharacterCardCollection.Services;

public interface ICharacterCardService
{
    public ICollection<CharacterViewModel> GetAllCharacters();
}

public class CharacterCardService : ICharacterCardService
{
    public ICollection<CharacterViewModel> GetAllCharacters()
    {
        var testValues = new List<CharacterViewModel>
        {
            new() { Id = 0, Name = "Cornelius", Race = Race.Human, Class = CharacterClass.Cleric },
            new() { Id = 1, Name = "Felewin", Race = Race.Elf, Class = CharacterClass.Mage },
            new() { Id = 2, Name = "Kren'ok", Race = Race.Orc, Class = CharacterClass.Paladin },
            new() { Id = 3, Name = "Bethelin", Race = Race.HalfElf, Class = CharacterClass.Druid }
        };

        return testValues;
    }
}