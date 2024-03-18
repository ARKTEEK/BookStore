using DataLibrary.Interfaces;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repositories;

public class CartItemRepository(DataContext context)
  : IRepository<CartItemModel> {
  public List<CartItemModel> GetAll() {
    List<CartItemModel> cartItems = context.CartItems
      .Include(c => c.BookModel)
      .Include(c => c.CartModel)
      .Include(c => c.BookTypeModel).ToList();

    return cartItems;
  }

  public CartItemModel GetById(int id) {
    CartItemModel? cartItems = context.CartItems
      .Include(c => c.BookModel)
      .Include(c => c.CartModel)
      .Include(c => c.BookTypeModel)
      .FirstOrDefault(c => c.Id == id);

    return cartItems;
  }

  public void Add(CartItemModel cartItemModel) {
    context.CartItems.Add(cartItemModel);
    context.SaveChanges();
  }

  public void Update(CartItemModel cartItemModel) {
    context.CartItems.Update(cartItemModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    CartItemModel? cartItem =
      context.CartItems.FirstOrDefault(c => c.Id == key);

    if (cartItem == null) return;

    context.CartItems.Remove(cartItem);
    context.SaveChanges();
  }

  public List<CartItemModel> GetItemsByCartId(int cartId) {
    List<CartItemModel> cartItems = context.CartItems
      .Include(c => c.BookModel)
      .Include(c => c.CartModel)
      .Include(c => c.BookTypeModel)
      .Where(c => c.CartId == cartId).ToList();

    return cartItems;
  }
}