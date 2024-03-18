using DataLibrary.Interfaces;
using DataLibrary.Models;

namespace DataLibrary.Repositories;

public class BookTypeRepository(DataContext context)
  : IRepository<BookTypeModel> {
  public List<BookTypeModel> GetAll() {
    List<BookTypeModel> bookTypes = context.BookTypes.ToList();

    return bookTypes;
  }

  public BookTypeModel GetById(int id) {
    BookTypeModel? bookType = context.BookTypes.FirstOrDefault(b => b.Id == id);

    return bookType;
  }

  public void Add(BookTypeModel bookTypeModel) {
    context.BookTypes.Add(bookTypeModel);
    context.SaveChanges();
  }

  public void Update(BookTypeModel bookTypeModel) {
    context.BookTypes.Update(bookTypeModel);
    context.SaveChanges();
  }

  public void Delete(int id) {
    BookTypeModel? bookType = context.BookTypes.FirstOrDefault(b => b.Id == id);

    if (bookType == null) return;

    context.BookTypes.Remove(bookType);
    context.SaveChanges();
  }
}