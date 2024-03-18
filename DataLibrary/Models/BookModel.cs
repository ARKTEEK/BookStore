using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models;

public class BookModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { get; set; }

  [ForeignKey("AuthorId")]
  public int AuthorId { get; set; }

  public virtual AuthorModel? AuthorModel { get; set; }

  [ForeignKey("GenreId")]
  public int GenreId { get; set; }

  public virtual GenreModel? GenreModel { get; set; }

  [MaxLength(8000)]
  public string Description { get; set; }

  public double Price { get; set; }
  public int Purchases { get; set; }

  [ForeignKey("DiscountId")]
  public int? DiscountId { get; set; }

  public virtual DiscountModel? DiscountModel { get; set; }

  public DateTime CreatedAt { get; set; }
  public int Pages { get; set; }
  public string Image { get; set; }
  public bool Active { get; set; }

  public ICollection<CartItemModel> CartItems { get; set; }
}