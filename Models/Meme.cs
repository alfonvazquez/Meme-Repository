using System.ComponentModel.DataAnnotations;

namespace memes_aspnet.Models;

public class Meme
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Name  { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "La descripcion no puede superar los 1000 caracteres.")]
    public string Description  { get; set; } = string.Empty;
    //public image? Image  { get; set; }
    //public int Score  { get; set; }

    public Gen Gen { get; set;}

    public List<KeyWord> KeyWords { get; set; } = new();

}