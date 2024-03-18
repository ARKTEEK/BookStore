using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models;

public class CartItemModel {
  [Key]
  public int Id { get; set; }

  [ForeignKey("BookId")]
  public int BookId { get; set; }

  public virtual BookModel BookModel { get; set; }

  [ForeignKey("CartId")]
  public int CartId { get; set; }

  public virtual CartModel CartModel { get; set; }

  public double Price { get; set; }

  [ForeignKey("BookTypeId")]
  public int BookTypeId { get; set; }

  public virtual BookTypeModel BookTypeModel { get; set; }
}