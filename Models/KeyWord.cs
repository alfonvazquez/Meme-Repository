namespace memes_aspnet.Models;

public class KeyWord
{
    public int Id { get; set; }
    public string Word { get; set; } = string.Empty;

    public int MemeId { get; set; }                     // Clave foranea Meme
    public Meme? Meme { get; set; }
}
