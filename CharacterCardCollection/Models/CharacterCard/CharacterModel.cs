using System.ComponentModel.DataAnnotations;
using CharacterCardCollection.Enums;

namespace CharacterCardCollection.Models.CharacterCard;

public sealed class CharacterModel
{
    [Key]
    public int Id { get; init; }
    [Required]
    public string Name { get; init; } = default!;
    public Race Race { get; init; }
    public CharacterClass Class { get; init; }
}