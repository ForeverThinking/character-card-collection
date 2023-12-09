using CharacterCardCollection;
using CharacterCardCollection.Models.CharacterCard;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CharacterCardCollectionTests;

public class TestWithSqlite : IDisposable
{
    private const string ConnectionString = "Data Source=:memory:";
    private readonly SqliteConnection _connection;

    protected readonly CharacterCardContext Context;

    protected TestWithSqlite()
    {
        _connection = new SqliteConnection(ConnectionString);
        _connection.Open();
        var options = new DbContextOptionsBuilder<CharacterCardContext>()
            .UseSqlite(_connection)
            .Options;
        Context = new CharacterCardContext(options);
        Context.Database.EnsureCreated();
    }

    protected async Task SeedCharactersAsync(List<CharacterModel> characters)
    {
        foreach (var character in characters)
        {
            Context.Characters.Add(character);
        }

        await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _connection.Close();
        GC.SuppressFinalize(this);
    }
}