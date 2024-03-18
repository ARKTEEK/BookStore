using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models;

public class AuthorModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { get; set; }

  [MaxLength(50)]
  public string Surname { get; set; }

  public ICollection<BookModel> Books { get; set; }
}