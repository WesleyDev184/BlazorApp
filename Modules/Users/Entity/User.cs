using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Modules.Users.Entity;

public class User
{
  [Key]
  public Guid Id { get; init; }
  [Required(ErrorMessage = "O nome é obrigatório.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "O email é obrigatório.")]
  public string CPF { get; set; }
  public bool IsActive { get; set; } = true;
  public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

}
