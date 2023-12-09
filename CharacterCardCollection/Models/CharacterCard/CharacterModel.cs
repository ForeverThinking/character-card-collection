using System.ComponentModel.DataAnnotations;
using CharacterCardCollection.Enums;

namespace CharacterCardCollection.Models.CharacterCard;

public class CharacterModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    public Race Race { get; set; }
    public CharacterClass Class { get; set; }
}