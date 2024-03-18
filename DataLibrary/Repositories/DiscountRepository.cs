using DataLibrary.Interfaces;
using DataLibrary.Models;

namespace DataLibrary.Repositories;

public class DiscountRepository(DataContext context)
  : IRepository<DiscountModel> {
  public List<DiscountModel> GetAll() {
    List<DiscountModel> discounts = context.Discounts.ToList();

    return discounts;
  }

  public DiscountModel GetById(int key) {
    DiscountModel? discount =
      context.Discounts.FirstOrDefault(d => d.Id == key);

    return discount;
  }

  public void Add(DiscountModel discountModel) {
    context.Discounts.Add(discountModel);
    context.SaveChanges();
  }

  public void Update(DiscountModel discountModel) {
    context.Discounts.Update(discountModel);
    context.SaveChanges();
  }

  public void Delete(int key) {
    DiscountModel? discount =
      context.Discounts.FirstOrDefault(d => d.Id == key);

    if (discount == null) return;

    context.Discounts.Remove(discount);
    context.SaveChanges();
  }
}