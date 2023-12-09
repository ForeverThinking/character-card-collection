using CharacterCardCollection.Models.CharacterCard;
using Microsoft.EntityFrameworkCore;

namespace CharacterCardCollection;

public class CharacterCardContext : DbContext
{
    public CharacterCardContext(DbContextOptions<CharacterCardContext> options)
    : base(options)
    {
    }

    public DbSet<CharacterModel> Characters => Set<CharacterModel>();
}
