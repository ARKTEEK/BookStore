using DataLibrary.Models;

namespace BlazorServer.Services;

public class Utilities {
  public static double CalculateDiscount(BookModel bookModel,
    BookTypeModel bookTypeModel) {
    return bookModel.Price + bookTypeModel.PriceIncrease
           - bookModel.Price * bookModel.DiscountModel.Percent / 100;
  }

  public static List<BookModel> RandomBooks(int amount, List<BookModel> Books) {
    List<BookModel> books = Books;
    Random random = new();
    books = books.OrderBy(item => random.Next()).ToList();

    return books.Take(amount).ToList();
  }
}