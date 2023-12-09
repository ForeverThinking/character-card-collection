using System.ComponentModel.DataAnnotations;

namespace CharacterCardCollection.Enums;

public enum Race
{
    [Display(Name = "Human")]
    Human,
    [Display(Name = "Elf")]
    Elf,
    [Display(Name = "Orc")]
    Orc,
    [Display(Name = "Half-elf")]
    HalfElf,
    [Display(Name = "Dwarf")]
    Dwarf,
    [Display(Name = "Halfling")]
    Halfling
}