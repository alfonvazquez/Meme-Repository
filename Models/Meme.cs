using System.ComponentModel.DataAnnotations;

namespace memes_aspnet.Models;

public class Meme
{
    public int Id { get; set; }

    [Required(ErrorMessage = "You must provide a Name.")]
    [StringLength(50, ErrorMessage = "The name can't' have more that 50 characters.")]
    public string Name  { get; set; } = string.Empty;

    [StringLength(3000, ErrorMessage = "The description can't have more 1000 characters.")]
    public string Description  { get; set; } = string.Empty;
    
    public string? ImageFileName { get; set; }
    //public int Score  { get; set; }

    public Gen Gen { get; set;}

    public List<KeyWord> KeyWords { get; set; } = new();

}