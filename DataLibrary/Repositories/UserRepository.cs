using DataLibrary.Interfaces;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repositories;

public class UserRepository(DataContext context) : IRepository<UserModel> {
  public List<UserModel> GetAll() {
    List<UserModel> users = context.Users
      .Include(u => u.RoleModel).ToList();

    return users;
  }

  public UserModel GetById(int key) {
    UserModel? user = context.Users
      .Include(u => u.RoleModel)
      .FirstOrDefault(u => u.Id == key);

    return user;
  }

  public void Add(UserModel userModel) {
    context.Users.Add(userModel);
    context.SaveChanges();
  }

  public void Update(UserModel userModel) {
    context.Users.Update(userModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    UserModel? user = context.Users
      .FirstOrDefault(u => u.Id == key);

    if (user == null) return;

    context.Users.Remove(user);
    context.SaveChanges();
  }

  public UserModel GetByEmail(string email) {
    UserModel? user = context.Users
      .Include(u => u.RoleModel)
      .FirstOrDefault(u => u.Email == email);

    return user;
  }
}