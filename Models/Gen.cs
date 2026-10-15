using System.ComponentModel.DataAnnotations;

namespace memes_aspnet.Models;

public enum Gen
{
    [Display(Name = "Boomer")]
    Boomer,

    [Display(Name = "Milenial")]
    Milenial,

    [Display(Name = "Gen_Z")]
    GenZ,
    
    [Display(Name = "Gen_Alpha")]
    GenAlpha
}
