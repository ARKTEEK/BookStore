using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models;

public class DiscountModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { get; set; }

  [MaxLength(8000)]
  public string Description { get; set; }

  public bool Active { get; set; }
  public int Percent { get; set; }

  public virtual ICollection<BookModel> Books { get; set; }
}