using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models;

public class BookTypeModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { get; set; }

  public double PriceIncrease { get; set; }

  public ICollection<CartItemModel> CartItems { get; set; }
}