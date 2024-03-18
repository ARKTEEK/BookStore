using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models;

public class UserModel {
  [Key]
  public int Id { get; set; }

  [ForeignKey("RoleId")]
  public int RoleId { get; set; }

  public virtual RoleModel RoleModel { get; set; }

  [MaxLength(50)]
  public string? Name { get; set; }

  [MaxLength(50)]
  public string? Surname { get; set; }

  public int? Telephone { get; set; }

  [MaxLength(150)]
  public string? StreetAddress { get; set; }

  [MaxLength(35)]
  public string? City { get; set; }

  [MaxLength(65)]
  public string Email { get; set; }

  [MaxLength(55)]
  public string Password { get; set; }

  public ICollection<CartModel> Carts { get; set; }
}