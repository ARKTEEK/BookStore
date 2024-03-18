using DataLibrary.Interfaces;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repositories;

public class CartRepository(DataContext context) : IRepository<CartModel> {
  public List<CartModel> GetAll() {
    List<CartModel> carts = context.Carts
      .Include(c => c.UserModel).ToList();

    return carts;
  }

  public CartModel GetById(int key) {
    CartModel? cart = context.Carts
      .Include(c => c.UserModel).FirstOrDefault(c => c.Id == key);

    return cart;
  }

  public void Add(CartModel cartModel) {
    context.Carts.Add(cartModel);
    context.SaveChanges();
  }

  public void Update(CartModel cartModel) {
    context.Carts.Update(cartModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    CartModel? cart = context.Carts.FirstOrDefault(c => c.Id == key);

    if (cart == null) return;

    context.Carts.Remove(cart);
    context.SaveChanges();
  }

  public CartModel GetActive(UserModel userModel) {
    CartModel? cart = context.Carts.Include(c => c.UserModel)
      .FirstOrDefault(c => c.UserId == userModel.Id && c.Active == true);

    return cart;
  }

  public CartModel GetActive(int userId) {
    CartModel? cart = context.Carts
      .Include(c => c.UserModel)
      .FirstOrDefault(c => c.UserId == userId && c.Active == true);

    return cart;
  }

  public List<CartModel> GetInactiveUserCarts(UserModel userModel) {
    List<CartModel> carts = context.Carts
      .Include(c => c.UserModel)
      .Where(c => c.UserId == userModel.Id && c.Active == false).ToList();

    return carts;
  }

  public List<CartModel> GetInactiveUserCarts(int userId) {
    List<CartModel> carts = context.Carts
      .Include(c => c.UserModel)
      .Where(c => c.UserId == userId && c.Active == false).ToList();

    return carts;
  }

  public List<CartModel> GetInactiveCarts() {
    List<CartModel> carts = context.Carts
      .Include(c => c.UserModel)
      .Where(c => c.Active == false).ToList();

    return carts;
  }

  public CartModel GetCartByUserId(int userId) {
    CartModel? cart = context.Carts
      .Include(c => c.UserModel)
      .FirstOrDefault(c => c.UserId == userId);

    return cart;
  }
}