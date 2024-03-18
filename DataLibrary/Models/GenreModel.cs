using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models;

public class GenreModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { get; set; }

  public ICollection<BookModel> Books { get; set; }
}