using DataLibrary.Interfaces;
using DataLibrary.Models;

namespace DataLibrary.Repositories;

public class RoleRepository(DataContext context) : IRepository<RoleModel> {
  public List<RoleModel> GetAll() {
    List<RoleModel> roles = context.Roles.ToList();

    return roles;
  }

  public RoleModel GetById(int key) {
    RoleModel? role = context.Roles.FirstOrDefault(r => r.Id == key);

    return role;
  }

  public void Add(RoleModel roleModel) {
    context.Roles.Add(roleModel);
    context.SaveChanges();
  }

  public void Update(RoleModel roleModel) {
    context.Roles.Add(roleModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    RoleModel? role = context.Roles.FirstOrDefault(r => r.Id == key);

    if (role == null) return;
    context.Roles.Remove(role);
    context.SaveChanges();
  }

  public RoleModel GetDefault() {
    RoleModel? role = context.Roles.FirstOrDefault(r => r.Default == true);

    return role;
  }
}