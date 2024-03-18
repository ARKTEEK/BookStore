using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models;

public class CartModel {
  [Key]
  public int Id { get; set; }

  [ForeignKey("UserId")]
  public int UserId { get; set; }

  public UserModel UserModel { get; set; }

  public double Total { get; set; }
  public bool Active { get; set; }
  public DateTime PurchaseDate { get; set; }

  public ICollection<CartItemModel> CartItems { get; set; }
}