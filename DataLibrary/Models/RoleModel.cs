using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models;

public class RoleModel {
  [Key]
  public int Id { get; set; }

  [MaxLength(50)]
  public string Name { set; get; }

  public bool Default { get; set; }

  public ICollection<UserModel> Users { get; set; }
}